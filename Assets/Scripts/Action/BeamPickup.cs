using UnityEngine;

public class BeamPickup : MonoBehaviour
{
    [SerializeField] private GameObject beamBarrelPrefabs;

    public GameObject beamBarrelPrefabsChoice => beamBarrelPrefabs;
}
