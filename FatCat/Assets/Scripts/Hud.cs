using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [SerializeField] private Text _score; //The player can see this all the time
    [SerializeField] private Text _finishedScore; //For when the player dies
    private float _countingTime; // float in charge of updating both timers
    private float _test = 1f;
    public bool Paused = false; //pauses everything, including character controls
    [SerializeField] private GameObject _deathScreen; //upon falling to the void, screen shows up (Cat will be sleeping)

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor

        //Just incase turn off death screen
        _deathScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        _countingTime += _test * Time.deltaTime; //adds onto an float to be used later
        //TimeSpan time = TimeSpan.FromSeconds(_countingTime); //priotizes the seconds in _countingTime
        _score.text = ((int)_countingTime).ToString(); //gives out the score to the player which is just seconds
        //_finishedScore.text = _countingTime.ToString(); //hidden until player dies
    }
}
