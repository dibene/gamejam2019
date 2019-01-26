using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class babosa_scr : MonoBehaviour
{
    bool agarrado = true;
    int direcc = 2;
    Animator anim;
    Rigidbody2D rb;
    bool caminando = false;
    public float velCamina = 3f;
    //public 
    float velX =0f;
    float velY =0f;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        caminando = false;
        velX = rb.velocity.x;
        velY = rb.velocity.y;
        if (agarrado)
        {
            bool adelante = false;
            if (direcc == 1 && Input.GetAxis("Vertical") > 0.1)    { adelante = true; }
            if (direcc == 2 && Input.GetAxis("Horizontal") > 0.1)  { adelante = true; }
            if (direcc == 3 && Input.GetAxis("Vertical") < 0.1)    { adelante = true; }
            if (direcc == 4 && Input.GetAxis("Horizontal") < 0.1)  { adelante = true; }

            if (adelante) {
                caminando = true;
                
                //velX = velCamina;
                transform.position += transform.right * velCamina;

                //rb.AddRelativeForce(new Vector2(velCamina,velCamina ));
            }
            
        }
        anim.SetBool("caminando", caminando);
        
        rb.AddForce (new Vector2(velX, velY));
    }
}
