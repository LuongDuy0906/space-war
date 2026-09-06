using UnityEngine;

public class BeamBarrel : MonoBehaviour
{
    [Header("Cấu hình đạn")]
    [SerializeField] private GameObject beamPrefab;
    [SerializeField] private float fireRate = 0.2f;

    private float nextFireTime;

    void Update()
    {
        if (beamPrefab != null && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        // Bắn ra từ chính vị trí và góc quay của nòng súng
        Instantiate(beamPrefab, transform.position, beamPrefab.transform.rotation);
    }
}
