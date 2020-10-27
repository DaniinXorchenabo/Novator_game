using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementObjectsControl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject movingObjSprite;
    private MovementSpriteWithMouse movingObjSpriteScr;
    private GameObject ObjectWhichMove;
    private movementObjectsControl selfScr;
    private MainMousePosForWindowControl mousePos;
    private bool isObjectWhichMove = false;
    private Sprite moveObjSprite;
    private bool isObjInventary = false;
    private Camera cam;
    private AllCellsControl allCellsControl;
    private ObjectInfo objInfo;
    void Awake()
    {
        mousePos = gameObject.GetComponent<MainMousePosForWindowControl>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        selfScr = gameObject.GetComponent<movementObjectsControl>();
        movingObjSprite = transform.Find("movingSpritePrefab").gameObject;
        movingObjSpriteScr = movingObjSprite.GetComponent<MovementSpriteWithMouse>();
        allCellsControl = transform.Find("MainInventary/Panel").gameObject.GetComponent<AllCellsControl>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void howObjectMovement(GameObject movementingObj, Sprite objSprite) // если объект появился из клеточки и остальные случаи
    {
        moveObjSprite = objSprite;
        movingObjSprite.SetActive(true);
        movingObjSpriteScr.EditMovingSprite(objSprite);
        ObjectWhichMove = movementingObj;
        isObjectWhichMove = true;
    }
    public void howObjectMovement(GameObject movementingObj, Sprite objSprite, ObjectInfo objInfo1)// если объект взяли с земли
    {
        objInfo = objInfo1;
        this.howObjectMovement(movementingObj, objSprite);
    }
    
    public void TryingWrongMovementReturningPlaseObject(GameObject movementingObj, Sprite objSprite)
    {
        moveObjSprite = objSprite;
        ObjectWhichMove = movementingObj;
        isObjInventary = false;
        returningPlaseObject();
    }

    public void returningPlaseObject(){this.returningPlaseObject(false);}
    public void returningPlaseObject(bool movement)
    {
 
        isObjectWhichMove = false;
        if (!isObjInventary)
        {
            //print("---!!!!!!!!!!!");
            ObjectWhichMove.SetActive(true);
            allCellsControl.SetIndexesMatrLastCell(new List<int>(){-1, -1});
            if(movement)
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(new Vector3(mousePos.GetMousePosX(), mousePos.GetMousePosY(), 0));
                if (Physics.Raycast(ray, out hit, 20)) 
                {
                    Vector3 targPos = hit.point; 
                    ObjectWhichMove.transform.position = targPos;
                    //print("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                }
                else
                {
                    ObjectWhichMove.transform.position = ray.GetPoint(12);
                }
            }
        }
    }
    public bool IsMovementObject()
    {
        return isObjectWhichMove;
    }
    public Sprite GetObjSprite()
    {
        return moveObjSprite;
    }
    public GameObject GetMovementingObj()
    {
        return ObjectWhichMove;
    }
    public void SetIsObjInventary(bool isObjInv)
    {
        isObjInventary = isObjInv;
    }
}
