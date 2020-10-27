using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools1Scr : ParentToolsScr
{
    [SerializeField]
    protected string myType = "tools_hammer1";
    protected string myGroup = "Hammer";

    void Awake()
    {
        ParentAwake(myClass, myGroup, myType, objSprite);
    }

    public ObjectInfo GetObjInfo()
    {
        return objectInfo;
    }
}
