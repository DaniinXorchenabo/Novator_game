using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIControl : MonoBehaviour
{
    private EditEventOnClickInButton openInventaryButton;
    private bool clickButtonInv = false;
    private bool isInventary = false;
    void Awake()
    {
        openInventaryButton = transform.Find("goToInventory").gameObject.GetComponent<EditEventOnClickInButton>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clickButtonInv = openInventaryButton.GetOnClickValue();
        if (clickButtonInv)
        {
            if (isInventary)
            {
                isInventary = false;
            } 
            else
            {
                isInventary = true;
            }
        }

    }
    public bool OpenInventary()
    {
        return isInventary;
    }
    //public bool CloseInventary(){}

}
