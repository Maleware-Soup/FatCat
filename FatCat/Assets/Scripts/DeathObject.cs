using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerInput player;
        player = other.gameObject.GetComponent<PlayerInput>();

        if (other.gameObject.name == "Player")
        {
            
        }
    }
}
