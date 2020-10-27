using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObjControl : MonoBehaviour
{
    private MPSQwestControl mPSQwestControl;
    void Awake()
    {
        mPSQwestControl = gameObject.GetComponent<MPSQwestControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mPSQwestControl.GetDialogStatus() != 1)
        {
            gameObject.SetActive(false);
        }
    }
}
