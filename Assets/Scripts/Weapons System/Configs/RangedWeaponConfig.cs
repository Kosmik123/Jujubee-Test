using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged Weapon")]
public class RangedWeaponConfig : WeaponConfig
{
    [SerializeField]
    private int maxProjectilesCount;
    public int MaxProjectilesCount => maxProjectilesCount;

    [SerializeField]
    private Projectile projectileTemplate;
    public Projectile ProjectileTemplate => projectileTemplate;
}
