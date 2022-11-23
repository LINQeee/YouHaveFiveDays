using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake_Xrotation : MonoBehaviour
{
   [SerializeField] private float shakeSensetive = 1;
   [SerializeField] private float speed = 2;
    [SerializeField] private float verticalSensetive = 3;
    [SerializeField] private float minVertical = -60;
    [SerializeField] private float maxVertical = 60;

    private float rotationX = 0;
    private Vector3 startPos;
    private float distantion;
    private Vector3 rotation = Vector3.zero;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {

        //y
        rotationX -= Input.GetAxis("Mouse Y") * verticalSensetive;
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);                                
        
        //z
        distantion += (transform.position - startPos).magnitude;
        startPos = transform.position;
        rotation.z = Mathf.Sin(distantion * speed) * shakeSensetive;

        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, rotation.z);
    }
}
