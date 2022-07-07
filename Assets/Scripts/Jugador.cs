using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject camara;

    [Header("Estadisticas normales")]
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadCorriendo;
    [SerializeField] private float tiempoAlGirar;

    float velocidadGiro;
    //float gravedad = -9.81f;
    Vector3 velocity;

    public Animator anim;

    private void start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0.0f, vertical).normalized;
        if (direccion.magnitude >= 0.1f)
        {
            float objetivoAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngulo, ref velocidadGiro, tiempoAlGirar);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("movimiento", 1.1f);
                Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                controller.Move(mover.normalized * velocidadCorriendo * Time.deltaTime);
            }
            else
            {
                anim.SetFloat("movimiento", 0.5f);
                Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                controller.Move(mover.normalized * velocidad * Time.deltaTime);
            }
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
        
        anim.SetFloat("movimiento", 0, 0.1f, Time.deltaTime);
    }

    public void accion()
    {
        anim.SetFloat("movimiento", 3.0f);
    }
}
