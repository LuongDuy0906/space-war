using System;
using UnityEngine;

public class PlayerBeamManager : MonoBehaviour
{
    [SerializeField] private Transform weaponMountPoint;
    [SerializeField] private GameObject currentBeam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BeamPickup>(out BeamPickup beamPickup))
        {
            EquipBeam(beamPickup.beamBarrelPrefabsChoice);
            Destroy(collision.gameObject);
        }
    }

    private void EquipBeam(GameObject beamPrefabsChoice)
    {
        if (beamPrefabsChoice == null) return;

        // 1. Xóa nòng súng cũ đang gắn trên tàu (currentBeam), KHÔNG xóa beamPrefabsChoice
        if (currentBeam != null)
        {
            Destroy(currentBeam);
        }

        // 2. Xác định điểm gắn súng
        Transform mountTransform = weaponMountPoint != null ? weaponMountPoint : transform;

        // 3. Sinh nòng mới làm con của điểm gắn súng và lưu vào currentBeam
        currentBeam = Instantiate(beamPrefabsChoice, mountTransform.position, mountTransform.rotation, mountTransform);
    }
}