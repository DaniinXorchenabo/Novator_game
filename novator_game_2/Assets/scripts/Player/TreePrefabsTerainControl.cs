using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ListsStorage
{
    private static int emptyTreeInd;
    private static TreeInstance emptyTree;
    private static List<List<int>> allObjectIndexesOnGroups = new List<List<int>>(){
                new List<int>(),
                new List<int>(),
                new List<int>()}; //хранит позиции элементов в terrainData
    private static List<List<Vector3>> allObjectPositionOnGroups = new List<List<Vector3>>(){
                new List<Vector3>(),
                new List<Vector3>(),
                new List<Vector3>()}; //список по группам кординат объектов на терейне 
    private static List<List<TreeInstance>> allTreeInstancesOnGroups = new List<List<TreeInstance>>(){
                new List<TreeInstance>(), 
                new List<TreeInstance>(), 
                new List<TreeInstance>(), // индексы в этих списках именубтся как GroupIndex
                new List<TreeInstance>()};//список по группам деревьев объектов на терейне
    private static List<Dictionary<int,TreeInstance>> alivingObjOnGroups = new List<Dictionary<int,TreeInstance>>(){
                new Dictionary<int,TreeInstance>(), 
                new Dictionary<int,TreeInstance>(), 
                new Dictionary<int,TreeInstance>(),//список по группам деревьев перемещённых с терейна по группам
                new Dictionary<int,TreeInstance>()};// в качестве ключа выступает индекс, который принадлежал элементу в terrainData
    private static List<Dictionary<int,int>> tablIndexes = new List<Dictionary<int, int>>(){
                new Dictionary<int,int>(), //список по группам деревьев перемещённых с терейна по группам
                new Dictionary<int,int>(), // в качестве ключа выступает индекс, который принадлежал элементу в terrainData
                new Dictionary<int,int>(), // в качестве аргумента - индекс этого же дерева в группе
                new Dictionary<int,int>()};


    private static List<int> addForIndexes = new List<int>(){0, 0, 0}; 
    private static List<int> treeCountList = new List<int>(){0, 0, 0, 0}; 
    private static Terrain terain;
    //private Terrain terain;


    public static List<List<int>> get_aOIOG()          {return allObjectIndexesOnGroups;}
    public static List<List<Vector3>> get_aOPOG()      {return allObjectPositionOnGroups;}
    public static List<List<TreeInstance>> get_aTIOG() {return allTreeInstancesOnGroups;}
    public static List<int> get_aFI()                  {return addForIndexes;}

    public static void Set_tIs(List<Dictionary<int,int>> tI1)      {tablIndexes = tI1;}
    public static void set_aOIOG(List<List<int>> aOIOG)            {allObjectIndexesOnGroups = aOIOG;}
    public static void set_aOPOG(List<List<Vector3>> aOPOG)        {allObjectPositionOnGroups = aOPOG;}
    public static void set_aFI(List<int> aFI)                      {addForIndexes = aFI;}
    public static void set_aTIOG(List<List<TreeInstance>> aTIOG){
        allTreeInstancesOnGroups = aTIOG;
        for (int i = 0; i < aTIOG.Count; i++) {treeCountList[i] = aTIOG[i].Count;}}

    public static int getTreesListLen(string key){return treeCountList[returnFromKey(key)];}
    public static Vector3 getTreePosByIndexInGroup(string key, int index_){return allObjectPositionOnGroups[returnFromKey(key)][index_];}
    public static List<Vector3> getTreePosRangeByGroupIndex(string key, int indexTo, int CountElements){
        int keyy = returnFromKey(key);
        if (getTreesListLen(key)> indexTo + CountElements)
        {return allObjectPositionOnGroups[keyy].GetRange(indexTo, CountElements);}
        else {return allObjectPositionOnGroups[keyy].GetRange(indexTo, getTreesListLen(key) - indexTo);} }

    public static List<int> getTDIndexesRangeByGroupIndex(string key, int indexTo, int CountElements){  //вернуть промежуток с индексами(terrainData)
        int keyy = returnFromKey(key);
        if (getTreesListLen(key)> indexTo + CountElements)
        {return allObjectIndexesOnGroups[keyy].GetRange(indexTo, CountElements);}
        else {return allObjectIndexesOnGroups[keyy].GetRange(indexTo, getTreesListLen(key) - indexTo);}}
    
    
    public static void ReWriteTreeIntoTerrainData(){
        List<TreeInstance> instances = new List<TreeInstance>();
        instances.AddRange(allTreeInstancesOnGroups[0]);
        instances.AddRange(allTreeInstancesOnGroups[1]);
        instances.AddRange(allTreeInstancesOnGroups[2]);
        instances.AddRange(allTreeInstancesOnGroups[3]);
        terain.terrainData.treeInstances = instances.ToArray();
    }
    public static void EditTerrainTreesList(string key, List<int> AlivingTree, List<int> movementInTerainTree){
        MovementTreesFromTerainIntoAlivingList(key, AlivingTree);
        MovementTreesToTerainFromAlivingList(key, movementInTerainTree);

    }
    public static void MovementTreesFromTerainIntoAlivingList(string key, List<int> AlivingTree){
        int keyy = returnFromKey(key);
        foreach (int index in AlivingTree)
        {
            alivingObjOnGroups[keyy][index] = allTreeInstancesOnGroups[keyy][tablIndexes[keyy][index]];
            allTreeInstancesOnGroups[keyy][tablIndexes[keyy][index]] = emptyTree;  //равно пустышке
            allObjectPositionOnGroups[keyy][tablIndexes[keyy][index]] = new Vector3(0,0,0);
        }}
    public static void MovementTreesToTerainFromAlivingList(string key, List<int> movementInTerainTree){
        int keyy = returnFromKey(key);
        foreach (int index in movementInTerainTree)
        {
            allTreeInstancesOnGroups[keyy][tablIndexes[keyy][index]] = alivingObjOnGroups[keyy][index];
            allObjectPositionOnGroups[keyy][tablIndexes[keyy][index]] = Vector3.Scale(alivingObjOnGroups[keyy][index].position, terain.terrainData.size) + terain.transform.position;
            alivingObjOnGroups[keyy].Remove(index);
        }}
    private static int returnFromKey(string key1){
        if (key1 == "stone"){return 1;}
        else if (key1 == "tree"){return 0;}
        else if (key1 == "bush"){return 2;}
        else{return 3;}}
    private static TreeInstance CreateEmptyTree(int prototipeIndexEmpty, Vector3 pos){
        return new TreeInstance{
                                prototypeIndex = prototipeIndexEmpty,
                                position = pos};}

    private static TreeInstance getTreeInstanceFromTerrainDataByIndex(int index_){return terain.terrainData.GetTreeInstance(index_);}

    /*public ListsStorage(List<List<int>> aOIOG,
                    List<List<Vector3>> aOPOG,
                    List<List<TreeInstance>> aTIOG,
                    List<int> aFI,
                    Terrain terainn)
                    {setAllLists(aOIOG, aOPOG, aTIOG, aFI);
                    terain = terainn;}*/
    public static void EditOnStart(List<List<int>> aOIOG,
                    List<List<Vector3>> aOPOG,
                    List<List<TreeInstance>> aTIOG,
                    List<int> aFI,
                    Terrain terainn,
                     List<Dictionary<int,int>> tI1, int emptyTreeIndex1){
        setAllLists(aOIOG, aOPOG, aTIOG, aFI, tI1);
        terain = terainn;
        emptyTreeInd = emptyTreeIndex1;
        emptyTree = CreateEmptyTree(emptyTreeInd, new Vector3(0,0,0));}

    public static void setAllLists(
                                    List<List<int>> aOIOG,
                                    List<List<Vector3>> aOPOG,
                                    List<List<TreeInstance>> aTIOG,
                                    List<int> aFI, 
                                    List<Dictionary<int,int>> tI1){
        set_aOIOG(aOIOG);
        set_aOPOG(aOPOG);
        set_aTIOG(aTIOG);
        set_aFI(aFI); 
        Set_tIs(tI1);}
}

public static class StonesNearPlayer
{
    private static List<Vector3> stonesPos = new List<Vector3>();
    private static List<Vector3> newStonesPos = new List<Vector3>();
    private static List<int> indexesStones = new List<int>(); //хранит индексы объектов в terrainData
    private static List<int> newIndexesStones = new List<int>();
    private static Vector3 lastPos;
    private static float findBlastRange;
    private static float editStoneListRange;
    private static int counter = 0;
    private static int forEditStoneListTO = 0;
    private static int forEditStoneListDO;
    private static int forEditStoneListSetup = 5000;
    private static bool goEditListPosStonesFlag = false;
    private static bool isReadNewList = false;
    

    /*public StonesNearPlayer()
    */
    public static void EditStart(Vector3 setLastPos, float setFindBlastRange, float eSLR)
    {   lastPos = setLastPos;
        findBlastRange = setFindBlastRange; 
        editStoneListRange = eSLR;}
    
    public static List<Vector3> getStonesPos(){isReadNewList = false;return stonesPos; }
    public static List<int> getIndexesStones(){ isReadNewList = false;return indexesStones;}

    public static void setStonesPos(List<Vector3> sStonesPos)    {stonesPos = sStonesPos; isReadNewList = true;}
    public static void setIndexesStones(List<int> sIndexesStones){indexesStones = sIndexesStones; isReadNewList = true;}

    public static void setAllLists(List<Vector3> sStonesPos, List<int> sIndexesStones) {setStonesPos(sStonesPos); setIndexesStones(sIndexesStones);}

    public static bool IsEditLists(){if (isReadNewList){return true;} else {return false;}}

    public static float distance;
    public static void editStonePosList(Vector3 nowPos)
    {
        distance = Vector3.Distance(lastPos, nowPos);
        //print("---distance " + distance);
        if ((goEditListPosStonesFlag) || (Mathf.Abs(distance) >= Mathf.Abs(editStoneListRange)))
        {
            if (counter == 0)
            {
                lastPos = nowPos;
                forEditStoneListTO = 0;
                forEditStoneListDO = forEditStoneListSetup;
                goEditListPosStonesFlag = true;
                
            }
            List<Vector3> stonesPosPart = ListsStorage.getTreePosRangeByGroupIndex("stone", forEditStoneListTO, forEditStoneListSetup);
            List<int> stonesTDIndexesPart = ListsStorage.getTDIndexesRangeByGroupIndex("stone", forEditStoneListTO, forEditStoneListSetup);
            if (forEditStoneListTO + forEditStoneListSetup >= stonesPosPart.Count - 1) // stonesPos брать из класса с террейном
            {
                forEditStoneListDO = stonesPosPart.Count - 1;
                counter = -1;
            }
            /*for (int i = 0; i < forEditStoneListDO; i++)
            {
                float distToStone = Vector3.Distance(stonesPosPart[i], nowPos);
                if (distToStone < findBlastRange)
                {
                    newStonesPos.Add(stonesPosPart[i]);
                    newIndexesStones.Add(stonesTDIndexesPart[i]);// в newIndexesStones должны быть индкексы объектов (в terainData) 
                }

                float distance = Vector3.Distance(locPosSton, myTransform.position);
                if (distance < findBlastRange)
                {
                    stonePosition.Add(locPosSton);
                    stoneIndexes.Add(counter);
                }

            }*/
            int counterr = 0;
            foreach (Vector3 stonePos in stonesPosPart) {
                float distToStone = Vector3.Distance(stonePos, lastPos);
                if (distToStone < findBlastRange)
                {
                    newStonesPos.Add(stonePos);
                    newIndexesStones.Add(stonesTDIndexesPart[counterr]);// в newIndexesStones должны быть индкексы объектов (в terainData) 
                }
                counterr++;
            }
            if (counter == -1)
            {
                
                stonesPos = new List<Vector3>(newStonesPos);
                indexesStones = new List<int>(newIndexesStones);
                newStonesPos =  new List<Vector3>();
                newIndexesStones = new List<int>();
                goEditListPosStonesFlag = false;
                isReadNewList = true;
            }
            else
            {
                forEditStoneListTO += forEditStoneListSetup;
                //forEditStoneListDO += forEditStoneListSetup;
            }
            counter++;
        }
    }
}

public class TreePrefabsTerainControl : MonoBehaviour
{
    public TreePrototype[] treePrototypesList; // список возможных префабов терейна
    //private StonesNearPlayer stonesNearPlayer;
    public float BlastRange = 5.0f;
    public float findBlastRange = 100.0f; 
    public float editStoneListRange = 70.0f;
    private Terrain terain;
    private Transform myTransform;
    private List<List<int>> indexesTreePrototipes = new List<List<int>>(){
                new List<int>(),
                new List<int>(),
                new List<int>()}; // индексы объектов, разделённые на группы : деревья, камни, кусты
    private List<Vector3> stonePosition = new List<Vector3>();
    private List<int> stoneIndexes = new List<int>();
    private List<GameObject> alivingTerrainObjects = new List<GameObject>();
    private List<int> alivingTerrainObjectsSectorIndexes = new List<int>();
    private List<int> alivingTerrainObjectsIndexes = new List<int>();
    private Vector3 myLastPosition;
    private int CounterForAliving = 0;
    private int stonePositionCount = 0;
    void Awake()
    {
        myTransform = transform;
        myLastPosition = myTransform.position;
        //stonesNearPlayer = new StonesNearPlayer(myTransform.position, findBlastRange, editStoneListRange);
        StonesNearPlayer.EditStart(myTransform.position, findBlastRange, editStoneListRange);
        terain = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>().newTerain.GetComponent<Terrain>();
        while (terain == null)
        {
           terain = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>().newTerain.GetComponent<Terrain>(); 
        }

        TerrainData terrainDat = terain.terrainData;
		treePrototypesList = terrainDat.treePrototypes;
        List<List<TreeInstance>> allTreeInstancesOnGroups = new List<List<TreeInstance>>(){
                    new List<TreeInstance>(), 
                    new List<TreeInstance>(), 
                    new List<TreeInstance>(), 
                    new List<TreeInstance>()};
        List<List<int>> allObjectIndexesOnGroups = new List<List<int>>(){
                    new List<int>(),
                    new List<int>(),
                    new List<int>()};
        List<List<Vector3>> allObjectPositionOnGroups = new List<List<Vector3>>(){
                    new List<Vector3>(),
                    new List<Vector3>(),
                    new List<Vector3>()}; //список по группам кординат объектов на терейне 
        List<Dictionary<int,int>> tablIndexes = new List<Dictionary<int, int>>(){
                    new Dictionary<int,int>(), //список по группам деревьев перемещённых с терейна по группам
                    new Dictionary<int,int>(), // в качестве ключа выступает индекс, который принадлежал элементу в terrainData
                    new Dictionary<int,int>(), // в качестве аргумента - индекс этого же дерева в группе
                    new Dictionary<int,int>()};
        int emptyTreeIndex = 0;
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
            } else if (treePrototypesList[i].prefab.name.Contains("empty"))
            {
                emptyTreeIndex = i;
            }
        }
        print("--emptyTreeIndex " + emptyTreeIndex);
        print("--всего деревьев1 " + terrainDat.treeInstanceCount);
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
            } else {
                allTreeInstancesOnGroups[3].Add(tree);
            }
        }

        List<TreeInstance> instances = new List<TreeInstance>();
        instances.AddRange(allTreeInstancesOnGroups[0]);
        instances.AddRange(allTreeInstancesOnGroups[1]);
        instances.AddRange(allTreeInstancesOnGroups[2]);
        instances.AddRange(allTreeInstancesOnGroups[3]);
        terrainDat.treeInstances = instances.ToArray();

        terrainDat = terain.terrainData;
        int counter = 0; //индекс элемента в terrainData
        int counter0 = 0;
        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;
        foreach (TreeInstance tree in terrainDat.treeInstances)
        {
            if (indexesTreePrototipes[0].Contains(tree.prototypeIndex))
            {
                allObjectIndexesOnGroups[0].Add(counter);
                allObjectPositionOnGroups[0].Add(Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position);
                tablIndexes[0][counter] = counter0;
                counter0++;
            }
            else if (indexesTreePrototipes[1].Contains(tree.prototypeIndex))
            {
                Vector3 locPosSton = Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position;
                allObjectIndexesOnGroups[1].Add(counter);
                allObjectPositionOnGroups[1].Add(locPosSton);
                float distance = Vector3.Distance(locPosSton, myTransform.position);
                if (distance < findBlastRange)
                {
                    stonePosition.Add(locPosSton);
                    stoneIndexes.Add(counter);
                }
                tablIndexes[1][counter] = counter1;
                counter1++;
            }
            else if (indexesTreePrototipes[2].Contains(tree.prototypeIndex))
            {
                allObjectIndexesOnGroups[2].Add(counter);
                allObjectPositionOnGroups[2].Add(Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position);
                tablIndexes[2][counter] = counter2;
                counter2++;
                
            } else{
                tablIndexes[3][counter] = counter3;
                counter3++;
            }
            counter++;
        }
        print("--всего деревьев2 " + terain.terrainData.treeInstanceCount);
        ListsStorage.EditOnStart(allObjectIndexesOnGroups, allObjectPositionOnGroups, allTreeInstancesOnGroups, new List<int>(){0, 0, 0, 0}, terain, tablIndexes, emptyTreeIndex);
        StonesNearPlayer.setAllLists(stonePosition, stoneIndexes);
    }

    void FixedUpdate()
    {
        StonesNearPlayerInteraction();
        if (myTransform.position == myLastPosition){
            Explode();
        }
        
        myLastPosition = myTransform.position;
    }

    void StonesNearPlayerInteraction()
    {
        StonesNearPlayer.editStonePosList(myTransform.position);
        
        if(StonesNearPlayer.IsEditLists())
        {
            print("поменял сектор");
            print((int)StonesNearPlayer.distance);
            print("камнейц в секторе " + stonePosition.Count);
            stonePosition = StonesNearPlayer.getStonesPos();
            stonePositionCount = stonePosition.Count;
            stoneIndexes = StonesNearPlayer.getIndexesStones();
        }  
    }
    void Explode()
    {
        //alivingTerrainObjects - список с игровыми объектами из террейна
        //alivingTerrainObjectsSectorIndexes - список с локальными индексами (индекскам в секторе) оживших объектов
        //treeInstancesGoingTerrain - список с индексами(в terainData) объектов, которые надо вернуть на террейн
        //treeInstancesFromTerrain - список м индексами(в terainData) объектов, которые надо убрать с террейна
        //stonePosition - список со всеми позициями сектора
        //stoneIndexes - список со всеми индексами в terainData сектора 
        //alivingTerrainObjectsIndexes - список с нндексами всех оживших объектов
        //if (stonePositionCount > )
        List<int> treeInstancesGoingTerrain = ReGenerateStones();
        List<int> treeInstancesFromTerrain = GenerateStones(stonePosition);
        if (treeInstancesGoingTerrain.Count > 0 || treeInstancesFromTerrain.Count > 0){
            //print("--всего камней, которые надо оживить " + treeInstancesFromTerrain.Count);
            ListsStorage.EditTerrainTreesList("stone", treeInstancesFromTerrain, treeInstancesGoingTerrain);
            ListsStorage.ReWriteTreeIntoTerrainData();
        }
    }
    List<int> ReGenerateStones()
    {
        List<int> treeInstancesGoingTerrain = new List<int>();
		if (alivingTerrainObjects.Count > 0){
			
			for (int i = alivingTerrainObjects.Count-1; i >= 0; i--) // перевод объектов, которые находятся далеко от игрока в террейн (1 этап)
			{
				GameObject treeGO = alivingTerrainObjects[i];
				float distance = Vector3.Distance(treeGO.transform.position, myTransform.position); //Vector3.Scale(tree.transform.position, terrain.size) + Terrain.activeTerrain.transform.position
				if (distance > (BlastRange + 1))
				{	
					treeInstancesGoingTerrain.Add(alivingTerrainObjectsIndexes[i]);
					Destroy(alivingTerrainObjects[i]);
					alivingTerrainObjects.RemoveAt(i);
                    alivingTerrainObjectsIndexes.RemoveAt(i);
                    
					//alivingInstances.RemoveAt(i);
				}
			}
		}
        return treeInstancesGoingTerrain;
    }

    List<int> GenerateStones(List<Vector3> partStonePosition)
    {
        List<int> treeInstancesFromTerrain = new List<int>();
        //List<int> delitVector = new List<int>();
        if (partStonePosition.Count > 0)
		{
            //print("--на сцене есть " + stonePosition.Count + " камней" );
			//funCounter++;
           TerrainData terrainDat = terain.terrainData;
			int counter = 0;
            int prefixIndex = 0;
			foreach (Vector3 stone in partStonePosition) {

				float distance = Vector3.Distance(stone, myTransform.position);
				if (distance<BlastRange) 
				{
                    if (alivingTerrainObjectsIndexes.Contains(stoneIndexes[counter]))
                    {
                        counter++;
                        continue;
                    }
                     // ----!!!!----реализовать систему с добавлением объектов
                    TreeInstance tree = terrainDat.GetTreeInstance(stoneIndexes[counter] + prefixIndex);
					GameObject prefabTree = Instantiate(treePrototypesList[tree.prototypeIndex].prefab,
                                                        Vector3.Scale(tree.position, terrainDat.size) + terain.transform.position,
                                                        Quaternion.identity);
					alivingTerrainObjects.Add(prefabTree);
                    treeInstancesFromTerrain.Add(stoneIndexes[counter]);
                    alivingTerrainObjectsIndexes.Add(stoneIndexes[counter]);
                    //stonePosition[]
				}
                counter++;
			}
		}
        return treeInstancesFromTerrain;
    }
}
/*
private static List<List<Dictionary<int,TreeInstance>>> alivingObjOnGroups = new List<List<TreeInstance>>(){
                new List<Dictionary<int,TreeInstance>>(){new Dictionary<int,TreeInstance>()}, 
                new List<Dictionary<int,TreeInstance>>(){new Dictionary<int,TreeInstance>()}, 
                new List<Dictionary<int,TreeInstance>>(){new Dictionary<int,TreeInstance>()},//список по группам деревьев перемещённых с терейна по группам
                new List<Dictionary<int,TreeInstance>>(){new Dictionary<int,TreeInstance>()}}; */
