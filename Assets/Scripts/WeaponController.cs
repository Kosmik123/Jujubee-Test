using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon> OnWeaponChanged;
    public event Action<Weapon> OnWeaponAdded;

    [SerializeField]
    private int currentWeaponIndex;
    public Weapon CurrentWeapon => (currentWeaponIndex < 0 || currentWeaponIndex >= weapons.Count) ? null : weapons[currentWeaponIndex];

    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();
    public IReadOnlyList<Weapon> Weapons => weapons;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ChangeWeapon();
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        OnWeaponAdded(weapon);
    }

    private void UseWeapon()
    {
        var weapon = weapons[currentWeaponIndex];
    }

    private void ChangeWeapon()
    {
        currentWeaponIndex++;
        currentWeaponIndex %= weapons.Count;
        OnWeaponChanged?.Invoke(CurrentWeapon);
    }
}
