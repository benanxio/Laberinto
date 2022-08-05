using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    public static OptionsController options;
    [SerializeField] GameObject panelOpciones;
    [SerializeField] GameObject panelPausa;
    bool activarPausa = true;

    void Awake()
    {
        if (OptionsController.options == null)
        {
            OptionsController.options = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //panelOpciones = GameObject.FindGameObjectWithTag("Opciones");
        //panelPausa = GameObject.FindGameObjectWithTag("Pausa");
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsController.options.MostrarMenuPausa();
        }
        if (Input.GetKey(KeyCode.LeftAlt) && activarPausa)
        {
            desbloquearCursor();
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt) && activarPausa)
        {
            bloquearCursor();
        }
    }

    public void MostrarOpciones()
    {
        panelOpciones.SetActive(true);
    }
    public void MostrarMenuPausa()
    {
        if (activarPausa)
        {
            desbloquearCursor();
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
        panelPausa.SetActive(activarPausa);
        activarPausa = !activarPausa;
    }
    void desbloquearCursor()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
    void bloquearCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void EsceneCharge(string escena){
        OptionsController.options.GetComponent<CargaEscena>().CargarEscenaP(escena);
    }


}
