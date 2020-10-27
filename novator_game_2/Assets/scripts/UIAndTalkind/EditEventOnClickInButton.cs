using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditEventOnClickInButton : MonoBehaviour
{
    private bool OnClickPer;
    private bool isRead;
    private Sprite mySprite;
    private Image imgScrForEditSprite;

    void Awake()
    {
        imgScrForEditSprite = gameObject.GetComponent<Image>();
        OnClickPer = false;
        isRead = false;
    }

    public void myOnClick()
    {
        OnClickPer = true;
        //print("______________________________click");
    }

    void FixUpdate() // FixedUpdate
    {
        if (OnClickPer)
        {
            if (isRead) 
            {
                OnClickPer = false;
                isRead = false;
            }
        }
    }

    public bool GetOnClickValue()
    {
        if (OnClickPer)
        {
            isRead = true;
            OnClickPer = false;
            return true;
        }
        return OnClickPer;
    }
    public void SetSprite(Sprite newSpr)
    {
        imgScrForEditSprite.sprite = newSpr;
    }
}
