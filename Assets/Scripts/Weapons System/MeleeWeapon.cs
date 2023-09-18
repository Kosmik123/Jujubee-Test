using UnityEngine;

public class MeleeWeapon : Weapon<MeleeWeaponConfig>
{
    public override void Use()
    {

        Debug.Log($"Inflicted {Config.Damage} point of ranged damage");
    }
}
