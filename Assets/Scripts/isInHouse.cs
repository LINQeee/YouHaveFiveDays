using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInHouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.isInHouse = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerMovement.isInHouse = false;
    }
}
