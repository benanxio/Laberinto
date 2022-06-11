using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad;
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0,0,-velocidad * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(0,0,velocidad * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(velocidad * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(-velocidad * Time.deltaTime,0,0);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            velocidad ++;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            if(velocidad <= 0.0f){
                velocidad = 0.0f;
            } 
            else{
                velocidad --;
            }
        }
    }
}
