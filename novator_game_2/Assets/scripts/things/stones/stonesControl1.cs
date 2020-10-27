using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonesControl1 : ParentAllStonesControl
{
    
    [SerializeField]
    protected string myType = "smallStone0";
    protected string myGroup = "small_stone";
    //private stonesControl1 myScr;
    //private BowForthingsParametrs BowScr;
    //private ListArray forMeScr;
    
    void Awake()
    {
        //myScr = gameObject.GetComponent<stonesControl1>();
        //forMeScr.
        //BowScr = gameObject.GetComponent<BowForthingsParametrs>();
        //BowScr.SetSelfScr()
        ParentAwake(myClass, myGroup, myType, objSprite);

        childrenAwake();
    }
    protected void childrenAwake()
    {
        //objectInfo.SetAllParametrs(myClass, myGroup, myType);
        //objectInfo = new ObjectInfo(myClass, myGroup, myType);
        //print("----=--%%%%%%%%%");
    }
    public ObjectInfo GetObjInfo()
    {
        return objectInfo;
    }
    //public void ObjIntoInventary(GameObject cell, MainCellControll selfCell)
    //{
   //     ParentObjIntoInventary( cell,  selfCell, objectInfo);
    //}
}
