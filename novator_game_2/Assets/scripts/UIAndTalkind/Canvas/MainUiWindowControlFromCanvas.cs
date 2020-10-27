using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUiWindowControlFromCanvas : MonoBehaviour
{
    private GameObject mainUIWindow;
    private MainUIControl mainUIWindowScr;
    private inventaryObjControl controlInventaryFromCanvasScr;

    void Awake ()
    {
        mainUIWindow = transform.Find("MainUIWindow").gameObject;
        mainUIWindowScr = mainUIWindow.GetComponent<MainUIControl>();
        controlInventaryFromCanvasScr = gameObject.GetComponent<inventaryObjControl>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainUIWindow.activeInHierarchy)
        {
            if (mainUIWindowScr.OpenInventary())
            {
                if (!controlInventaryFromCanvasScr.IsActiveInventary())
                {
                    controlInventaryFromCanvasScr.OpenInventary();
                }
            }
            else
            {
                if (controlInventaryFromCanvasScr.IsActiveInventary())
                {
                    controlInventaryFromCanvasScr.CloseInventary();
                }
            }
        }
    }
}
