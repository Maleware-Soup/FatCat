using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float jumpSpeed = 8f;

    private bool _isGrounded = true;

    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            _isGrounded = false;
        }
    }
}
