using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float jumpSpeed = 8f;

    private bool _isGrounded = true;

    private Animator animator;

    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && this.gameObject && _isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if(normal == Vector3.up)
            {
                animator.SetBool("_isGrounded", true);
                _isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("_isGrounded", false);
            _isGrounded = false;
        }
    }
}
