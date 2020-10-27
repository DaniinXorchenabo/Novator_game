using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParentALLMPSMovement : MonoBehaviour
{
    //[SerializeField]
    protected NavMeshAgent agent;

    
    protected static Transform player;
    protected Transform target;
    protected Animator anim;
    protected float speedd = 0;
    protected float editState = 0;
    protected static PrefabsStorageController prefabsStorageScript;
    protected bool isGoWay = true; //можно идти
    protected Vector3 targetPos;

    protected void AllParentAwake ()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
            prefabsStorageScript = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>();
        }
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.updateUpAxis = true;
        print("------*&&&&&");
    }

    protected void AllParentUpdate()
    {

    }

    protected void AllParentFixUpdate()
    {
        //AnimUpdate();
    }
    protected void OnTriggerEnter(Collider other) //вошёл
    {
        if (other.tag == "Player")
        {   
            targetPos = transform.position;
            isGoWay = false;
            agent.ResetPath();
            print("0-0-0-0-0-0-0-0-0-0");
            
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isGoWay = true;
        }
    }
}
