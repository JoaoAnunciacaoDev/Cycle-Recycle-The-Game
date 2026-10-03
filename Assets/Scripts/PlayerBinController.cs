using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Collider2D collider2D;

    private InputSystem_Actions inputActions;
    private bool isDragging = false;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (inputActions.Player.PointerPress.WasPressedThisFrame())
        {
            Vector2 pointerPosition = inputActions.Player.PointerPosition.ReadValue<Vector2>();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
                new Vector3(
                    pointerPosition.x, 
                    pointerPosition.y, 
                    -mainCamera.transform.position.z
                    )
            );

            Vector2 point = new Vector2(worldPosition.x, worldPosition.y);

            isDragging = collider2D.OverlapPoint(point);
        }

        if (!isDragging) return;

        Vector2 currentPointerPosition = inputActions.Player.PointerPosition.ReadValue<Vector2>();

        Vector3 currentWorldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(
                currentPointerPosition.x, 
                currentPointerPosition.y, 
                -mainCamera.transform.position.z
            )
        );

        transform.position = new Vector3(
            currentWorldPosition.x,
            currentWorldPosition.y,
            transform.position.z
        );

        if (inputActions.Player.PointerPress.WasReleasedThisFrame())
        {
            isDragging = false;
        }
    }
}
