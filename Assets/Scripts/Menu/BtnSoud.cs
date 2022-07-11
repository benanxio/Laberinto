using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSoud : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip clip;


    public void Reproducir(){
        sonido.PlayOneShot(clip);
    }
}
