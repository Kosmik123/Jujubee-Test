using UnityEngine;

public class MeleeWeaponBehavior : WeaponBehavior
{
    public override void Use()
    {
        Debug.Log("Used melee weapon");
    }
}
