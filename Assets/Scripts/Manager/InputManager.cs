using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> OnDragDelta;

    private global::Input inputAction;
    private bool wasPressedLastFrame = false;
    private Vector2 lastPosition;

    private void Awake()
    {
        inputAction = new global::Input();
    }

    private void OnEnable() => inputAction.PlayerInput.Enable();
    private void OnDisable() => inputAction.PlayerInput.Disable();

    private void Update()
    {
        // Kiểm tra xem phím/cảm ứng có đang được giữ hay không
        bool isPressed = inputAction.PlayerInput.TouchPress.IsPressed();

        if (isPressed)
        {
            Vector2 currentPosition = inputAction.PlayerInput.TouchPosition.ReadValue<Vector2>();

            // Frame đầu tiên vừa chạm xuống: chỉ ghi nhận vị trí gốc, không tính delta
            if (!wasPressedLastFrame)
            {
                lastPosition = currentPosition;
                wasPressedLastFrame = true;
                return;
            }

            // Các frame tiếp theo: tính khoảng dời
            Vector2 delta = currentPosition - lastPosition;
            lastPosition = currentPosition;

            // Chỉ bắn event khi có dịch chuyển (tránh gọi event vô nghĩa)
            if (delta.sqrMagnitude > 0.0001f)
            {
                OnDragDelta?.Invoke(delta);
            }
        }
        else
        {
            wasPressedLastFrame = false;
        }
    }
}