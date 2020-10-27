/*
	Script to blow up terrain engine trees
	(C)2009 by Tom Vogt <tom@lemuria.org>
	
	Released under the Creative Commons "Share Alike" license, see http://creativecommons.org/licenses/by-sa/3.0/

	DeadReplace must contain a collider and a rigidbody, or it'll fall through the terrain. :-)

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObjectAliveControl : MonoBehaviour {

	public float BlastRange = 30.0f;
	//public float BlastForce = 30000.0f;
	//public GameObject DeadReplace;
	//public GameObject Explosion;
	private List<GameObject> alivingTerrainObjects;
	private List<TreeInstance> alivingInstances;
	//private 
	private TreePrototype[] treePrototypes;
	private TerrainObjectsGetControl getTerrainObjScr;
	private PlayerTerrainSectorObjectControl GetTerrainSectorWithObjInfo;
	private Terrain terrain;
	public bool StartFinaly = false; 
	
	void Awake()
	{
		getTerrainObjScr = gameObject.GetComponent<TerrainObjectsGetControl>();
		GetTerrainSectorWithObjInfo = gameObject.GetComponent<PlayerTerrainSectorObjectControl>();
		alivingTerrainObjects = new List<GameObject>();
		alivingInstances = new List<TreeInstance>();
		//alivingInstancesGlobalIdexes = new List<int>();
		
	}

	void Start()
	{
		treePrototypes = getTerrainObjScr.treePrototypesList;
		terrain = getTerrainObjScr.terain;
		StartFinaly = true;
	}

	void Explode() {
		/* 
		TerrainData terrainDat = terrain.terrainData;
		TreeInstance[] instances = terrainDat.treeInstances;
		
		//Instantiate(Explosion, transform.position, Quaternion.identity);
		List<Vector3> anyStonesPosition = GetTerrainSectorWithObjInfo.getPlayerSectorWithStonesPositionList();
		List<int> anyStonesPositionIndexes = GetTerrainSectorWithObjInfo.getPlayerSectorWithStonesIndexesList();
		
		List<TreeInstance> instances = new List<TreeInstance>();
		List<TreeInstance> returnInstances = new List<TreeInstance>();
		if (alivingTerrainObjects.Count > 0){
			for (int i = alivingTerrainObjects.Count-1; i >= 0; i--) // перевод объектов, которые находятся далеко от игрока в террейн (1 этап)
			{
				GameObject tree = alivingTerrainObjects[i];
				float distance = Vector3.Distance(tree.transform.position, transform.position); //Vector3.Scale(tree.transform.position, terrain.size) + Terrain.activeTerrain.transform.position
				if (distance > (BlastRange + 1))
				{
					print("+++++++++++");
					returnInstances.Add(alivingInstances[i]);
					Destroy(alivingTerrainObjects[i]);
					alivingTerrainObjects.RemoveAt(i);
					alivingInstances.RemoveAt(i);
				}
			}
		}
		int counter = 0;
		foreach (Vector3 stone in anyStonesPosition) {
			float distance = Vector3.Distance(stone, transform.position);
			if (distance<BlastRange) {
				tree = terrainDat.GetTreeInstance(anyStonesPositionIndexes[counter]);
				GameObject prefabTree = Instantiate(treePrototypes[tree.prototypeIndex].prefab, Vector3.Scale(tree.position, terrainDat.size) + Terrain.activeTerrain.transform.position, Quaternion.identity);
				*//*if (prefabTree.name.Contains("tree"))
				{
					Transform prefabTreeTransform = prefabTree.transform;       //prefabTreeTransform.Rotate(0, tree.rotation, 0,  Space.Self);
					prefabTreeTransform.localScale = new Vector3 (prefabTreeTransform.localScale.x * tree.widthScale, prefabTreeTransform.localScale.y * tree.heightScale, prefabTreeTransform.localScale.z * tree.widthScale);	
				}*/
				/* 
				alivingTerrainObjects.Add(prefabTree);
				//alivingInstances.Add(tree);
			} else {
				instances.Add(tree);
			}
			counter++;
		}
		//instances.AddRange(returnInstances);
		terrainDat.treeInstances = instances;//.ToArray();//(TreeInstance[])instances.ToArray(typeof(TreeInstance));
*/
	}
	void Explode1() 
	{
		TerrainData terrainDat = terrain.terrainData;
		List<Vector3> anyStonesPosition = GetTerrainSectorWithObjInfo.getPlayerSectorWithStonesPositionList();
		List<int> anyStonesPositionIndexes = GetTerrainSectorWithObjInfo.getPlayerSectorWithStonesIndexesList();
		int prefix_index = getTerrainObjScr.getAddForIndexesList()[1];

		List<int> alivingInstancesGlobalIdexes = new List<int>();
		List<int> alivingInstancesLocalIdexes = new List<int>();
		List<TreeInstance> treeInstancesGoingTerrain = new List<TreeInstance>();
		int funCounter = 0;
		if (alivingTerrainObjects.Count > 0){
			
			for (int i = alivingTerrainObjects.Count-1; i >= 0; i--) // перевод объектов, которые находятся далеко от игрока в террейн (1 этап)
			{
				GameObject treeGO = alivingTerrainObjects[i];
				float distance = Vector3.Distance(treeGO.transform.position, transform.position); //Vector3.Scale(tree.transform.position, terrain.size) + Terrain.activeTerrain.transform.position
				if (distance > (BlastRange + 1))
				{	
					funCounter++;
					treeInstancesGoingTerrain.Add(alivingInstances[i]);
					Destroy(alivingTerrainObjects[i]);
					alivingTerrainObjects.RemoveAt(i);
					alivingInstances.RemoveAt(i);
				}
			}
		}

		if (anyStonesPosition.Count > 0)
		{
			funCounter++;
			int counter = 0;
			foreach (Vector3 stone in anyStonesPosition) {
				//print("---*******---stone pos1 " + stone);
				float distance = Vector3.Distance(stone, transform.position);
				//print("-------------distanse " + distance);
				if (distance<BlastRange) 
				{
					funCounter++;
					int indexx = anyStonesPositionIndexes[counter] + prefix_index;
					TreeInstance tree = terrainDat.GetTreeInstance(indexx);
					GameObject prefabTree = Instantiate(treePrototypes[tree.prototypeIndex].prefab, Vector3.Scale(tree.position, terrainDat.size) + Terrain.activeTerrain.transform.position, Quaternion.identity);
					alivingInstances.Add(tree);
					alivingInstancesGlobalIdexes.Add(indexx);
					alivingInstancesLocalIdexes.Add(counter);
					alivingTerrainObjects.Add(prefabTree);
					print("-indexx " + indexx);
				}
			}
		}
		if (funCounter > 0)
		{
			print("funCount");
			editCountStones(alivingInstancesGlobalIdexes, treeInstancesGoingTerrain, alivingInstancesLocalIdexes);
		}
	}

	void Update() {
		if (GetTerrainSectorWithObjInfo.StartFinaly)
		{
			if (getTerrainObjScr.StartFinaly)
			{
				Explode1();
			}
		}
	}
	void editCountStones(List<int> deliteList, List<TreeInstance> addList, List<int> alivingInstancesLocalIdexes)
	{
		GetTerrainSectorWithObjInfo.editSectorStones(deliteList, addList, alivingInstancesLocalIdexes);
	}
}

