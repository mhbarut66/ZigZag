using System.ComponentModel;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallController : MonoBehaviour
{

    
    [SerializeField] private BallDataTransmitter ballDataTransmitter;

    [SerializeField] private float ballMoveSpeed;
    private bool IsDead = false;
    public GameObject DeathScreen;

    public AudioSource background;


    private void Update() {
        SetBallMovement();

        if (transform.position.y < -7)
        {
            //Oyun biter.
            IsDead = true;
            DeathScreen.SetActive(true);
            Time.timeScale = 0;
            background.Stop();

        }

        if(IsDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDead = false;
                SceneManager.LoadScene(0); 
                Time.timeScale = 1;
            }
        }

    }

    private void Start() {
        Application.targetFrameRate = 90;
    }

    void SetBallMovement()
    {
        transform.position += ballDataTransmitter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }
}

