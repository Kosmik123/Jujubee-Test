using System.Xml.Schema;
using UnityEngine;

public class MeleeWeapon : Weapon<MeleeWeaponConfig>
{
    [SerializeField]
    private Transform attackPoint;

    private readonly Collider[] hitColliders = new Collider[5];

    private void Reset()
    {
        attackPoint = transform;
    }

    public override void Use()
    {
        Debug.Log($"Inflicted {Config.Damage} points of melee damage");

        var endPoint = attackPoint.position + attackPoint.forward * WeaponConfig.AttackRange;
        int hitCount = Physics.OverlapCapsuleNonAlloc(attackPoint.position, endPoint, 0.5f, hitColliders, WeaponConfig.AttackedLayers);
        for (int i = 0; i < hitCount; i++)
        {
            var enemy = hitColliders[i].GetComponentInParent<EnemyController>();
            if (enemy != null)
                Destroy(enemy.gameObject, 0.5f);
        }
        CallUseEvent();
    }
}
