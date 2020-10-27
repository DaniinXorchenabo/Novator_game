using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatMakedThings : MonoBehaviour
{
    private player_control playerControl;
    private GameObject GobAndWoulfObj;
    private bool isThinksSpeedBoorts = false;
    private bool isGoblin_potion = false;
    void Awake()
    {
        GobAndWoulfObj = transform.Find("Orc_Wolfrider").gameObject;
        
        playerControl = gameObject.GetComponent<player_control>();
        GobAndWoulfObj.SetActive(false);
    }
    public void AddElementIntoInv(string typeEl)
    {
        if (typeEl == "thinksSpeedBoorts")
        {
            if (!isThinksSpeedBoorts)
            {
                playerControl.speed += 2;
            }
            isThinksSpeedBoorts = true;
        }
        if (typeEl == "Goblin_potion")
        {
            if (!isGoblin_potion)
            {
                GobAndWoulfObj.SetActive(true);
            }
            isGoblin_potion = true;
        }
    }
    public void RemuveElementIntoInv(string typeEl)
    {
        if (typeEl == "thinksSpeedBoorts")
        {
            if (isThinksSpeedBoorts)
            {
                playerControl.speed -= 2;
            }
            isThinksSpeedBoorts = false;
            }
        if (typeEl == "Goblin_potion")
        {
            if (!isGoblin_potion)
            {
                GobAndWoulfObj.SetActive(false);
            }
            isGoblin_potion = false;
        }
    }

}
