using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private new Animation animation;

    private void OnEnable()
    {
        weapon.OnUsed += PlayAnimation;
    }

    [ContextMenu("Play")]
    private void PlayAnimation()
    {
        if (animation.isPlaying)
            animation.Stop();
        animation.Play();
    }

    private void OnDisable()
    {
        weapon.OnUsed -= PlayAnimation;
    }
}
