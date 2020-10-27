using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTerrainSectorObjectControl : MonoBehaviour
{
    private TerrainObjectsGetControl getTerrainObjScr;
    private List<List<Vector3>> allObjectPositionOnGroups;
    private List<List<int>> allObjectIndexesOnGroups;
    private List<Vector3> playerSectorWithStonesPosition;
    private List<int> playerSectorWithStonesIndexes; // хранит индексы деревьев(камней) в глобальном массиве
    public float findBlastRange = 100.0f;  
    public bool StartFinaly = false; 

    void Awake()
    {
        playerSectorWithStonesPosition = new List<Vector3>();
        playerSectorWithStonesIndexes = new List<int>();
        getTerrainObjScr = gameObject.GetComponent<TerrainObjectsGetControl>();
        print("--------player Pos " + transform.position);
    }
    
    void Start()
    {
        allObjectPositionOnGroups = getTerrainObjScr.getAllObjectPositionOnGroupsList();
        allObjectIndexesOnGroups = getTerrainObjScr.getAllObjectIndexesOnGroupsList();
        int counter = 0;
        print("^^^^^^^^^^^^^^  "  + allObjectPositionOnGroups[1].Count);
        foreach (Vector3 stonePosition in allObjectPositionOnGroups[1])
        {
            //print("=-=-====Stone pos " + stonePosition);
            float distance = Vector3.Distance(stonePosition, transform.position);
            if (distance < findBlastRange)
            {
                //print("**");
                playerSectorWithStonesPosition.Add(allObjectPositionOnGroups[1][counter]);
                playerSectorWithStonesIndexes.Add(allObjectIndexesOnGroups[1][counter]);

            }
            counter++;
        }
        StartFinaly = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        print("-=-");
    }
    public List<Vector3> getPlayerSectorWithStonesPositionList()
    {
        return playerSectorWithStonesPosition;
    }
    public List<int> getPlayerSectorWithStonesIndexesList()
    {
        return playerSectorWithStonesIndexes;
    }
    public void editSectorStones(List<int> deliteList, List<TreeInstance> addList, List<int> alivingInstancesLocalIdexes)
    {
        if (deliteList.Count != 0) 
        {
            print("deliteList.Count " + deliteList.Count);
            for (int i = alivingInstancesLocalIdexes.Count - 1; i >= 0; i--)
            {
                playerSectorWithStonesPosition.RemoveAt(alivingInstancesLocalIdexes[i]);
                playerSectorWithStonesIndexes.RemoveAt(alivingInstancesLocalIdexes[i]);
            }
        }
        getTerrainObjScr.editsomethingGroupList(1, deliteList, addList);
    }
    public void AddStonesLists(Vector3 positionTree, int globalIndex)
    {
        playerSectorWithStonesPosition.Add(positionTree);
        playerSectorWithStonesIndexes.Add(globalIndex);
    }

}
