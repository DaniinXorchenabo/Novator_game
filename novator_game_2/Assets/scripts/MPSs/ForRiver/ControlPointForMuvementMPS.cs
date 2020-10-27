using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPointForMuvementMPS : MonoBehaviour
{
    protected PrefabsStorageController prefabsStorageScript;
    void Awake()
    {
        prefabsStorageScript = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>();
        Component[] tr = gameObject.GetComponentsInChildren(typeof(Transform), false);
        List<Vector3> poss = new List<Vector3>();

        foreach (Transform tran in tr)
        {
            poss.Add(tran.position);
        }
        
        prefabsStorageScript.SetOutRivPoint(poss);
        print("------" + poss.Count);
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
