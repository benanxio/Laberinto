using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CargaEscena : MonoBehaviour
{
    [SerializeField] GameObject panelCarga;
    [SerializeField] Slider sliderCarga;
    [SerializeField] TMP_Text info;
    [SerializeField] TMP_Text textc;
    public void MainMenu()
    {
        OptionsController.options.Autodestruccion();
        
        SceneManager.LoadScene("menu");
    }
    public void play()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void CargarEscenaP(string escena)
    {
        StartCoroutine(CargaAsync(escena));
    }

    IEnumerator CargaAsync(string escena)
    {

        panelCarga.SetActive(true);

        AsyncOperation Operacion = SceneManager.LoadSceneAsync(escena);
        Operacion.allowSceneActivation = false;

        while (!Operacion.isDone)
        {
            float progreso = Mathf.Clamp01(Operacion.progress / 0.9f) * 100;
            sliderCarga.value = progreso;
            textc.text = (int)progreso + "%";

            if(progreso > 0.9f){
                Operacion.allowSceneActivation = true;
                yield return new WaitForSeconds(2f);
                panelCarga.SetActive(false);
            }
            yield return null;
        }
    }

}
