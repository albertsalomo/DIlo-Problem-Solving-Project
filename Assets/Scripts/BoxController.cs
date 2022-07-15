using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxController : MonoBehaviour
{
    public UnityAction OnBoxDisabled = delegate { };
    public float degree = 0.2f;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0 ,0 , degree);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Read Player Tag
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(1);
            gameObject.SetActive(false);
            OnBoxDisabled();
            OnBoxDisabled = delegate { };
        }
    }
}
