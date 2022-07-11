using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject panelOpciones;

    public void abrirOpciones(){
        panelOpciones.SetActive(true);
    }
    public void cerrarOpciones(){
        panelOpciones.SetActive(false);
    }

    public void salir()
    {
        Application.Quit();

    }
}
