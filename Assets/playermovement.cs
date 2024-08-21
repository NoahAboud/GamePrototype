using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Vector3 playerInput;
    Rigidbody2D rb;
    bool isGrounded;
    public projectilebehaviour projectileprefab;
    public Transform launchOFFset;
    private bool facingLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
       
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Instantiate(projectileprefab, launchOFFset.position, transform.rotation);
            }
        }
       
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = playerInput.normalized * speed * Time.deltaTime;
        newPosition.y = rb.velocity.y;
        rb.velocity = newPosition;
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

  

}
