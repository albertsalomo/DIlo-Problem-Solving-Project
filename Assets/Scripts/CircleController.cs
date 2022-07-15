using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public Transform player;
    public AudioSource collide;
    public AudioSource hit;

    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthbar;

    // set max speed for player
    public float maxSpeed = 10.0f;
    public float Force = 10.0f;

    // pushed back
    Vector2 impulse = new Vector2(-7, 2);
    public float collideForce = .2f;

    private Rigidbody2D rigid;

    private void Start()
    {
        InputHandler inputHandler = GetComponent<InputHandler>();
        if (inputHandler is null || !inputHandler.enabled)
        {
            Move();
        }
        else
        {
            rigid = GetComponent<Rigidbody2D>();
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    // move method
    private void Move()
    {
        float rand = Random.Range(-Force, Force);
        if (Random.Range(-1, 1) < 0)
        {
            //go to left
            rigid.AddForce(Vector2.ClampMagnitude(new Vector2(-Force, 2), maxSpeed), ForceMode2D.Impulse);
        }
        else
        {
            //go to right
            rigid.AddForce(Vector2.ClampMagnitude(new Vector2(Force, 2), maxSpeed), ForceMode2D.Impulse);
        }
    }

    // keyboard
    public void MoveInput(float x, float y)
    {
        rigid.velocity = Vector2.ClampMagnitude(new Vector2(x * Force, y * Force), maxSpeed);
    }

    // cursor 
    public void CursorMove(Vector2 target)
    {
        rigid.MovePosition(Vector2.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            collide.Play();
            if (player.gameObject.transform.localScale.x < 2f && player.gameObject.transform.localScale.y < 2f)
            {
                player.gameObject.transform.localScale += new Vector3(.002f, .002f, 0);
            } 
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(10);
            hit.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}