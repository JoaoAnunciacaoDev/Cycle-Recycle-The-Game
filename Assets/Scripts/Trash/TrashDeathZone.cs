using UnityEngine;

public class TrashDeathZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Trash trash = other.GetComponent<Trash>();

        if (trash == null) return;

        gameManager.TakeDamage(1);
        Destroy(other.gameObject);
    }
}
