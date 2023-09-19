using UnityEngine;

public class MeleeWeapon : Weapon<MeleeWeaponConfig>
{
    protected override void DoUse()
    {
        Debug.Log($"Inflicted {Config.Damage} points of melee damage");
    }
}
