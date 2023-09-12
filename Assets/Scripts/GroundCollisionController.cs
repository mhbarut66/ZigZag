using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundCollisionController : MonoBehaviour
{

    [SerializeField] private GroundDataTransmitter groundDataTransmitter;



    

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            groundDataTransmitter.SetGroundRigidbody();
        }
    }


}
