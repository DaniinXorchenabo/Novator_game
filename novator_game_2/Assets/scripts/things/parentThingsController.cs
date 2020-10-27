using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentThingsController : MonoBehaviour
{
    protected movementObjectsControl mainCanvasMovementScr;
    public Sprite objSprite;
    protected inventaryObjControl invObjContrScr;
    protected ObjectInfo objectInfo;
    protected GameObject player;
    protected PlayerInventaryControl playerInvScr;
    protected bool isMeAddToInventary = false;
    protected PrefabsStorageController prefabsStorageController;
    // Start is called before the first frame update
    protected void ParentAwake(string howClass1, string howGroup1, string howType1, Sprite objSprite1)
    {
        objSprite = objSprite1;
        if (objSprite == null)
        {
            prefabsStorageController = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>();
            objSprite = prefabsStorageController.NullSpr;
        }
        objectInfo = new ObjectInfo( howClass1,  howGroup1,  howType1);
        player = GameObject.FindWithTag("Player");
        playerInvScr = player.GetComponent<PlayerInventaryControl>();
        mainCanvasMovementScr = GameObject.FindWithTag("UIMainCanvas").GetComponent<movementObjectsControl>();
        invObjContrScr = GameObject.FindWithTag("UIMainCanvas").GetComponent<inventaryObjControl>();
        //childrenAwake();

    }
    void rAwake()
    {
        
        //ParentAwake();
    }
    protected void childrenAwake()
    {
        //print("*****________");
    }
    public Sprite GetSprite()
    {
        return objSprite;
    }
    /* 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        print("you click me!");
    }
    public void OnMouseUpAsButton()
    {
        print("you want give me");
    }
    */
    public void OnMouseDrag()
    {
        //print("_)_)_)_)_)_)_)_)_)_");
        if (invObjContrScr.IsMouseForInventar())
        {
            //print("drag button keeping me");
            mainCanvasMovementScr.howObjectMovement(gameObject, objSprite, objectInfo);
            gameObject.SetActive(false);
        }
    }
    public void ObjIntoInventary(GameObject cell, MainCellControll selfCell)
    {
        isMeAddToInventary = true;
       
        playerInvScr.AddElementIntoList(objectInfo, cell, selfCell);
        //print("&*&*&*&*&*&_____   " + objectInfo.GetType() + "---");
        //print(objectInfo.GetType());
    }
    void OnEnable()
    {
        if (isMeAddToInventary)
        {
            if (objectInfo != null){
                playerInvScr.DeliteObjectFromInventary(objectInfo.GetType());
            }
            isMeAddToInventary = false;
        }
    }
}

public class ObjectInfo
{
    private string howClass;
    private string howGroup;
    private string howType;

    public ObjectInfo(string howClass1, string howGroup1, string howType1){this.SetAllParametrs(howClass1, howGroup1, howType1);}

    public void SetAllParametrs(string howClass1, string howGroup1, string howType1)
    {
        SetClass(howClass1);
        SetGroup(howGroup1);
        SetType(howType1);
    }
    public void SetClass(string howClass1)
    {
        howClass = howClass1;
    }
    public void SetGroup(string howGroup1)
    {
        howGroup = howGroup1;
    }
    public void SetType(string howType1)
    {
        howType = howType1;
    }
    public string GetClass()
    {
        return howClass;
    }
    public string GetGroup()
    {
        return howGroup;
    }
    public string GetType()
    {
        return howType;
    }
}
