using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeWiretrigger : MonoBehaviour
{
    [SerializeField] private GameObject gasPistol;
    private Vector3 pistolStartPos;
    private Quaternion pistolStartRotate;
    [SerializeField] private GameObject handPlace;
    private bool isTook;
    private bool isInTrigger;
    [SerializeField] private AudioSource stationAudio;
    [SerializeField] private AudioClip takeGas;
    [SerializeField] private AudioClip throwGas;
    [SerializeField] private new Animation animation;

    void Start()
    {
        pistolStartPos = gasPistol.transform.position;
        pistolStartRotate = gasPistol.transform.rotation;
        isTook = false;
        isInTrigger = false;
         
    }

    private void moveWire()
    {
        if (isTook)
        {
            gasPistol.transform.position = handPlace.transform.position;
            gasPistol.transform.rotation = handPlace.transform.rotation;
        }
        else CancelInvoke();
    }
    private void throwGasPistol()
    {
        animation.Play("throwGasPistol");
        stationAudio.PlayOneShot(throwGas);
        gasPistol.transform.position = pistolStartPos;
        gasPistol.transform.rotation = pistolStartRotate;
        isTook = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            if (!isTook)
            {   

                stationAudio.PlayOneShot(takeGas);
                animation.Blend("takeGasPistol");
                InvokeRepeating("moveWire", 0, 0.001f);
                isTook = true;
            }
            else
            {
                throwGasPistol();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (isTook)
        {
            throwGasPistol();
        }
        isInTrigger = false;
    }
}
