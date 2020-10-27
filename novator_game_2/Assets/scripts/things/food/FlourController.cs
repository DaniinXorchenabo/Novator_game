using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourController : ParentFoodScript
{
    [SerializeField]
    protected string myType = "food_flour1";
    protected string myGroup = "Flour";

    void Awake()
    {
        ParentAwake(myClass, myGroup, myType, objSprite);
    }

    public ObjectInfo GetObjInfo()
    {
        return objectInfo;
    }
}
