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

    protected override void DoUse()
    {
        if (remainingProjectiles < 1)
            return;

        var projectile = ProjectilesSpawner.SpawnProjectile(
            WeaponConfig.ProjectileTemplate,
            projectilesShootingPoint);
        projectile.Shoot();

        //Debug.Log($"Inflicted {Config.Damage} points of ranged damage");
        remainingProjectiles--;
    }
}
