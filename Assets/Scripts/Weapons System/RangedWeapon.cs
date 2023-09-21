using UnityEngine;

public class RangedWeapon : Weapon<RangedWeaponConfig>  
{
    private int remainingProjectiles;
    public int RemainingProjectiles => remainingProjectiles;

    [SerializeField]
    private Transform projectilesShootingPoint;

    private void Awake()
    {
        remainingProjectiles = WeaponConfig.MaxProjectilesCount;
    }

    public ProjectilesSpawner ProjectilesSpawner { get; set; }

    public override void Use()
    {
        if (remainingProjectiles < 1)
            return;

        remainingProjectiles--;
        var projectile = ProjectilesSpawner.SpawnProjectile(
            WeaponConfig.ProjectileTemplate,
            projectilesShootingPoint);
        projectile.Shoot(Config.Damage);

        CallUseEvent();
    }
}
