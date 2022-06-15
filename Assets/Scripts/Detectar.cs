using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar : MonoBehaviour
{
    LayerMask mask;

    public float distancia = 5.5f;

    void Start()
    {
        mask = LayerMask.GetMask("RaycastObject");
    }

    void Update()
    {

        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, distancia, mask)){
            if(hit.collider.tag != null){
                //Debug.Log("AEA "+distancia);
                if(Input.GetKeyDown(KeyCode.E)){
                    LogicaPuerta puerta = hit.collider.transform.GetComponent<LogicaPuerta>();
                    bool p = !puerta.doorOpen;

                    puerta.doorOpen = p;

                }
            }
        }
    }

    public void cambio(int valor){
        distancia = valor;
    }
}
