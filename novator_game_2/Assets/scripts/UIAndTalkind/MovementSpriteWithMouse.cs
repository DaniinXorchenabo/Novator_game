using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpriteWithMouse : MonoBehaviour
{
    private RectTransform m_RectTransform;
    private Image imgScrForEditSprite;
    public Sprite sprite_null;
    private movementObjectsControl movementObjControlScr;
    private MousePointControl mousePointControl;
    private GameObject allInventaryParent;
    private MainMousePosForWindowControl mousePos;
    private Camera cam;

    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mousePos = transform.parent.gameObject.GetComponent<MainMousePosForWindowControl>();
        allInventaryParent = transform.parent.Find("MainInventary").gameObject;
        mousePointControl = allInventaryParent.GetComponent<MousePointControl>();
        movementObjControlScr = transform.parent.gameObject.GetComponent<movementObjectsControl>();
        imgScrForEditSprite = gameObject.GetComponent<Image>();
        m_RectTransform = gameObject.GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") != 0)
        {
            if (allInventaryParent.activeInHierarchy)
            {
                mousePointControl.MouseWentInventary();
            }
            m_RectTransform.anchoredPosition = mousePos.GetMousePosVector2(1);
        } 
        else
        {
            movementObjControlScr.returningPlaseObject(true);
            gameObject.SetActive(false);
        }
    } 
    public void EditMovingSprite(Sprite spriteObj)
    {
        imgScrForEditSprite.sprite = spriteObj;
    }
    
    void OnDisable() // вызывается при SetActive(false);
    {
        imgScrForEditSprite.sprite = sprite_null;
    }
}
