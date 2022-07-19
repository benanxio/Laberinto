using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscena : MonoBehaviour
{
    public void MainMenu()
    {
        Destroy(OptionsController.options.gameObject);
        SceneManager.LoadScene("menu");
    }
    public void play()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void CargarEscenaP(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}