using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Tốc độ di chuyển")]
    [SerializeField] private float moveSpeed = 0.02f; // Tỉ lệ đổi từ pixel sang đơn vị Unity

    [Header("Giới hạn di chuyển thủ công")]
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;

    private void OnEnable()
    {
        InputManager.OnDragDelta += MovePlayer;
    }

    private void OnDisable()
    {
        InputManager.OnDragDelta -= MovePlayer;
    }

    private void MovePlayer(Vector2 delta)
    {
        Vector3 newPos = transform.position;
        newPos.x += delta.x * moveSpeed;
        newPos.y += delta.y * moveSpeed;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }
}