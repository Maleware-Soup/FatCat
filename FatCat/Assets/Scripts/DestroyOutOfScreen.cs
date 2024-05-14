using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
    [SerializeField]private GameObject camPosition;


    void Start()
    {
        camPosition = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x < camPosition.transform.position.x - 9.5F)
        {
            Destroy(this.gameObject);
        }
    }
}
