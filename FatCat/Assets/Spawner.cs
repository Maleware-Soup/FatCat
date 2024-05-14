using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject _floor;
    [SerializeField] private Transform _floorFolder;

    private float _cameraDestination = 0.5F;
    private int _constantFloorSpawn = 10;

    private int _spawnAmount = 0;
    private int _spawnElevation = -5;

    private List<GameObject> _floorPlacements = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int x = -9; x < 10; x++)
        {
            Instantiate(_floor, new Vector3(x, -5, 0), Quaternion.identity, _floorFolder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.x > _cameraDestination)
        {
            if(_spawnAmount < 0)
            {
                _spawnAmount = Random.Range(5,10);
                _spawnElevation = Random.Range(-2,-5);
            }
            _spawnAmount --;            
            _cameraDestination ++;
            if(_spawnAmount >= 0)
            {
                Instantiate(_floor, new Vector3(_constantFloorSpawn, _spawnElevation, 0), Quaternion.identity, _floorFolder);
            }
            _constantFloorSpawn ++;
        }
    }
}
