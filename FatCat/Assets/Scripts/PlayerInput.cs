using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float jumpSpeed = 8f;

    public bool _isGrounded = true;

    public bool _isDead = false;
    private Animator animator;
    private Rigidbody2D player;

    public LayerMask groundlayer = 1<<3;

    private Hud hud;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        hud = Object.FindAnyObjectByType<Hud>();

        _isDead = false;
    }

    void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, groundlayer); //Casts raycast downwards to find if the player is on the ground
        animator.SetBool("_isGrounded", _isGrounded);
        CheckPosition();

        if(Input.GetButtonDown("Jump") && _isGrounded) //Checks to see if the player can jump
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        
    }

    //Checks to see if the player is out of view
    private void CheckPosition()
    {
        if(this.transform.position.x <= -8 || this.transform.position.y <= -5)
        {
            _isDead = true;
        }
    }
}
