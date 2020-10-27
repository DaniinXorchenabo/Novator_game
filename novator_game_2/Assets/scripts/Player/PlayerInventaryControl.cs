using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventaryControl : MonoBehaviour
{
    private List<string> objClassListInInventar = new List<string>(); // {"", "", "", "", "", "", "", "", ""};
    private List<string> objGroupListInInventar = new List<string>(); // {"", "", "", "", "", "", "", "", ""};
    private List<string> objTypeListInInventar = new List<string>(); // {"", "", "", "", "", "", "", "", ""};
    private List<ObjectInfo> infoListInInventar = new List<ObjectInfo>();
    private List<GameObject> cellsObjList = new List<GameObject>();
    private List<MainCellControll> cellsScrList = new List<MainCellControll>();
    public Text printDebag;
    private AllCellsControl allCellsControl;
    private List<string> metaObjInventary = new List<string>();
    private WhatMakedThings whatMakedThings ;
    // Start is called before the first frame update
    void Awake()
    {
        whatMakedThings = gameObject.GetComponent<WhatMakedThings>();
        allCellsControl = GameObject.FindWithTag("UIMainCanvas").transform.Find("MainInventary/Panel").gameObject.GetComponent<AllCellsControl>();
    }

    // Update is called once per frame
    void Update()
    {
        string alltext = "";
        foreach (string cell in objTypeListInInventar)
        {
            alltext += cell;
        }
        //printDebag.text = alltext;
    }
    public void AddElementIntoList(ObjectInfo objectInfo, GameObject cell, MainCellControll cellScr)
    {
        infoListInInventar.Add(objectInfo);
        objClassListInInventar.Add(objectInfo.GetClass());
        objGroupListInInventar.Add(objectInfo.GetGroup());
        objTypeListInInventar.Add(objectInfo.GetType());
        cellsObjList.Add(cell);
        cellsScrList.Add(cellScr);
        whatMakedThings.AddElementIntoInv(objectInfo.GetType());
    }
    public void DeliteObjectFromInventary(string objType) // происходит при взятии объекта из инвентаря игроком
    {
        
        int index = objTypeListInInventar.IndexOf(objType);
        DeliteObjFromInvByIndex(index);
    }
    private void DeliteObjFromInvByIndex(int index)
    {
        whatMakedThings.RemuveElementIntoInv(objTypeListInInventar[index]);
        infoListInInventar.RemoveAt(index);
        objClassListInInventar.RemoveAt(index);
        objGroupListInInventar.RemoveAt(index);
        objTypeListInInventar.RemoveAt(index);
        cellsObjList.RemoveAt(index);
        cellsScrList.RemoveAt(index);
        
    }
    public void PlayerGiveObject(string value, string howType) // если какой-то персонаж отобрал предмет у игрока
    {
        if (howType == "$Type")
        {
            whatMakedThings.RemuveElementIntoInv(value);
            return;
        }
        int index = GetIndexElementIntoInv(value, howType);
        if (index > -1)
        {
            cellsScrList[index].GiveAwayObj();
            DeliteObjFromInvByIndex(index);
        }
    }
    public void PlayerGetObject(GameObject obj) // если какой-то персонаж отдал предмет  игроку
    {
        if (cellsObjList.Count < 9)
        {
            allCellsControl.FindBlankCell(obj);
        }
    }
    public void PlayerGetObject(string obj) // если какой-то персонаж отдал какую-то фразу  игроку
    {
        whatMakedThings.AddElementIntoInv(obj);
        metaObjInventary.Add(obj);
    }
    private int GetIndexElementIntoInv(string value, string howType)
    {
        int index = -1;
        if (howType == "Class")
        {
            index = objClassListInInventar.IndexOf(value);
        }
        else if (howType == "Group")
        {
            index = objGroupListInInventar.IndexOf(value);
        }
        else if (howType == "Type")
        {
            index = objTypeListInInventar.IndexOf(value);
        }
        if (howType == "$Type")
        {
            index = metaObjInventary.IndexOf(value);
        }
        return index;
    }
    public bool IsElementIntoInv(string value, string howType)
    {
        int index = GetIndexElementIntoInv(value, howType);
        if (index == -1)
        {
            return false;
        }
        return true;
    }
    

}
