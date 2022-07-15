using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float degree = 10f;

    Rigidbody2D rigid;
    CircleController target;

    Vector2 moveDirection;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<CircleController>();
        if (target != null)
        {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rigid.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, 5f);
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, degree);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
