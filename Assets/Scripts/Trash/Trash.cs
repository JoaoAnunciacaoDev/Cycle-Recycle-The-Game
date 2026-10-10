using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType type;
    [SerializeField] private float fallSpeed = 3f;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;

    public TrashType Type => type;

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