using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalSun : MonoBehaviour
{
    public Transform rotPos;
    public Vector3 rotPoss;
     private Vector3 target = new Vector3(5.0f, 0.0f, 0.0f);
    void Awake()
    {
        rotPoss = rotPos.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(rotPoss, Vector3.forward, 0.1f * Time.deltaTime);
    }
}
