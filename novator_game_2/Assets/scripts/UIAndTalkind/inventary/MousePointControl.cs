using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointControl : MonoBehaviour
{
    private bool ifMouseOnInventaty = false;
    private bool mouseDownGoingInventary = false; //если мышь зашла с уже нажатой клавишей
    private bool mouseDownOutInventary = false; //если мышь зашла с без нажатой клавиши, а вышла с нажатой
    private Vector2 coordUpMouse;
    private bool isGiveCoordUpMouse = false;
    private AllCellsControl allCellsControlScr;
    private movementObjectsControl movementObjectsControlScr;
    private MainMousePosForWindowControl mousePosScr;
    private Rect inventaryRect;

    void Awake()
    {
        mousePosScr = transform.parent.gameObject.GetComponent<MainMousePosForWindowControl>();
        allCellsControlScr = transform.Find("Panel").gameObject.GetComponent<AllCellsControl>();
        movementObjectsControlScr = transform.parent.gameObject.GetComponent<movementObjectsControl>();
        inventaryRect = allCellsControlScr.GetMyRect();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGiveCoordUpMouse){
            
            if (mouseDownGoingInventary)
            {
                //print("---------------------");
                if (Input.GetAxis("Fire1") == 0)//если мышь зашла с уже нажатой клавишей и клавишу отпустили
                {
                   // print("%%%%%%%%%%%%%%%");
                    coordUpMouse = mousePosScr.GetMousePosVector2();
                    
                    if (movementObjectsControlScr.IsMovementObject())
                    {
                        
                        Sprite sprite = movementObjectsControlScr.GetObjSprite();
                        GameObject obj = movementObjectsControlScr.GetMovementingObj();
                        allCellsControlScr.GiveComponentIntoCell(coordUpMouse, sprite, obj);
                        mouseDownGoingInventary = false;
                        //isGiveCoordUpMouse = true;
                    }

                }
            }
        }
        float mousX = mousePosScr.GetMousePosX() ;
        float mousY = -mousePosScr.GetMousePosY(1) ;
        if (allCellsControlScr.GetCoordX() < mousX &&  allCellsControlScr.GetCoordX()+ allCellsControlScr.GetSizeX() > mousX )
        {
            if (allCellsControlScr.GetCoordY() < mousY &&  allCellsControlScr.GetCoordY() + allCellsControlScr.GetSizeY() > mousY )
            {
                ifMouseOnInventaty = true;
            }
            else{
                ifMouseOnInventaty = false;
            }
        }
        else{
            ifMouseOnInventaty = false;
        }
        //print("-----ifMouseOnInventaty " + ifMouseOnInventaty );  // + " " + mousX + "" + mousY
    }
    public void MouseWentInventary()
    {
        if (Input.GetAxis("Fire1") != 0)
        {
            mouseDownGoingInventary = true;
            mouseDownOutInventary = false; 
            //print("^^^^^^^^^^^^^^^^^^^^");
        }
        //ifMouseOnInventaty = true;
        //print("------^^^^^^^^");
        

    }
    public void MouseOutInventary()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (mouseDownGoingInventary)
            {
                mouseDownGoingInventary = false;
            }
            else
            {
                mouseDownGoingInventary = false;
                //mouseDownOutInventary = true;
            }
        }
        //ifMouseOnInventaty = false;
        //print("*************************");
    }
    void OnDisable()
    {
        ifMouseOnInventaty = false;
        mouseDownGoingInventary = false;
        mouseDownOutInventary = false;
        isGiveCoordUpMouse = false;
    }
    public bool IsMouseOnInventaty()
    {
        return ifMouseOnInventaty;
    }

}
