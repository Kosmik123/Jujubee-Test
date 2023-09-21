using System.Collections;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public event System.Action OnMovementEnded;

    [SerializeField]
    private TMP_Text label;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private AnimationCurve opacityCurve;

    public string Text
    {
        get => label.text;
        set => label.text = value;
    }

    public void StartMoving()
    {
        StopAllCoroutines();
        StartCoroutine(MovingCo());
    }

    private IEnumerator MovingCo()
    {
        float progress = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + moveDistance * Vector3.up;
        while (progress < 1)
        {
            yield return null;
            progress += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, progress);
            var color = label.color;
            color.a = opacityCurve.Evaluate(progress);
            label.color = color;
        }
        OnMovementEnded?.Invoke();
    }

    private void OnDestroy()
    {
        OnMovementEnded = null;
    }
}
