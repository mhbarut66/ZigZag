using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundPosController : MonoBehaviour
{
    private GroundSpawnController groundSpawnController;
    private Rigidbody rb;
    [SerializeField] private float endYValue;
    private int groundDirection;

    private void Start() {
        groundSpawnController = FindObjectOfType<GroundSpawnController>();
        rb = GetComponent<Rigidbody>();

    }

    private void Update() {
        CheckGroundVerticalPos();
    }

    private void CheckGroundVerticalPos()
    {
        if (transform.position.y <= endYValue)
        {
            SetRigidbodyValue();
            
            SetGroundNewPosition();
            
        }
    }

    private void SetGroundNewPosition()
    {
        groundDirection = Random.Range(0,2);

            if (groundDirection == 0)
            {
                transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x -1f,groundSpawnController.lastGroundObject.transform.position.y,groundSpawnController.lastGroundObject.transform.position.z);
            }else
            {
                transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x,groundSpawnController.lastGroundObject.transform.position.y,groundSpawnController.lastGroundObject.transform.position.z + 1f);

            }

            groundSpawnController.lastGroundObject = gameObject;
    }

    private void SetRigidbodyValue()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
