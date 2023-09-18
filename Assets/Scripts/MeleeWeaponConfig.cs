using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Melee Weapon")]
public class MeleeWeaponConfig : WeaponConfig
{
    [SerializeField]
    private float attackRange;
    public float AttackRange => attackRange;
}
