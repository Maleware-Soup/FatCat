using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _pickUp10;
    [SerializeField] private GameObject _pickUp15;
    [SerializeField] private GameObject _pickUp20;
    [SerializeField] private Transform _floorFolder;


    private float _cameraDestination = 0.5F;
    private int _constantFloorSpawn = 10;

    private int _spawnAmount = 0;
    private int _spawnElevation = -5;
    private int _lastSpawnElevation = 0;
    private int _spawnAmountConstant = 0;
    private int _flipCoin = 0;
    private bool _firstObstacle;

    private List<GameObject> _floorPlacements = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int x = -9; x < 10; x++)
        {
            Instantiate(_floor, new Vector2(x, -5), Quaternion.identity, _floorFolder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.x > _cameraDestination)
        {
            if(_spawnAmount < 0)
            {
                _firstObstacle = true;
                _lastSpawnElevation = _spawnElevation;
                _spawnAmount = Random.Range(5,10);
                _spawnAmountConstant = _spawnAmount;
                _spawnElevation = Random.Range(-2,-5);
                _flipCoin = Random.Range(0,2);
            }
            _spawnAmount --;            
            _cameraDestination ++;
            if(_spawnAmount >= 0)
            {
                Instantiate(_floor, new Vector2(_constantFloorSpawn, _spawnElevation), Quaternion.identity, _floorFolder);

                if(_spawnAmount <= _spawnAmountConstant - 4 && _flipCoin == 1)
                {
                    Instantiate(_pickUp10, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.identity, _floorFolder);
                }

                if(_spawnElevation == _lastSpawnElevation && _firstObstacle == true)
                {
                    Instantiate(_floor, new Vector2(_constantFloorSpawn, _spawnElevation + 1), Quaternion.identity, _floorFolder);
                    _firstObstacle = false;
                }
            }
            _constantFloorSpawn ++;
        }
    }
}
