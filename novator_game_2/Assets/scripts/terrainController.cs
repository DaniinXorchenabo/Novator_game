using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainController : MonoBehaviour
{
    void Awake()
    {
        GameObject terrainn = transform.Find("Terrain").gameObject;
        
        //GameObject newTerrain = Instantiate(terrainn, terrainn.transform.position, Quaternion.identity);
        //terrainn.SetActive(false);
        GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>().newTerain = terrainn;
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
