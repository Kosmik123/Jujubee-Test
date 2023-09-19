using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float stopDistance;

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
}
