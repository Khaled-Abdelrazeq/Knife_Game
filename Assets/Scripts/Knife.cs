using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Knife : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;

    //private Rigidbody2D rb;

    private bool isMoving = true;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.instance.isPlayed)
        {
            if (isMoving)
            {
                if (Circle.instance.transform != null)
                {
                    Vector3 direction = Circle.instance.transform.position - transform.position;
                    transform.position += direction.normalized * Time.deltaTime * moveSpeed;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Circle"))
        {
            isMoving = false;
            GameManager.instance.count++;
            transform.parent = Circle.instance.transform;            
        }

        if (collision.transform.CompareTag("Knife"))
        {
            // You Fail
            Destroy(gameObject);
            GameManager.instance.Fail();

        }
    }
}
