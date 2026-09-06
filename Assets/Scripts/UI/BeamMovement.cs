using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 3f; // Tự hủy sau 3 giây nếu không trúng gì để nhẹ RAM

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Bay thẳng lên trên theo trục Y cục bộ của đạn
        transform.position += Vector3.up * (speed * Time.deltaTime);
    }
}
