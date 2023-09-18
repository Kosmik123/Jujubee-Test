using System;
using UnityEngine;

public class WeaponControllerUI : MonoBehaviour
{
    [SerializeField]
    private WeaponController controller;

    [Header("UI Elements")]
    [SerializeField]
    private WeaponDisplay weaponWindow;
    [SerializeField]
    private WeaponsListDisplay weaponsListDisplay;

    private void Reset()
    {
        controller = FindObjectOfType<WeaponController>();
    }

    private void Awake()
    {
        weaponsListDisplay.Init(controller);
    }

    private void Start()
    {
        RefreshDisplayedWeapon(controller.CurrentWeapon);
        weaponsListDisplay.Refresh();
    }

    private void OnEnable()
    {
        controller.OnWeaponChanged += RefreshDisplayedWeapon;
        controller.OnWeaponAdded += RefreshWeaponsList;
    }

    private void RefreshWeaponsList(WeaponConfig weapon)
    {
        weaponsListDisplay.Refresh();
    }

    private void RefreshDisplayedWeapon(WeaponConfig newWeapon)
    {
        weaponWindow.Weapon = newWeapon;
    }

    private void OnDisable()
    {
        controller.OnWeaponChanged -= RefreshDisplayedWeapon;
        controller.OnWeaponAdded -= RefreshWeaponsList;
    }
}
