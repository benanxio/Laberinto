using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscena : MonoBehaviour
{
    public void iniciar(){
        SceneManager.LoadScene("menu");
    }
    public void play(){
        SceneManager.LoadScene("Inicio");
    }
    public void CargarEscenaP(string escena){
        SceneManager.LoadScene(escena);

    public void salir(){
        Application.Quit(); 
    }
}
