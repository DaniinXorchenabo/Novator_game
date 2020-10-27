using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEventController : MonoBehaviour
{
    private GameObject MainInventaryWindow;
    private PanelInventaryMainController MainInventaryWindowScr;
    
    void Aweke()
    {
        MainInventaryWindow = transform.Find("MainInventary").gameObject;
        MainInventaryWindowScr = MainInventaryWindow.GetComponent<PanelInventaryMainController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mouseDropEvent()
    {

    }
}
