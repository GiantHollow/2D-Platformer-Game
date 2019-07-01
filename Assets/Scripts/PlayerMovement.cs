using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    private float lifes = 2;

    private float maxVelocityX = 4;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        //add force
        rb.AddForce(new Vector3(horizontalAxis, 0) * 30);

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale = new Vector3(9, 9, 9);
        }

        //jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            isGrounded = false;

            //reset velocity when max reached
            if (rb.velocity.x > maxVelocityX)
            {
                rb.velocity = new Vector2(maxVelocityX, rb.velocity.y);
            }

            else if (rb.velocity.x < -maxVelocityX)
            {
                rb.velocity = new Vector2(-maxVelocityX, rb.velocity.y);
            }
        }

        //player dies when lifes reaches 0 or when he falls of the map
        if (lifes == 0 || transform.position.y < -15)
        {
                SceneManager.LoadScene("DeathScreen");
        }
    }

        //when collided with object
        private void OnCollisionEnter2D(Collision2D collision)
        {
            isGrounded = true;
            if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Spike")
            {
                lifes -= 1;
                LifesScript.lifeValue -= 1;
            }
            else if (collision.gameObject.name == "Coin")
            {
                ScoreScript.scoreValue += 10;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Chest" && ScoreScript.scoreValue == 30)
            {
                ScoreScript.scoreValue += 100;
                SceneManager.LoadScene("WinScreen");
        }
    }
}
