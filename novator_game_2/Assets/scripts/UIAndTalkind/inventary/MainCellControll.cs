using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCellControll : MonoBehaviour
{ 
    private RectTransform m_RectTransform;
    private Rect  m_rect;
    private Sprite mySprite;
    private GameObject spriteObj;
    private Sprite noneSprite;
    private Image imgIntoCell;
    private MainMousePosForWindowControl mousePosScr;
    private Vector2 newSize;
    private float leftX;
    private float upY;
    private int indexX;
    private int indexY;
    private int bigIndex;
    private AllCellsControl allCellsContrCsr;
    private MainCellControll selfCellScr;


    void Awake()
    {
        selfCellScr = gameObject.GetComponent<MainCellControll>();
        imgIntoCell = transform.Find("sprite").gameObject.GetComponent<Image>();
        m_RectTransform = gameObject.GetComponent<RectTransform>();
        m_rect = m_RectTransform.rect;
        noneSprite = imgIntoCell.sprite;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteObj != null){
            if (spriteObj.activeInHierarchy)
            {
                spriteObj.SetActive(false);
            }
        }
    }

    public void SetParametrs(Vector2 newSize1, float leftX1, float upY1, int indexX1, int indexY1,
                            MainMousePosForWindowControl mousePosScr1,
                            AllCellsControl allCellsContrCsr1)
    {
        newSize = newSize1;
        leftX = leftX1;
        upY = upY1;
        indexX = indexX1;
        indexY = indexY1;
        mousePosScr = mousePosScr1;
        allCellsContrCsr = allCellsContrCsr1;
        bigIndex = (indexY1 ) * 3 + indexX1;
    }
    private void SetSprite()
    {
        imgIntoCell.sprite = mySprite;
    }
    public void GiveSprite(GameObject obj, List<int> cellInd){this.GiveSprite(noneSprite, obj, cellInd, true);}
    public void GiveSprite(Sprite sprite, GameObject obj, List<int> cellInd){this.GiveSprite(sprite, obj, cellInd, false);}
    public void GiveSprite(Sprite sprite, GameObject obj, List<int> cellInd, bool isobj) // если последний флаг - true - то надо создавать объект
    {
        if (spriteObj == null){ // если ячейка пустая
            if (isobj)
            {
                spriteObj = Instantiate(obj);
                var scr = spriteObj.GetComponent<parentThingsController>();
                mySprite = scr.GetSprite();
                scr.ObjIntoInventary(gameObject, selfCellScr);
                // создаем объект
            }
            else
            {
                spriteObj = obj;
                spriteObj.SetActive(true);
                var scr = spriteObj.GetComponent<parentThingsController>();
                mySprite = sprite;
                scr.ObjIntoInventary(gameObject, selfCellScr);
            }
            
            spriteObj.SetActive(false);
            
            SetSprite(); 
        }
        else // если в ячейке уже что-то лежит
        {
            if (cellInd[0] > -1 && cellInd[1] > -1) // если апрайт был перемещён из другой ячейки
            {
                spriteObj.SetActive(true);
                spriteObj.GetComponent<parentThingsController>().ObjIntoInventary(gameObject, selfCellScr);
                spriteObj.SetActive(false);
                allCellsContrCsr.swapSprite(mySprite, spriteObj, cellInd);
                
                mySprite = sprite;
                spriteObj = obj;
                spriteObj.SetActive(true);
                spriteObj.GetComponent<parentThingsController>().ObjIntoInventary(gameObject, selfCellScr);
                spriteObj.SetActive(false);
                SetSprite(); 
            }
            else // если спрайт был перетащен из игры
            {
                //print("-@@@@@-=-=-=-=-=-=-=-=--------------------");
                allCellsContrCsr.TryingWrongMovement(sprite, obj);
            }
        }

    }

    public void DragMouseFun()
    {
        if (spriteObj != null)
        {
            allCellsContrCsr.DragMouseForCell(mySprite, spriteObj, new List<int>(){indexX, indexY});
            ClearCell();
        }
    }
    public void ClearCell()
    {
        imgIntoCell.sprite = noneSprite;
        spriteObj = null;
    }
    public void GiveAwayObj()
    {
        print("_*_*_*_*_*_*_");
       ClearCell(); 
    }
    public bool isSprite()
    {
        if (spriteObj != null)
        {
            return true;
        }
        return false;
    }
}
