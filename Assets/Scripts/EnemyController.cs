using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event System.Action<DamagableObject> OnDied;
    public event System.Action<DamagableObject, int> OnDamaged;

    [SerializeField]
    private DamagableObject damagableObject;
    public DamagableObject DamagableObject => damagableObject;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform target;
    public Transform Target 
    {
        get => target; 
        set => target = value; 
    }

    [SerializeField]
    private float stopDistance;

    private void Reset()
    {
        damagableObject = GetComponent<DamagableObject>();    
    }

    private void OnEnable()
    {
        damagableObject.OnDied += CallDiedEvent;
        damagableObject.OnHealthChanged += CallDamagedEvent;
    }

    private void CallDamagedEvent(int healthChange)
    {
        if (healthChange < 0)
            OnDamaged?.Invoke(damagableObject, healthChange);
    }

    private void CallDiedEvent()
    {
        OnDied?.Invoke(damagableObject);
    }

    private void Update()
    {
        LookAtTarget();

        Vector3 direction = (target.position - transform.position);
        if (direction.sqrMagnitude > stopDistance * stopDistance)
        {
            var motion = moveSpeed * Time.deltaTime * direction.normalized;
            transform.Translate(motion, Space.World);
        }
    }

    private void LookAtTarget()
    {
        var position = GetHorizontalPosition(transform);
        var targetPosition = GetHorizontalPosition(target);
        var direction = targetPosition - position;

        transform.forward = direction;
    }

    private Vector3 GetHorizontalPosition(Transform transform)
    {
        Vector3 horizontalPosition = transform.position;
        horizontalPosition.y = 0;
        return horizontalPosition;
    }

    private void OnDisable()
    {
        damagableObject.OnDied -= CallDiedEvent;
        damagableObject.OnHealthChanged -= CallDamagedEvent;
    }
}
