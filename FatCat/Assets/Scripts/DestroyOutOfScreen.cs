using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    [SerializeField]private GameObject camPosition;


    void Start()
    {
        camPosition = GameObject.Find("Main Camera"); //once block is spawned in, it checks where it is compared to the camera
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x < camPosition.transform.position.x - 9.5F) //checks if its outside the range for the camera, if it is, destroy itself
        {
            Destroy(this.gameObject);
        }
    }
}
