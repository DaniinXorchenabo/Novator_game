/*
	Script to blow up terrain engine trees
	(C)2009 by Tom Vogt <tom@lemuria.org>
	
	Released under the Creative Commons "Share Alike" license, see http://creativecommons.org/licenses/by-sa/3.0/

	DeadReplace must contain a collider and a rigidbody, or it'll fall through the terrain. :-)

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeExplosion : MonoBehaviour 
 { /* 

	public float BlastRange = 30.0f;
	//public float BlastForce = 30000.0f;
	//public GameObject DeadReplace;
	//public GameObject Explosion;
	private List<GameObject> alivingTerrainObjects;
	private List<TreeInstance> alivingInstances;
	private TreePrototype[] treePrototypes;
	
	void Awake()
	{

		alivingTerrainObjects = new List<GameObject>();
		alivingInstances = new List<TreeInstance>();
	}
	void Start()
	{
		TerrainData terrain = Terrain.activeTerrain.terrainData;
		treePrototypes = Terrain.activeTerrain.terrainData.treePrototypes;
	}
	void Explode() {
		//Instantiate(Explosion, transform.position, Quaternion.identity);
		TerrainData terrain = Terrain.activeTerrain.terrainData;
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

		foreach (TreeInstance tree in terrain.treeInstances) {
			float distance = Vector3.Distance(Vector3.Scale(tree.position, terrain.size) + Terrain.activeTerrain.transform.position, transform.position);
			if (distance<BlastRange) {
				// the tree is in range - destroy it
				//print("-==------------" + treePrototypes[tree.prototypeIndex].prefab + "   " + tree.prototypeIndex);
				GameObject prefabTree = Instantiate(treePrototypes[tree.prototypeIndex].prefab, Vector3.Scale(tree.position, terrain.size) + Terrain.activeTerrain.transform.position, Quaternion.identity);
				Transform prefabTreeTransform = prefabTree.transform;
				if (prefabTree.name.Contains("tree"))
				{
					prefabTreeTransform.localScale = new Vector3 (prefabTreeTransform.localScale.x * tree.widthScale, prefabTreeTransform.localScale.y * tree.heightScale, prefabTreeTransform.localScale.z * tree.widthScale);
					//prefabTreeTransform.Rotate(0, tree.rotation, 0,  Space.Self);
				}
				alivingTerrainObjects.Add(prefabTree);
				alivingInstances.Add(tree);
				//print("------");
				//dead.GetComponent<Rigidbody>().maxAngularVelocity = 1;
				//dead.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, transform.position, BlastRange*5, 0.0f);
			} else {
				// tree is out of range - keep it
				instances.Add(tree);
				
			}
		}
		instances.AddRange(returnInstances);
		terrain.treeInstances = instances.ToArray();//(TreeInstance[])instances.ToArray(typeof(TreeInstance));

	}

	void Update() {
		//if (Input.GetButtonDown("Fire1")) {
		Explode();
		//}
	}
	*/
}

