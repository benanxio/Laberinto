using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar : MonoBehaviour
{
    LayerMask mask;

    public float distancia;
    public GameObject instrucciones;
    public GameObject origen;
    GameObject ultimoReconocido;

    void Start()
    {
        mask = LayerMask.GetMask("RaycastObject");
        instrucciones = GameObject.FindGameObjectWithTag("Info");
        instrucciones.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(origen.transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselected();
            SelectedObject(hit.transform);
            if (hit.collider.tag == "Objeto")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<LogicaPuerta>().ChangeDoorState();
                }
            }
            Debug.DrawRay(transform.position, Vector3.forward * distancia, Color.red);
        }
        else
        {
            Deselected();
        }

    }

    public void cambio(int valor)
    {
        distancia = valor;
    }

    void SelectedObject(Transform transform)
    {
        ultimoReconocido = transform.gameObject;
    }

    void Deselected()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        //Rect rect = new Rect(Screen.width / 2, Screen.height/2, puntero.width, puntero.height);
        //GUI.DrawTexture(rect, puntero);
        if (ultimoReconocido!=null)
        {
            instrucciones.SetActive(true);
        }
        else
        {
            instrucciones.SetActive(false);
        }
    }
}
