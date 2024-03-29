﻿using UnityEngine;

public class WeaponControllerUI : MonoBehaviour
{
    [SerializeField]
    private WeaponController controller;

    [Header("UI Elements")]
    [SerializeField]
    private WeaponDisplayWithLabel weaponWindow;
    [SerializeField]
    private WeaponsListDisplay weaponsListDisplay;
    [SerializeField]
    private AmmoDisplay ammoDisplay;

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
        HandleChangedWeapon(controller.CurrentWeapon);
        weaponsListDisplay.Refresh();
    }

    private void OnEnable()
    {
        controller.OnWeaponChanged += HandleChangedWeapon;
        controller.OnWeaponAdded += HandleNewWeapon;
        controller.OnWeaponUsed += Controller_OnWeaponUsed;
    }

    private void HandleNewWeapon(Weapon weapon)
    {
        weaponsListDisplay.AddNewListItem(weapon);
    }

    private void HandleChangedWeapon(Weapon newWeapon)
    {
        weaponWindow.Weapon = newWeapon;
        if (newWeapon is RangedWeapon)
        {
            ammoDisplay.gameObject.SetActive(true);
            ammoDisplay.Refresh(newWeapon);
        }
        else
        {
            ammoDisplay.gameObject.SetActive(false);
        }
        weaponsListDisplay.UpdateCursorPosition();
    }

    private void Controller_OnWeaponUsed(Weapon weapon)
    {
        ammoDisplay.Refresh(weapon);
    }

    private void OnDisable()
    {
        controller.OnWeaponChanged -= HandleChangedWeapon;
        controller.OnWeaponAdded -= HandleNewWeapon;
        controller.OnWeaponUsed -= Controller_OnWeaponUsed;
    }
}
