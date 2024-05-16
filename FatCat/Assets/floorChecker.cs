using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class floorChecker : MonoBehaviour
{

    private Animator animator;

    private PlayerInput player;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("_isGrounded", true);
            player._isGrounded = true;
            Debug.Log("FUCK YOU");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("_isGrounded", false);
            player._isGrounded = false;
            Debug.Log("FUCK YOUX2");
        }
    }
}
