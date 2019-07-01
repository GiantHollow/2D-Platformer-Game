using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int attackPattern = 2;
    public float jumpForce = 300;
    public float speed = 1;
    public float movingDistance = 0.5f;
    public float attackSpeedDefault = 1;
    private float maxVelocityX = 8;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float attackTimer;
    private bool goingRight;
    private float startX;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        attackTimer = attackSpeedDefault;
        startX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (attackPattern)
        {
            case 1:
                //springen omhoog
                if (attackTimer < 0)
                {
                    rb.AddForce(new Vector2(0, jumpForce));
                    attackTimer = attackSpeedDefault;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
                break;
            case 2:
                //springen opzij
                if (attackTimer < 0)
                {
                    if (goingRight)
                    {
                        //ja we gaan naar rechts
                        rb.AddForce(new Vector2(jumpForce / 2, jumpForce));
                    }
                    else
                    {
                        //nee we naar links
                        rb.AddForce(new Vector2(-jumpForce / 2, jumpForce));
                    }
                    goingRight = !goingRight;
                    attackTimer = attackSpeedDefault;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
                break;
            case 3:
                //heen en weer lopen
                if (goingRight)
                {
                    //we gaan naar rechts
                    rb.AddForce(new Vector2(10 * speed, 0));
                    if (transform.position.x > startX + movingDistance)
                    {
                        goingRight = !goingRight;
                        transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                else
                {
                    //we gaan naar links
                    rb.AddForce(new Vector2(-10 * speed, 0));
                    if (transform.position.x < startX - movingDistance)
                    {
                        goingRight = !goingRight;
                        transform.localRotation = Quaternion.Euler(0, 180, 0);
                    }
                }
                if (rb.velocity.x > maxVelocityX)
                {
                    rb.velocity = new Vector2(maxVelocityX, rb.velocity.y);
                }

                else if (rb.velocity.x < -maxVelocityX)
                {
                    rb.velocity = new Vector2(-maxVelocityX, rb.velocity.y);
                }
                break;
        }
    }
}

