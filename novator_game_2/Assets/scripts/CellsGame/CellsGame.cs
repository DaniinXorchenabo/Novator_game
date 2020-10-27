using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsGame : MonoBehaviour
{
    private GameObject finishing;
    private GameObject Starting;
    private GameObject finalWoulf;
    private GameObject world;
    private GameObject country;
    private GameObject forRiver;
    private bool isFirst = true;
    private bool isFirst2 = true;
    void Awake()
    {
        world = GameObject.FindWithTag("World");
        country = world.transform.Find("country").gameObject;
        forRiver = world.transform.Find("outCountry").gameObject;
        finalWoulf = GameObject.FindWithTag("Player").transform.Find("Orc_Wolfrider").gameObject;
        finishing = transform.Find("Finishing").gameObject;
        finishing.SetActive(false);
        Starting = transform.Find("Starting").gameObject;
        //Starting.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        country.SetActive(false);
        forRiver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (finalWoulf.activeInHierarchy & isFirst)
        {
            country.SetActive(false);
            forRiver.SetActive(false);
            finishing.SetActive(true);
            if (finishing.activeInHierarchy & isFirst)
            {
                isFirst = false;
                country.SetActive(true);
                forRiver.SetActive(true);
            }
        }
        if (!Starting.activeInHierarchy & isFirst2)
        {
            isFirst2 = false;
            country.SetActive(true);
            forRiver.SetActive(true);
        }
       
    }

}
