using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private float smoothSpeed = 10f;
    [SerializeField] private TrashType type;

    private InputSystem_Actions inputActions;
    private bool isDragging;
    private Vector3 targetPosition;
    public TrashType Type => type;   

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        Vector2 pointerPosition = inputActions.Player.PointerPosition.ReadValue<Vector2>();

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(
                pointerPosition.x,
                pointerPosition.y,
                -mainCamera.transform.position.z
            )
        );

        if (inputActions.Player.PointerPress.WasPressedThisFrame())
        {
            Vector2 point = new Vector2(
                worldPosition.x,
                worldPosition.y
            );

            isDragging = collider2D.OverlapPoint(point);

            if (isDragging)
            {
                targetPosition = worldPosition;
            }
        }

        if (!isDragging)
            return;

        targetPosition = ClampToBounds(new Vector3(
            worldPosition.x,
            worldPosition.y,
            transform.position.z
        ));

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        if (inputActions.Player.PointerPress.WasReleasedThisFrame())
        {
            isDragging = false;
        }
    }

    private Vector3 ClampToBounds(Vector3 position)
    {
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        float halfObjectWidth = collider2D.bounds.extents.x;
        float halfObjectHeight = collider2D.bounds.extents.y;

        float minX = -halfWidth + halfObjectWidth;
        float maxX = halfWidth - halfObjectWidth;

        float minY = -halfHeight + halfObjectHeight;
        float maxY = halfHeight - halfObjectHeight;

        return new Vector3(
            Mathf.Clamp(position.x, minX, maxX),
            Mathf.Clamp(position.y, minY, maxY),
            position.z
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Trash trash = other.GetComponent<Trash>();

        if (trash == null) return;
        if (trash.Type != type) return;

        Destroy(trash.gameObject);
    }
}