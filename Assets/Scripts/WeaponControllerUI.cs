using UnityEngine;

public class WeaponControllerUI : MonoBehaviour
{
    [SerializeField]
    private WeaponController controller;

    [Header("UI Elements")]
    [SerializeField]
    private WeaponDisplay weaponWindow;

    private void Reset()
    {
        controller = FindObjectOfType<WeaponController>();
    }

    private void Start()
    {
        Refresh(controller.CurrentWeapon);
    }

    private void OnEnable()
    {
        controller.OnWeaponChanged += Refresh;
    }

    private void Refresh(Weapon newWeapon)
    {
        weaponWindow.Weapon = newWeapon;
    }

    private void OnDisable()
    {
        controller.OnWeaponChanged -= Refresh;
    }
}
