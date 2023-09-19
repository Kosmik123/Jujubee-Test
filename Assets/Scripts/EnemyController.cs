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

        if ((transform.position - target.position).sqrMagnitude > stopDistance * stopDistance)
        {
            var motion = moveSpeed * Time.deltaTime * Vector3.forward;
            transform.Translate(motion);
        }
    }

    private void LookAtTarget()
    {
        var startPosition = GetHorizontalPosition(transform);
        var targetPosition = GetHorizontalPosition(target);
        var direction = targetPosition - startPosition;

        transform.forward = direction;
    }

    private Vector3 GetHorizontalPosition(Transform transform)
    {
        Vector3 horizontalPosition = transform.position;
        horizontalPosition.y = 0;
        return horizontalPosition;
    }
}
