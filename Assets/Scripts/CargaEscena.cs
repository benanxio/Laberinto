using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void iniciar(){
        SceneManager.LoadScene("menu");
    }
    public void play(){
        SceneManager.LoadScene("Inicio");
    }
}
