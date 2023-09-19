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

    public override void Use()
    {
        if (remainingProjectiles < 1)
            return;


        var projectile = Instantiate(WeaponConfig.ProjectileTemplate,
            projectilesShootingPoint.position, projectilesShootingPoint.rotation);
        projectile.OnMaxDistanceTraveled += Projectile_OnMaxDistanceTraveled;
        projectile.Shoot();

        //Debug.Log($"Inflicted {Config.Damage} points of ranged damage");
        remainingProjectiles--;
    }

    private void Projectile_OnMaxDistanceTraveled(Projectile projectile)
    {
        projectile.OnMaxDistanceTraveled -= Projectile_OnMaxDistanceTraveled;
        Destroy(projectile.gameObject);
    }
}
