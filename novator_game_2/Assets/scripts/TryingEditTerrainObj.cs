using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class TryingEditTerrainObj : MonoBehaviour
{

    public Terrain terrain;
    private List<TreeInstance> trees;
    // Start is called before the first frame update
 
    void Start()
    {
        trees = new List<TreeInstance>(terrain.terrainData.treeInstances);
        print(trees[0].position);
        terrain.terrainData.treeInstances = trees.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
