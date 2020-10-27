using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForRiverMPSParentControl : ParentALLMPSMovement
{
    protected static List<Vector3> goblinTargetPoints = new List<Vector3> ();
    protected List<Vector3> targetPoints = new List<Vector3> ();
    protected int indexPoint = 0;
    int counterForTime = 0;
    bool makeWay = false;
    int tryingItIsMetod = 0;

    protected void ParentAwake()
    {
        AllParentAwake();
       
    }
    protected void ParentFixedUpdate()
    {
        AllParentFixUpdate();
        //SimpleControlPosition();
        ControlPosition();
        print("-------------------WAY Status " + agent.hasPath);

    }
    protected void ParentUpdate()
    {
        AllParentUpdate();
        //anim.SetFloat("speed", speedd);
        
        if (agent.hasPath)
        {
            anim.SetFloat("speed", 1.0f);
        }
        else
        {
            anim.SetFloat("speed", 0.1f);
        }
        /**/
    }

    void ChangeIndexControl(int plus1)
    {
        indexPoint += plus1;
        if(indexPoint >= targetPoints.Count-1)
        {
            indexPoint = 0;
            speedd = 1;
        }
    }

    protected void SetPointsList(List<Vector3> tP)
    {
        targetPoints = tP;
    }
    void SimpleControlPosition()
    {
        if ((transform.position - targetPos).magnitude < 3)
        {
            ChangeIndexControl(1);
            targetPos = targetPoints[indexPoint];
            agent.destination = targetPos;
        }
    }
    void ControlPosition()
    {
        if (makeWay) //если карта считается
        {
            counterForTime += 1;
            if (counterForTime > 10)
            {
                counterForTime = 0;
                makeWay = false;
            }
        }
        else
        {
            if (!agent.hasPath & isGoWay) // если можно идти но путя еще нет
            {
                if (tryingItIsMetod < 1 | tryingItIsMetod == 3)
                {
                    ChangeIndexControl(1);
                    agent.destination = targetPoints[indexPoint];
                    makeWay = true;
                    tryingItIsMetod = 1;
                    return;
                }
            }
            else if (agent.hasPath & isGoWay)// если можно идти и мы идём
            {
                tryingItIsMetod = 0;
                return;
            } 
            if (agent.isPathStale & isGoWay) //если navMwsh претерпел изменения или путь не действителен
            {
                if (tryingItIsMetod < 2)
                {
                    agent.destination = targetPoints[indexPoint];
                    makeWay = true;
                    tryingItIsMetod = 2;
                    return;
                }
            }
            if (tryingItIsMetod < 3 & isGoWay)
            {
                agent.SetDestination(targetPoints[indexPoint]);
                makeWay = true;
                tryingItIsMetod = 3;
                return;
            }  
             
        }


    }

}
