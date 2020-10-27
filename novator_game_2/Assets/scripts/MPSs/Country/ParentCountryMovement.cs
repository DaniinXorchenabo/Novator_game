using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCountryMovement : ParentALLMPSMovement
{
    //[SerializeField]
    //NavMeshAgent agent;

    [SerializeField]
    public Transform home;

    [SerializeField]
    public Transform work;

    //private Transform target;
    protected void ParentAwake()
    {
        AllParentAwake();
        target = home;
        agent.SetDestination(target.position);
    }
    void Start()
    {

    }
    protected void ParentUpdate()
    {
        AllParentUpdate();
        if (isGoWay)
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
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            agent.SetDestination(target.position);
        }
    }
}
