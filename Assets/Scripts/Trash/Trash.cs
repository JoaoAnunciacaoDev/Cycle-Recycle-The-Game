using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType type;
    [SerializeField] private float fallSpeed = 3f;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;

    [Header("Visual Effects")]
    [SerializeField] private float minRotationSpeed = 40f;
    [SerializeField] private float maxRotationSpeed = 120f;

    private float rotationSpeed;

    public TrashType Type => type;

    private void Start()
    {
        float speed = Random.Range(minRotationSpeed, maxRotationSpeed);
        float direction = Random.value > 0.5f ? 1f : -1f;
        rotationSpeed = speed * direction;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
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
        fallSpeed = speed;
        rb.linearVelocity = new Vector2(0f, -speed);
    }

    public void SetTrashType(TrashType type)
    {
        this.type = type;
    }

    public void SetVisuals(Sprite sprite, Color fallbackColor)
    {
        if (sr == null) return;

        if (sprite != null)
        {
            sr.sprite = sprite;
            sr.color = Color.white;
        }
        else
        {
            sr.color = fallbackColor;
        }
    }
}