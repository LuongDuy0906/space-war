using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Bắn ra khoảng cách ngón tay vừa vuốt
    public static event Action<Vector2> OnDragDelta;

    private global::Input inputAction;
    private bool isDragging = false;

    private void Awake()
    {
        inputAction = new global::Input();

        inputAction.PlayerInput.TouchPress.started += _ => isDragging = true;
        inputAction.PlayerInput.TouchPress.canceled += _ => isDragging = false;
    }

    private void OnEnable() => inputAction.PlayerInput.Enable();
    private void OnDisable() => inputAction.PlayerInput.Disable();

    private void Update()
    {
        if (isDragging)
        {
            Vector2 delta = inputAction.PlayerInput.TouchDelta.ReadValue<Vector2>();

            // Chỉ bắn khi ngón tay thực sự di chuyển
            if (delta.sqrMagnitude > 0.001f)
            {
                OnDragDelta?.Invoke(delta);
            }
        }
    }
}