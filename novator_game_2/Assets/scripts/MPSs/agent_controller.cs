using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent_controller : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    public Transform home;

    [SerializeField]
    public Transform work;

    private Transform target;

    void Start()
    {
        target = home;
        agent.SetDestination(target.position);
    }
    void Update()
    {
        if ((transform.position - target.position).magnitude < 3)
        {
            if (target == home){
                target = work;
            } else {
                target = home;
            }
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerEnter(Collider other) //вошёл
    {
        if (other.tag == "Player")
        {

        }
    }
    private void OnTriggerExit(Collider other) //вошёл
    {
        if (other.tag == "Player")
        {
            
        }
    }

}
