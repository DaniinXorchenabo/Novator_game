// This test class allows to test performance for kdtree when running
// 1 : single threaded with regular arrays
// 2 : single threaded with native arrays
// 3 : jobified (multithreaded) with native arrays

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Burst;

public class KDtest : MonoBehaviour
{

    Vector3[] points;
    NativeArray<float3> points_native;
    NativeArray<float3> queries;

    NativeArray<int> answers;

    public int nData = 5000;
    public int nQueries = 5000;

    public bool printTotalSizeOnUpdate = false;

    struct KdSearchJob : IJobParallelFor
    {
        [ReadOnly] public KDTreeStruct kd_job;
        [ReadOnly] public NativeArray<float3> points_job;
        [ReadOnly] public NativeArray<float3> queries_job;

        public NativeArray<int> answers_job;

        public void Execute(int i)
        {
            answers_job[i] = kd_job.FindNearest2(queries_job[i]);
        }
    }

    [BurstCompile]
    struct KdSearchJobBurst : IJobParallelFor
    {
        [ReadOnly] public KDTreeStruct kd_job;
        [ReadOnly] public NativeArray<float3> points_job;
        [ReadOnly] public NativeArray<float3> queries_job;

        public NativeArray<int> answers_job;

        public void Execute(int i)
        {
            answers_job[i] = kd_job.FindNearest2(queries_job[i]);
        }
    }



    void Start()
    {
        UnityEngine.Random.InitState(48);

        points = new Vector3[nData];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = UnityEngine.Random.insideUnitSphere;
        }

        points_native = new NativeArray<float3>(nData, Allocator.Persistent);

        for (int i = 0; i < points.Length; i++)
        {
            points_native[i] = points[i];
        }

        queries = new NativeArray<float3>(nQueries, Allocator.Persistent);
        answers = new NativeArray<int>(nQueries, Allocator.Persistent);
        for (int i = 0; i < queries.Length; i++)
        {
            queries[i] = UnityEngine.Random.insideUnitSphere;
        }

        MakeAndFind0();
        MakeAndFind1();
        MakeAndFind2();

    }

    KDTree kd0;
    void MakeAndFind0()
    {
        kd0 = KDTree.MakeFromPoints(points);

        float r = 0;
        for (int i = 0; i < queries.Length; i++)
        {
            int id = kd0.FindNearest(queries[i]);
            float3 relative = queries[i] - points_native[id];
            r = r + math.sqrt(math.dot(relative, relative));
        }

        Debug.Log("Regular array " + r);
    }

    KDTreeStruct kd1;
    void MakeAndFind1()
    {
        kd1 = new KDTreeStruct();
        kd1.MakeFromPoints(points_native);

        float rTot = 0;
        for (int i = 0; i < queries.Length; i++)
        {
            int id = kd1.FindNearest2(queries[i]);
            float3 relative = queries[i] - points_native[id];
            rTot = rTot + math.sqrt(math.dot(relative, relative));
        }

        Debug.Log("Native array single threaded " + rTot);
    }

    KDTreeStruct kd2;
    void MakeAndFind2()
    {
        kd2 = new KDTreeStruct();
        kd2.MakeFromPoints(points_native);

        float rTot = 0;
        for (int i = 0; i < queries.Length; i++)
        {
            int id = kd2.FindNearest2(queries[i]);
            float3 relative = queries[i] - points_native[id];
            rTot = rTot + math.sqrt(math.dot(relative, relative));
        }

        Debug.Log("Native array jobified " + rTot);
    }

    int imode = 0;
    void Update()
    {
        // 		rTot here is the total of lengths between all query points and their nearest neighbours
        //      rTot is a good controlling parameter to estimate if kdtree works correctly
        float rTot = 0;
        if (imode == 0)
        {
            for (int i = 0; i < queries.Length; i++)
            {
                int j = kd0.FindNearest(queries[i]);
                float3 relative = queries[i] - points_native[j];
                rTot = rTot + math.sqrt(math.dot(relative, relative));
            }
        }
        else if (imode == 1)
        {
            for (int i = 0; i < queries.Length; i++)
            {
                int j = kd1.FindNearest2(queries[i]);
                float3 relative = queries[i] - points_native[j];
                rTot = rTot + math.sqrt(math.dot(relative, relative));
            }
        }
        else if (imode == 2)
        {

            int processorCount = System.Environment.ProcessorCount;
            var job = new KdSearchJob()
            {
                kd_job = kd2,
                points_job = points_native,
                queries_job = queries,
                answers_job = answers
            };

            JobHandle jobHandle = job.Schedule(queries.Length, processorCount);

            jobHandle.Complete();

            for (int i = 0; i < answers.Length; i++)
            {
                int j = answers[i];
                float3 relative = queries[i] - points_native[j];
                rTot = rTot + math.sqrt(math.dot(relative, relative));
            }
        }
        else if (imode == 3)
        {

            int processorCount = System.Environment.ProcessorCount;
            var job = new KdSearchJobBurst()
            {
                kd_job = kd2,
                points_job = points_native,
                queries_job = queries,
                answers_job = answers
            };

            JobHandle jobHandle = job.Schedule(queries.Length, processorCount);

            jobHandle.Complete();

            for (int i = 0; i < answers.Length; i++)
            {
                int j = answers[i];
                float3 relative = queries[i] - points_native[j];
                rTot = rTot + math.sqrt(math.dot(relative, relative));
            }
        }

        if (printTotalSizeOnUpdate)
        {
            Debug.Log(rTot);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            imode = 0;
            Debug.Log("running with regular arrays");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            imode = 1;
            Debug.Log("running with native arrays");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            imode = 2;
            Debug.Log("running jobified");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            imode = 3;
            Debug.Log("running jobified with burst");
        }
    }

    void OnApplicationQuit()
    {
        kd1.DisposeArrays();
        kd2.DisposeArrays();
        points_native.Dispose();
        queries.Dispose();
        answers.Dispose();
    }

}
