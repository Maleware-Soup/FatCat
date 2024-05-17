using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Objects to spawn
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _pickUp10; //adds 10 to the score once implemented
    [SerializeField] private GameObject _pickUp15; //adds 15 to the score once implemented
    [SerializeField] private GameObject _pickUp20; //adds 20 to the score once implemented
    [SerializeField] private Transform _folder; //keeps the hierarchy clean
    


    //Floor spawning variables
    private float _cameraDestination = 0.5F; //how far the camera has to go
    private int _constantFloorSpawn = 10; //where the floor will be spawning
    private int _spawnAmount = 0; //how long the curret floor should be (Randomized)
    private int _spawnElevation = -5; //what height the floor should spawn at (Randomized)
    private int _lastSpawnElevation = 0; //this is the first spawnelevation which is calculated with the second spawnelevation
    private int _spawnAmountConstant = 0; //Spawn amount with an unchangable value, this is equal to the randomized spawn amount
    private int _flipCoin = 0; //flip coin to see if pickups would spawn
    private bool _firstObstacle; //checks to see if the spawn elevation is the same as the last spawn elevation.

    void Awake()
    {
        //starting floor, always the same
        for (int x = -9; x < 10; x++)
        {
            Instantiate(_floor, new Vector2(x, -5), Quaternion.identity, _folder);
        }
    }


    void Update()
    {
        //checks if the camera passed the 0.5 checkpoint
        if (this.transform.position.x > _cameraDestination)
        {
            //this renews all the varaiables for reuse.
            if(_spawnAmount < 0)
            {
                _firstObstacle = true;
                _lastSpawnElevation = _spawnElevation;
                _spawnAmount = Random.Range(3,11);
                _spawnAmountConstant = _spawnAmount;
                _spawnElevation = Random.Range(-3,-5);
                _flipCoin = Random.Range(-3,4);
            }
            _spawnAmount --; //every loop, minus one from the spawn amount 
            _cameraDestination ++; 
            if(_spawnAmount >= 0)
            {
                Instantiate(_floor, new Vector2(_constantFloorSpawn, _spawnElevation), Quaternion.identity, _folder); //this is the floor

                //this spawns in the pickups
                if(_spawnAmount <= _spawnAmountConstant - 10 && _flipCoin == 3) //checks to see if the 20 pickup is able to spawn
                {
                    Instantiate(_pickUp20, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.identity, _folder); 
                }
                else if(_spawnAmount <= _spawnAmountConstant - 8 && _flipCoin >= 2)//checks to see if the 15 pickup is able to spawn
                {
                    Instantiate(_pickUp15, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.identity, _folder);
                }
                else if(_spawnAmount <= _spawnAmountConstant - 5 &&_flipCoin >= 1)//checks to see if the 10 pickup is able to spawn
                {
                    Instantiate(_pickUp10, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.identity, _folder);
                }
               
                //if elevation is same as the last elevation, spawn a obstacle to prevent player from gliding over the hole
                if(_spawnElevation == _lastSpawnElevation && _firstObstacle == true)
                {
                    Instantiate(_obstacle, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.Euler(0, 0, 90), _folder);
                    _firstObstacle = false;
                }
            }
            _constantFloorSpawn ++;
        }
    }
}
