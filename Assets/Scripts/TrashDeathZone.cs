using UnityEngine;

public class TrashDeathZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Trash trash = other.GetComponent<Trash>();
        Debug.Log("TrashDeathZone: OnTriggerEnter with " + other.name);

        if (trash == null) return;

        gameManager.TakeDamage(1);
        Destroy(other.gameObject);
    }
}
