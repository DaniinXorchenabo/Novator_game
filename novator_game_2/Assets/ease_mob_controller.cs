using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ease_mob_controller : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = true;
        _agent.ActivateCurrentOffMeshLink(true);
        if (_agent.isActiveAndEnabled)
        {
            print("------------");
        }
        //transform.localScale(new  Vector3(1,1,2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            //player = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //_agent.isStopped = false;
        
        _agent.SetDestination(player.transform.position);
    }

    private void OnTriggerExit(Collider other){
        //_agent.isStopped = true;
        //player = null;
    }
}
