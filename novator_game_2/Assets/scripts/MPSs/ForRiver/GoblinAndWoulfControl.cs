using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAndWoulfControl : ForRiverMPSParentControl
{
    GoblinAndWoulfControl selfScr;
    void Awake()
    {
        ParentAwake();
        selfScr = gameObject.GetComponent<GoblinAndWoulfControl>();
        prefabsStorageScript.SetGoblinAndWoulfControl(selfScr);
        prefabsStorageScript.TryingClass();
        print("-=-=-=-=" + prefabsStorageScript.GetOutRivPoint().Count);
    }
    
    void AfterAwake()
    {
        ParentAwake();
        if (goblinTargetPoints.Count == 0)
        {
            int a = 0;
            while (goblinTargetPoints.Count == 0)
            {
                a ++;
                goblinTargetPoints = prefabsStorageScript.GetOutRivPoint();
                if (goblinTargetPoints.Count != 0 | a > 10)
                {
                    //var rr = goblinTargetPoints[1000];
                    break;
                }
            }
        
            //goblinTargetPoints = prefabsStorageScript.GetOutRivPoint();
        }
        List<Vector3> poss = new List<Vector3>(goblinTargetPoints);
        int gg = (int)Random.Range(0.0f, (float)poss.Count - 5);
        int hhh ;
        for (int i = 0; i > gg; i++)
        {
            hhh = (int)Random.Range(0.0f, (float)poss.Count-1);
            if (poss.Count - 2 < hhh)
            {
                print("---" + hhh + " " + goblinTargetPoints.Count);
                poss.RemoveAt(hhh);
            }
        }
        Vector3 pos;
        for (int i = 0;  i > poss.Count - 2; i++)
        {
            if (poss.Count-1 < i)
            {
                pos = poss[i];
                poss.RemoveAt(i);
                poss.Insert((int)Random.Range(0.0f, (float)poss.Count), pos);
            }
        }
        SetPointsList(poss);
        agent.SetDestination(poss[0]);
        targetPos = poss[0];
        print("*^^^^^^^^^^^^^^^^^^^^******_____________");
        //agent.destination = targetPos;
    }
    //void Start()
//{
        
    //}

    // Update is called once per frame
    void Update()
    {
        ParentUpdate();
    }
    void FixedUpdate()
    {
        ParentFixedUpdate();
    }
    public void SetGoblinTargetPoints(List<Vector3> listt)
    {
        goblinTargetPoints = listt;
        print("------%%%%%%");
        AfterAwake();
    }
}
