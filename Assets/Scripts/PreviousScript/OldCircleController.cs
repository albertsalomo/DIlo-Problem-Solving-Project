using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OldCircleController : MonoBehaviour
{
    // set max speed for player
    public float maxSpeed = 10.0f;
    public float Force = 10.0f;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Move();
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

    public void MoveInput(float x, float y)
    {
        rigid.velocity = Vector2.ClampMagnitude(new Vector2(x * Force, y * Force), maxSpeed);
    }

    // cursor 
    public void CursorMove(Vector2 target)
    {
        rigid.MovePosition(Vector2.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime));
    }
}