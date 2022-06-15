using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    public GameObject objeto;
    public void ActivarObjeto(){
        Destroy(objeto);
    }
}
