using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryingSetInstanse1 : MonoBehaviour
{
    public Terrain terain;
    private TreeInstance firstTree;
    void Awake()
    {
        TerrainData terrainDat = terain.terrainData;
        firstTree = terrainDat.GetTreeInstance(0);
        List<TreeInstance> instances = new List<TreeInstance>();

        int counter = 0;
        foreach (TreeInstance tree in terrainDat.treeInstances) {
            if (counter != 0){
            instances.Add(tree);
            }
            counter++;
        }
        print(firstTree);
        print(firstTree.prototypeIndex);
        
        terrainDat.treeInstances = instances.ToArray();
        terrainDat = terain.terrainData;
        //firstTree.prototypeIndex = 1;
        
        //terrainDat.SetTreeInstance(0, firstTree);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
