using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleAnimControllerTrying : MonoBehaviour
{
    private Animator anim;
    private float speedd;
    private float pasr_speedd;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       speedd = Input.GetAxis("Vertical");
       if (pasr_speedd != speedd)
       {
           print("-0-0-0-0-0-");
       }
       pasr_speedd = speedd;
    }
    void FixedUpdate()
    {
        anim.SetFloat("speeed", speedd);
    }
}
