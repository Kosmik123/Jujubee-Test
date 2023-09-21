using System.Collections;
using UnityEngine;

public class MeleeWeapon : Weapon<MeleeWeaponConfig>
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackDelay;
    public float AttackDelay
    {
        get => attackDelay;
        set
        {
            attackDelay = value;
            wait = new WaitForSeconds(attackDelay);
        }
    }

    private readonly Collider[] hitColliders = new Collider[5];
    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(attackDelay);
    }

    private void Reset()
    {
        attackPoint = transform;
    }

    public override void Use()
    {
        StopAllCoroutines();
        var endPoint = attackPoint.position + attackPoint.forward * WeaponConfig.AttackRange;
        int hitCount = Physics.OverlapCapsuleNonAlloc(attackPoint.position, endPoint, 0.5f, hitColliders, WeaponConfig.AttackedLayers);
        for (int i = 0; i < hitCount; i++)
        {
            var enemy = hitColliders[i].GetComponentInParent<DamagableObject>();
            if (enemy != null)
                StartCoroutine(AttackAfterDelayCo(enemy));
        }
        CallUseEvent();
    }

    private IEnumerator AttackAfterDelayCo(DamagableObject enemy)
    {
        yield return wait;
        enemy.Damage(Config.Damage);
    }

    private void OnValidate()
    {
        AttackDelay = AttackDelay;
    }
}
