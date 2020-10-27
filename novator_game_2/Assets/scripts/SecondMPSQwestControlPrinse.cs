using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMPSQwestControlPrinse : MonoBehaviour
{
    private MPSQwestControl mPSQwestControlScr;
    [SerializeField]
    public Collider enableCollider;
    void Awake()
    {
        mPSQwestControlScr = gameObject.GetComponent<MPSQwestControl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            {
            int Dialogprogress = mPSQwestControlScr.GetDialogStatus();
            if (Mathf.Abs(Dialogprogress) > 500)
            {
                enableCollider.enabled = false;
            }
        }

    }
}
