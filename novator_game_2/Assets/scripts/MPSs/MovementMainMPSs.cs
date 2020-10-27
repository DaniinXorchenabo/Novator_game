using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMainMPSs : ParentALLMPSMovement
{
    [SerializeField]
    public Transform home;

    [SerializeField]
    public Transform work;

    void Awake()
    {
        AllParentAwake();
        if (agent != null & home != null & work != null )
        {
            speedd = 0;
            target = home;
            agent.SetDestination(target.position);
            //agent.destination = target.position; 
            speedd = 1;
                
        }
    }
    void Update()
    {
        if (agent != null & home != null & work != null)
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
        AnimUpdate();
    }
    void FixedUpdate()
    {
        AllParentFixUpdate();

    }
        void AnimUpdate()
    {
        if (editState == 1)
        {
            editState = 0;
            anim.SetFloat("editState", editState);
        }
        
        if (agent.hasPath)
        {
            if(speedd == 0)
            {
                playWalikAnimation();
            }
        }
        else
        {
            if(speedd == 1)
            {
                playWalikAnimation();
            }
        }
    }
    protected void playWalikAnimation()
    {
        if (editState == 1)
        {
            editState = 0;
            anim.SetFloat("speed", speedd);
            anim.SetFloat("editState", editState);
        }
        else
        {
            editState = 1;
            anim.SetFloat("speed", speedd);
            anim.SetFloat("editState", editState);
        }
    }

}
