using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [SerializeField] private Text _score; //The player can see this all the time
    [SerializeField] private Text _finishedScore; //For when the player dies
    private int _countingTime; // float in charge of updating both timers

    public bool Paused = false; //pauses everything, including character controls
    [SerializeField] private GameObject _deathScreen;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor

        //Just incase turn off death screen
        _deathScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        _countingTime += (int)Time.time; //adds onto an float to be used later
        _score.text = _countingTime.ToString();
        //_finishedScore.text = _countingTime.ToString(); //hidden until player dies
    }
}
