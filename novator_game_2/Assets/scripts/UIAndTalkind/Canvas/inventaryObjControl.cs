using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventaryObjControl : MonoBehaviour
{
    private PanelInventaryMainController panelInventaryScr;
    private GameObject panelInventary;
    private bool isActiveInventary = false;
    private MainMousePosForWindowControl MousePos;
    private GameObject upInventarObj;
    private MousePointControl mousePointControl;
    void Awake()
    {
        upInventarObj = transform.Find("MainInventary").gameObject;
        mousePointControl = upInventarObj.GetComponent<MousePointControl>();
        MousePos = gameObject.GetComponent<MainMousePosForWindowControl>();
        panelInventary = transform.Find("MainInventary").gameObject;
        panelInventaryScr = panelInventary.GetComponent<PanelInventaryMainController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OpenInventary()
    {
        panelInventary.SetActive(true);
        isActiveInventary = true;
    }
    public void CloseInventary()
    {
        panelInventary.SetActive(false);
        isActiveInventary = false;
    }
    public bool IsActiveInventary()
    {
        return isActiveInventary;
    }
    public bool IsMouseForInventar()
    {
        //print("-----^^^^^^^_)____");
        if (upInventarObj.activeInHierarchy)
        {
            if (mousePointControl.IsMouseOnInventaty()) // если мышь на инвентаре
            {
                return false; // то брать нельзя
            }
        }
        return true; // иначе брать предмет можно
    }
}
