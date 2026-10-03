using System;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType type;
    [SerializeField] private float fallSpeed = 3f;
    private Rigidbody2D rb;
    public TrashType Type => type;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x, 
            -fallSpeed
        );
    }

    public void SetFallSpeed(float speed)
    {
        rb.linearVelocity = new Vector2(0f, -speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
