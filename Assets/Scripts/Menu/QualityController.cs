using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownQuality;
    [SerializeField] private TMP_Dropdown dropdownAntiAlising;
    [SerializeField] private TMP_Dropdown dropdownVSync;
    private int quality;
    private int antiAlising;
    private int vsync;
    private List<int> antiAlisingModes = new List<int>{0,2,4,8};
    void Start()
    {
        quality = PlayerPrefs.GetInt("Quality", 3);
        antiAlising = PlayerPrefs.GetInt("antiAlising", 1);
        vsync = PlayerPrefs.GetInt("VSync",1);
        dropdownQuality.value = quality;
        dropdownQuality.RefreshShownValue();
        dropdownAntiAlising.value = antiAlising;
        dropdownAntiAlising.RefreshShownValue();
        dropdownVSync.value = vsync;
        dropdownVSync.RefreshShownValue();
        changeQuality();
        changeAntiAlising();
        changeVSync(vsync);
    }

    public void changeQuality()
    {
        quality = dropdownQuality.value;
        PlayerPrefs.SetInt("Quality", quality);
        QualitySettings.SetQualityLevel(quality);
    }
    public void changeAntiAlising()
    {
        antiAlising = antiAlisingModes[dropdownAntiAlising.value];
        QualitySettings.antiAliasing = antiAlising;
        PlayerPrefs.SetInt("antiAlising", dropdownAntiAlising.value);

    }
    public void changeVSync(int value){
        vsync = value;
        QualitySettings.vSyncCount = vsync;
        dropdownVSync.value = vsync;
        dropdownVSync.RefreshShownValue();
        PlayerPrefs.SetInt("VSync",vsync);
    }
}
