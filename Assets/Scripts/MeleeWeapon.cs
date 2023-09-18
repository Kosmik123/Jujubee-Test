using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    [SerializeField]
    private float attackRange;
    public float AttackRange => attackRange;
}
