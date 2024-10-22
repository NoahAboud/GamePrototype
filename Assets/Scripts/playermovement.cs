using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Transform launchOFFset2;
    private bool facingRight = true;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    AudioManager audioManager;

    public float xVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(xVelocity));

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (spriteRenderer.flipX == true)
            {
                Instantiate(projectileprefab, launchOFFset.position, launchOFFset.rotation);
                audioManager.PlaySFX(audioManager.Gun);
            }
            else
            {
                Instantiate(projectileprefab, launchOFFset2.position, launchOFFset2.rotation);
                audioManager.PlaySFX(audioManager.Gun);
            }
        }

       
        xVelocity = rb.velocity.x;

        // != not equal to
        // == equal to

        if (rb.velocity.x != 0)
        {
            spriteRenderer.flipX = rb.velocity.x < 0f;
        }


    }

    void flip()
    {

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
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

  

}
