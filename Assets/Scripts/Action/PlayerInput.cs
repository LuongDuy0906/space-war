using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [Header("Độ nhạy ngón tay")]
    [SerializeField] private float dragSensitivity = 0.015f;

    [Header("Giới hạn di chuyển (Tọa độ tự do)")]
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => InputManager.OnDragDelta += MovePlayer;
    private void OnDisable() => InputManager.OnDragDelta -= MovePlayer;

    private void MovePlayer(Vector2 delta)
    {
        // Tính vị trí mới dựa trên vị trí hiện tại + độ dời ngón tay
        Vector2 targetPos = rb.position + (delta * dragSensitivity);

        // Chặn mép màn hình
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // Di chuyển mượt bằng Kinematic Rigidbody
        rb.MovePosition(targetPos);
    }
}