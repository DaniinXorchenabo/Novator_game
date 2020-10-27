using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCellsControl : MonoBehaviour
{
    private RectTransform m_RectTransform;
    private float coordX;
    private float coordY;
    private Rect  m_rect;
    private List<List<MainCellControll>> cellScripts = new List<List<MainCellControll>>(){
                new List<MainCellControll>(),
                new List<MainCellControll>(),
                new List<MainCellControll>()};
    private Vector2 cellSetup;
    private float myWidth;
    private float myHeight;
    private MainMousePosForWindowControl mousePosScr;
    private AllCellsControl meScr;
    private movementObjectsControl moveObjControl;
    private List<int> indexesMatrLastCell = new List<int>(){-1, -1};

    // Start is called before the first frame update
    void Awake()
    {
        m_RectTransform = gameObject.GetComponent<RectTransform>();
        m_rect = m_RectTransform.rect;
        meScr = gameObject.GetComponent<AllCellsControl>();
        mousePosScr = transform.parent.parent.gameObject.GetComponent<MainMousePosForWindowControl>();
        moveObjControl = transform.parent.parent.gameObject.GetComponent<movementObjectsControl>();
        
        cellSetup = new Vector2(m_rect.size[0] / 3, m_rect.size[1] / 3);
        myWidth = m_rect.size[0];
        myHeight = m_rect.size[1];
        //print(m_rect.position);
        //print(m_rect.size);
        coordX = Screen.width /2 + m_rect.position[0];
        coordY = Screen.height/2 + m_rect.position[1];
        //print("----" + coordX + " " + coordY);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cellScripts[i].Add(transform.Find("Panel" + i.ToString() + "/cell" + j.ToString()).GetComponent<MainCellControll>());
                cellScripts[i][j].SetParametrs(cellSetup, coordX + cellSetup[0]*i, coordY + cellSetup[1]*j, i, j, mousePosScr, meScr);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CellsControl(Input.mousePosition[0], Input.mousePosition[1]);
    }
    public void GiveComponentIntoCell(Vector2 mousePos, Sprite sprite, GameObject obj)// // используется для того, чтобы поменять спрайты местами (данная штука не работает)
    {
        this.GiveComponentIntoCell(mousePos, sprite, obj, indexesMatrLastCell);
    }
    public void GiveComponentIntoCell(Vector2 mousePos, Sprite sprite, GameObject obj, List<int> indexesMatrLastCellLoc) // положить компонент внутрь ячейки
    {
        
        List<int> indexes = CellsControl(mousePos[0], mousePos[1]);
        //print("-----0----");
        if (indexes[0] >= 0 && indexes[0] <=2 ) 
        {
            if (indexes[1] >= 0 && indexes[1] <= 2 ) 
            {
                //print("-----))))- " + indexes[0] + " " + indexes[1] + " "+ cellScripts.Count + " " + cellScripts[indexes[0]].Count);
                cellScripts[indexes[0]][indexes[1]].GiveSprite(sprite, obj, indexesMatrLastCellLoc);
                moveObjControl.SetIsObjInventary(true);
                indexesMatrLastCellLoc =  new List<int>(){-1, -1};
            }
        }
    }


    public List<int> CellsControl(float mouX, float mosY)
    {
        float mousX = mouX - coordX;
        float mouseY = -(mosY -  Screen.height + coordY);
        if (mousX > 0 & mousX < myWidth)
        {
            if (mouseY > 0 & mouseY < myHeight)
            {
                return new List<int>(){(int)(mouseY/cellSetup[0]), (int)(mousX/cellSetup[1])};
            }
        }
        return new List<int>(){-1, -1};
    }
    public void DragMouseForCell(Sprite sprite, GameObject obj, List<int> cellInd) // мышка взяла объект из инвентпря
    {
        moveObjControl.SetIsObjInventary(false);
        moveObjControl.howObjectMovement(obj, sprite);
        indexesMatrLastCell = cellInd;
    }
    public void TryingWrongMovement(Sprite sprite, GameObject obj) // если игрок вносит объект из мира в уже заполненную ячейку
    {
        //moveObjControl.howObjectMovement(obj, sprite);
        moveObjControl.TryingWrongMovementReturningPlaseObject(obj, sprite);
    }
    public void swapSprite(Sprite sprite, GameObject obj, List<int> cellInd) // поменять местами спрайты в инвентаре
    {
        cellScripts[cellInd[0]][cellInd[1]].GiveSprite(sprite, obj, indexesMatrLastCell);
    }
    public void FindBlankCell(GameObject obj)//найти пустую ячейку для того, чтобы положить в нее объект
    {
        int indexJ = -1;
        int indexI = -1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (!cellScripts[i][j].isSprite())
                {
                    indexJ = j;
                    indexI = i;
                    break;
                }
            }
            if (!cellScripts[indexI][indexJ].isSprite())
            {
                break;
            }
        }
        if (indexJ != -1)
        {
            cellScripts[indexI][indexJ].GiveSprite(obj, new List<int>(){-1, -1});
            moveObjControl.SetIsObjInventary(true);
        }
    }
    public Rect GetMyRect()
    {
        return m_rect;
    }
    public float GetCoordX()
    {
        return coordX;
    }
    public float GetCoordY()
    {
        return coordY;
    }
    public float GetSizeX()
    {
        return m_rect.size[0];
    }
    public float GetSizeY()
    {
        return m_rect.size[1];
    }
    public void SetIndexesMatrLastCell(List<int> newIndexesMatrLastCell)
    {
        indexesMatrLastCell = newIndexesMatrLastCell;
    }

}
