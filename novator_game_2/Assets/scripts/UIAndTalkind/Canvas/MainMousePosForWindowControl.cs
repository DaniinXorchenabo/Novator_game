using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMousePosForWindowControl : MonoBehaviour
{
    private float mousePosX;
    private float mousePosY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition[0];
        mousePosY = Input.mousePosition[1];
    }
    public float GetMousePosX() {return mousePosX;}
    public float GetMousePosY(){return this.GetMousePosY(0);}
    public float GetMousePosY(int flag) {
        if (flag == 1){return mousePosY - Screen.height;}
        return mousePosY;}
    public Vector2 GetMousePosVector2() {return this.GetMousePosVector2(0);}
    public Vector2 GetMousePosVector2(int flag) {
        if (flag == 1){return new Vector2(mousePosX, mousePosY - Screen.height);}
        return new Vector2(mousePosX, mousePosY);}
    public List<float> GetMousePosList() {return new List<float>(){mousePosX, mousePosY};}
    //public float GetMousePosYForHeignt() {return mousePosY - Screen.height;}
}
