using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class grendFatherControl : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    public Transform home;

    [SerializeField]
    public Transform work;

    private Transform target;
    private Animator anim;
    private float speedd;
    void Start()
    {
        speedd = 0;
        target = home;
        agent.SetDestination(target.position);
        speedd = 1;
        anim = GetComponent<Animator>();
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
            speedd = 1;
            //anim.SetFloat("speeed", speedd);
        }
    }
    void FixedUpdate()
    {
        anim.SetFloat("speeed", speedd);
    }
}
