using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class TerrainObjectsGetControl : MonoBehaviour
{
    public Terrain terain;
    public TreePrototype[] treePrototypesList; // список возможных префабов терейна
    private List<List<int>> indexesTreePrototipes; // индексы объектов, разделённые на группы : деревья, камни, кусты
    private List<List<int>> allObjectIndexesOnGroups;
    private List<List<Vector3>> allObjectPositionOnGroups; //список по группам кординат объектов на терейне 
    private List<List<TreeInstance>> allTreeInstancesOnGroups;//список по группам деревьев объектов на терейне
    private List<int> addForIndexes;

    
    public bool StartFinaly = false; 
    void Awake()
    {
        addForIndexes = new List<int>(){0, 0, 0};
        indexesTreePrototipes = new List<List<int>>(){new List<int>(), new List<int>(), new List<int>()};
        allObjectIndexesOnGroups = new List<List<int>>(){new List<int>(), new List<int>(), new List<int>()};
        allObjectPositionOnGroups = new List<List<Vector3>>(){new List<Vector3>(), new List<Vector3>(), new List<Vector3>()};
        allTreeInstancesOnGroups = new List<List<TreeInstance>>(){new List<TreeInstance>(), new List<TreeInstance>(), new List<TreeInstance>()};

        terain = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>().newTerain.GetComponent<Terrain>();
        while (terain == null)
        {
           terain = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>().newTerain.GetComponent<Terrain>(); 
        }

		TerrainData terrainDat =terain.terrainData;
		treePrototypesList = terrainDat.treePrototypes;
        for (int i = 0; i < treePrototypesList.Length; i++)
        {
            if (treePrototypesList[i].prefab.name.Contains("tree"))
            {
                indexesTreePrototipes[0].Add(i);
            }
            else if (treePrototypesList[i].prefab.name.Contains("Stone"))
            {
                indexesTreePrototipes[1].Add(i);
            }
            else if (treePrototypesList[i].prefab.name.Contains("bush"))
            {
                indexesTreePrototipes[2].Add(i);
            }
        }

         foreach (TreeInstance tree in terrainDat.treeInstances) {
            if (indexesTreePrototipes[0].Contains(tree.prototypeIndex))
            {
                allTreeInstancesOnGroups[0].Add(tree);
            }
            else if (indexesTreePrototipes[1].Contains(tree.prototypeIndex))
            {
                allTreeInstancesOnGroups[1].Add(tree);
            }
            else if (indexesTreePrototipes[2].Contains(tree.prototypeIndex))
            {
                allTreeInstancesOnGroups[2].Add(tree);
            }
        }
        List<TreeInstance> instances = new List<TreeInstance>();
        instances.AddRange(allTreeInstancesOnGroups[0]);
        instances.AddRange(allTreeInstancesOnGroups[1]);
        instances.AddRange(allTreeInstancesOnGroups[2]);
        terrainDat.treeInstances = instances.ToArray();
        terrainDat = terain.terrainData;
        int counter = 0;
        foreach (TreeInstance tree in terrainDat.treeInstances) {
            if (indexesTreePrototipes[0].Contains(tree.prototypeIndex))
            {
                allObjectIndexesOnGroups[0].Add(counter);
                allObjectPositionOnGroups[0].Add(Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position);
            }
            else if (indexesTreePrototipes[1].Contains(tree.prototypeIndex))
            {
                allObjectIndexesOnGroups[1].Add(counter);
                allObjectPositionOnGroups[1].Add(Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position);
            }
            else if (indexesTreePrototipes[2].Contains(tree.prototypeIndex))
            {
                allObjectIndexesOnGroups[2].Add(counter);
                allObjectPositionOnGroups[2].Add(Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position);
            }
            counter++;
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        StartFinaly = true;
    }

    // Update is called once per frame
    void Update()
    {
        print("-=-=");
    }
    public List<List<int>> getAllObjectIndexesOnGroupsList()
    {
        return allObjectIndexesOnGroups;
    }
    public List<List<Vector3>> getAllObjectPositionOnGroupsList()
    {
        return allObjectPositionOnGroups;
    }
    public void editsomethingGroupList(int whyList, List<int> deliteList, List<TreeInstance> addList)
    {
        if (whyList == 1) //stoneList
        {
            print("8*8*8");
            addForIndexes[2] += addList.Count - deliteList.Count;
        }
        else if (whyList == 0) //treeList
        {
            addForIndexes[1] += addList.Count - deliteList.Count;
            addForIndexes[2] += addList.Count - deliteList.Count;
        }
        else if (whyList == 2){}//bushList
        
        
        if (deliteList.Count != 0) 
        {
            print("deliteList.Count " + deliteList.Count);
            for (int i = deliteList.Count - 1; i >= 0; i--)
            {
                print("-=----remove " + i);
                allTreeInstancesOnGroups[whyList].RemoveAt(deliteList[i]);
                allObjectIndexesOnGroups[whyList].RemoveAt(deliteList[i]);
                allObjectPositionOnGroups[whyList].RemoveAt(deliteList[i]);
            }
        }
        if (addList.Count != 0)
        {
            allTreeInstancesOnGroups[whyList].AddRange(addList);
        }
        reWriteTreeInstances();

    }
    public void reWriteTreeInstances()
    {
        TerrainData terrainDat =terain.terrainData;
        List<TreeInstance> instances = new List<TreeInstance>();
        instances.AddRange(allTreeInstancesOnGroups[0]);
        instances.AddRange(allTreeInstancesOnGroups[1]);
        instances.AddRange(allTreeInstancesOnGroups[2]);
        terrainDat.treeInstances = instances.ToArray();
    }
    public List<int> getAddForIndexesList()
    {
        return addForIndexes;
    }
}
