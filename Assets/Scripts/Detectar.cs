using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar : MonoBehaviour
{
    LayerMask mask;

    public float distancia = 5.5f;

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
    }

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, distancia, mask)){
            if(hit.collider.tag == "Puerta"){
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();
                }
            }
        }
    }
}
