using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scissor : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject rock;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     
    void Start()
    {
        target = GameObject.FindWithTag("Paper").transform;
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
        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(rock, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
