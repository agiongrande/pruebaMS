using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPjBlender : MonoBehaviour
{
    int speed = 15;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontales = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        if(vertical != 0)
        {
            anim.SetBool("caminando", true);
        }
        else
        {
            anim.SetBool("caminando", false);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("correr", true);
            speed = 25;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("correr", false);
            speed = 15;
        }

        transform.Rotate(0, horizontales, 0);

        transform.Translate(transform.forward * vertical * Time.deltaTime * speed, Space.World);

        

        
    }
}


