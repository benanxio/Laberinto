using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public bool activeTP;
    public Transform posTP, posPP;
    public float rotSpeed;
    public float rotMin, rotMax;
    float mouseX, mouseY;
    public Transform target, player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Cam(){
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY += rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY,rotMin,rotMax);
        target.rotation = Quaternion.Euler(-mouseY,mouseX,0.0f);
        player.rotation = Quaternion.Euler(0.0f,mouseX,0.0f);
    }

    void LateUpdate()
    {
        Cam();
        if(activeTP == false && Input.GetKeyDown(KeyCode.Tab)){
            //transform.GetComponent<Detectar>().cambio(5);
            activeTP = true;
            transform.position = posPP.position;
        }
        else if (activeTP && Input.GetKeyDown(KeyCode.Tab)){
            //transform.GetComponent<Detectar>().cambio(20);
            activeTP = false;
            transform.position = posTP.position;
            transform.LookAt(player);
        }
    }
}
