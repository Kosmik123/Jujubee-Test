using UnityEngine;

public class WeaponControllerUI : MonoBehaviour
{
    [SerializeField]
    private WeaponController controller;

    private void Reset()
    {
        controller = FindObjectOfType<WeaponController>();
    }

    private void OnEnable()
    {
        controller.OnWeaponChanged += Refresh;
    }

    private void Refresh(Weapon newWeapon)
    {

    }

    private void OnDisable()
    {
        controller.OnWeaponChanged -= Refresh;
    }
}
