using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 3f;
    [SerializeField] private Transform bg1;
    [SerializeField] private Transform bg2;

    private float bgHeight;

    void Awake()
    {
        if (bg1 == null && transform.childCount > 0) bg1 = transform.GetChild(0);
        if (bg2 == null && transform.childCount > 1) bg2 = transform.GetChild(1);

        // Đo kích thước trực tiếp từ thông số Sprite thay vì bounds để tránh bug
        SpriteRenderer sr = bg1.GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            // Chiều cao gốc x tỉ lệ Scale Y
            bgHeight = (sr.sprite.rect.height / sr.sprite.pixelsPerUnit) * bg1.localScale.y;
        }

        // Đặt vị trí xuất phát tuyệt đối
        bg1.localPosition = new Vector3(0, 0, 0);
        bg2.localPosition = new Vector3(0, bgHeight, 0);
    }

    void Update()
    {
        if (bgHeight <= 0.01f) return;

        // Trôi xuống
        float moveY = scrollSpeed * Time.deltaTime;
        bg1.localPosition += Vector3.down * moveY;
        bg2.localPosition += Vector3.down * moveY;

        // Khi vượt quá đáy, nhảy lên đỉnh một khoảng đúng bằng (2 * bgHeight)
        if (bg1.localPosition.y <= -bgHeight)
        {
            bg1.localPosition += new Vector3(0, bgHeight * 2f, 0);
        }

        if (bg2.localPosition.y <= -bgHeight)
        {
            bg2.localPosition += new Vector3(0, bgHeight * 2f, 0);
        }
    }
}
