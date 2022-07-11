using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenController : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown dropdownResolutions;
    public TMP_Dropdown dropdownFPS;
    public List<int> FPS = new List<int> { 30, 60, 120 };

    void Start()
    {
        ChargeResolution();
    }


    public void ChargeResolution()
    {
        resolutions = Screen.resolutions;
        dropdownResolutions.ClearOptions();
        dropdownFPS.ClearOptions();
        List<string> resoltionOptions = new List<string> { };
        List<string> FPSlist = new List<string> { "30", "60", "120" };
        int actuallyResolution = resolutions.Length - 1;
        int actuallyFPS = 1;

        for (int i = resolutions.Length - 1; i >= 0; i--)
        {
            Resolution resolution = resolutions[i];
            if (i == resolutions.Length - 1)
            {
                resoltionOptions.Add(resolution.width + "x" + resolution.height + " Pantalla completa");
            }
            else
            {
                resoltionOptions.Add(resolution.width + "x" + resolution.height + " Modo ventana");
            }

            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                actuallyResolution = resolutions.Length - 1 - i;
            }
        }
        for (int i = 0; i < FPS.Count; i++)
        {
            if (FPS[i] == Screen.currentResolution.refreshRate)
            {
                actuallyFPS = i;
            }
        }
        dropdownResolutions.AddOptions(resoltionOptions);
        dropdownResolutions.value = PlayerPrefs.GetInt("optionResolution",actuallyResolution);
        dropdownResolutions.RefreshShownValue();
        dropdownFPS.AddOptions(FPSlist);
        dropdownFPS.value = PlayerPrefs.GetInt("optionFPS",actuallyFPS);
        dropdownFPS.RefreshShownValue();

    }

    public void ChangeResolution(int option)
    {
        PlayerPrefs.SetInt("optionResolution", option);
        Resolution resolution = resolutions[resolutions.Length - 1 - option];
        if (option == 0){
            
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);
        }
        else
        {
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
        }
    }

    public void ChangeFPS(int option)
    {
        PlayerPrefs.SetInt("optionFPS", option);
        Application.targetFrameRate = FPS[option];
        transform.GetComponent<QualityController>().changeVSync(0);
    }
}
