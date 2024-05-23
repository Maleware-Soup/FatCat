using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [SerializeField] private Text _score; //The player can see this all the time
    [SerializeField] private Text _finishedScore; //For when the player dies
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _deathScreen; //upon falling to the void, screen shows up (Cat will be sleeping)
    private float _countingTime; // float in charge of updating both timers

    private bool Paused = true; //pauses everything, including character controls

    public float scoreAddon;
    private int pointDestination = 300; //Every 200 points, increase speed

    private PlayerInput player;
    private AudioSource _audioSwitch;
    [SerializeField] private AudioClip _coinPickUpSound;
    private CameraMovement increaseInSpeed; //Increases the speed once the player reaches a certain score
    

    private void Start()
    {
        player = FindAnyObjectByType<PlayerInput>();
        increaseInSpeed = FindAnyObjectByType<CameraMovement>();
        _audioSwitch = FindAnyObjectByType<PlayerInput>().GetComponent<AudioSource>();

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Locked; //locks cursor
        //Just incase turn off death screen
        _deathScreen.SetActive(false);
        _startScreen.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        _countingTime += 1f * Time.deltaTime; //adds onto an float to be used later
        _score.text = ((int)_countingTime).ToString(); //gives out the score to the player which is just seconds
        _finishedScore.text = ((int)_countingTime).ToString(); //hidden until player dies
        if(int.Parse(_score.text) >= pointDestination && pointDestination != 300 * 3)
        {
            pointDestination += 300;
            increaseInSpeed.movingSpeed += 1.5f;
        }

        if(Paused == true && Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Paused = false;
            _startScreen.SetActive(false);
            if (player._isDead == true)
            {
                SceneManager.LoadScene(0);
            }
        }

        if(player._isDead == true)
        {
            Time.timeScale = 0f;
            Paused = true;
            _deathScreen.SetActive(true);
        }
    }

    public void PointAddOn()
    {
        _audioSwitch.PlayOneShot(_coinPickUpSound);
        _countingTime += scoreAddon;
        scoreAddon = 0;
    }
}
