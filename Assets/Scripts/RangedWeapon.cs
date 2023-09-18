using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    [SerializeField]
    private float maxDistance;
    public float MaxDistance => maxDistance;

    [SerializeField]
    private int maxProjectilesCount;
    public int MaxProjectilesCount => maxProjectilesCount;

    [SerializeField]
    private GameObject projectileTemplate;
    public GameObject ProjectileTemplate => projectileTemplate;
}
