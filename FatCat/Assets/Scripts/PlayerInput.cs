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
    private Animator animator;
    private Rigidbody2D player;

    public LayerMask groundlayer = 1<<3;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, 1f, groundlayer);
        animator.SetBool("_isGrounded", _isGrounded);


        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
}
