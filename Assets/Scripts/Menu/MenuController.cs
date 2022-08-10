using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject panelOpciones;
    public void salir()
    {
        Application.Quit();

    }
    public void mostraropciones(){
        panelOpciones.SetActive(true);
    }
}
6