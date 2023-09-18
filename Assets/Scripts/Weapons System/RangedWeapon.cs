using UnityEngine;

public class RangedWeapon : Weapon<RangedWeaponConfig>  
{
    [SerializeField]
    private int remainingProjectiles;
    public int RemainingProjectiles => remainingProjectiles;

    private void Awake()
    {
        remainingProjectiles = WeaponConfig.MaxProjectilesCount;
    }

    public override void Use()
    {
        if (remainingProjectiles < 1)
            return;

        Debug.Log($"Inflicted {Config.Damage} points of ranged damage");
        remainingProjectiles--;
    }
}
