using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad;

    public Animator anim;
    private void start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetFloat("movimiento", 0, 0.1f, Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, velocidad * Time.deltaTime);
            anim.SetFloat("movimiento", 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -velocidad * Time.deltaTime);
            anim.SetFloat("movimiento", 2.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-velocidad * Time.deltaTime, 0, 0);
            anim.SetFloat("movimiento", 1.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
            anim.SetFloat("movimiento", 2f);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("movimiento", 1.1f);

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidad += 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidad -= 3;
        }
    }
    public void accion()
    {
        anim.SetFloat("movimiento", 3.0f);
    }
}
