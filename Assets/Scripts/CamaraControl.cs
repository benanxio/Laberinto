using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    [SerializeField] private Transform objASeguir;
    [SerializeField] private float velCamara = 120;
    [SerializeField] private float sensibilidad = 150;

    private float mouseX;
    private float mouseY;
    private float rotX = 0;
    private float rotY = 0;

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * sensibilidad * Time.deltaTime;
        rotX -= mouseY * sensibilidad * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -60, 60);
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);

    }
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objASeguir.position, Time.deltaTime * velCamara);
    }
}