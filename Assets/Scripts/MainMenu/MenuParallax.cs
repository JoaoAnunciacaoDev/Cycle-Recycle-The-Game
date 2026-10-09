using UnityEngine.InputSystem;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public float offsetMultiplier = 1f;
    public float smoothTime = 0.3f;

    private Vector3 startPosition;
    private Vector3 velocity;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 offset = mainCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        transform.position = Vector3.SmoothDamp(
            transform.position, startPosition + (offset * offsetMultiplier), 
            ref velocity, smoothTime);
    }
}
