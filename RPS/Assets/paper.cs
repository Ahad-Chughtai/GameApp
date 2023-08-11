using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class paper : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject scissor;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     
    void Start()
    {
        target = GameObject.FindWithTag("Rock").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDir = dir;
        }
    }

    private void FixedUpdate()
    {
        if (target) 
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scissor")
        {
            Instantiate(scissor, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
