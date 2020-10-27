
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TreeColliderMaker
{
        /* 
        public static void MakeTreeColliders(Terrain terrain)
        {
                GameObject treeColliders = new GameObject("Tree Colliders");
                treeColliders.transform.parent = terrain.transform;
                TerrainData td = terrain.terrainData;
                TreeInstance[] tis = td.treeInstances;
                TreePrototype[] tps = td.treePrototypes;
                Bounds[] bounds = new Bounds[tps.Length];
                //float[] radii = new float[tps.Length];
                //IEnumerable<World.Tree> worldTrees = Globals.instance.worldProperties.terrains.First(wt => wt.name == terrain.name).GetTrees();
                for (int i = 0; i < tps.Length; i++)
                {
                        bounds[i] = tps[i].prefab.gameObject.GetComponent<MeshFilter>().sharedMesh.bounds;
                        //radii[i] = worldTrees.First(wt => wt.name == tps[i].prefab.name).trunkSize;
                }
                int index = 0;
                foreach (TreeInstance ti in tis)
                {
                        GameObject tc = new GameObject("TC" + String.Format("{0:00000}", index));
                        CapsuleCollider cc = tc.AddComponent<CapsuleCollider>();
                        cc.direction = 1;
                        //cc.radius = radii[ti.prototypeIndex] * ti.widthScale;
                        cc.height = bounds[ti.prototypeIndex].size.y * ti.heightScale;
                        cc.center = Vector3.up * cc.height / 2f;
                        tc.transform.parent = treeColliders.transform;
                        tc.transform.position = TerrainExtras.WorldCoordinates(terrain, ti.position);
                        index++;
                }
        }

}

public class TerrainExtras 
{

        public static Vector3 WorldCoordinates(Terrain terrain, Vector3 point)
        {
                Vector3 tdSize = terrain.terrainData.size;
                point.y = terrain.terrainData.GetHeight((int)(point.x * terrain.terrainData.heightmapWidth), (int)(point.z * terrain.terrainData.heightmapHeight));
                point.x *= tdSize.x;
                point.z *= tdSize.z;
                point += terrain.transform.position;
                return point;
        }

        
        
}


public class TreeCollidersEditor
{



        [MenuItem("GameObject/Make Tree Colliders")]
        static void MakeTreeCollidersMenuItem()
        {
                foreach (Transform selection in Selection.transforms)
                {

                        Terrain terrain = selection.GetComponent<Terrain>();
                        if (terrain)
                                TreeColliderMaker.MakeTreeColliders(terrain);

                }
        }

        [MenuItem("GameObject/Make Tree Colliders", true)]
        static bool ValidateMakeTreeCollidersMenuItem()
        {
                if (Selection.activeTransform)
                {
                        foreach (Transform selection in Selection.transforms)
                        {
                                Terrain terrain = selection.GetComponent<Terrain>();
                                if (terrain)
                                        return true;
                        }
                        return false;
                }
                else
                        return false;
        }*/

}


