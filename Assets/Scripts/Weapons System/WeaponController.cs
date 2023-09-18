using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon> OnWeaponChanged;
    public event Action<Weapon> OnWeaponAdded;

    [SerializeField]
    private Transform weaponHolder;

    [SerializeField]
    private int currentWeaponIndex;
    public Weapon CurrentWeapon => (currentWeaponIndex < 0 || currentWeaponIndex >= weapons.Count) ? null : weapons[currentWeaponIndex];

    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();
    public IReadOnlyList<Weapon> Weapons => weapons;

    private void Awake()
    {
        foreach (var weapon in weapons)
        {
            var weaponBehavior = SpawnModel(weapon);
            weaponBehavior.gameObject.SetActive(false);
        }

        if (CurrentWeapon != null)
            CurrentWeapon.gameObject.SetActive(true);
    }

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
        var weapon = CurrentWeapon;
        if (weapon == null)
            return;

        CurrentWeapon.Use();
    }

    private void ChangeWeapon()
    {
        if (CurrentWeapon != null)
            CurrentWeapon.gameObject.SetActive(false);

        currentWeaponIndex++;
        currentWeaponIndex %= weapons.Count;
        CurrentWeapon.gameObject.SetActive(true);
        
        OnWeaponChanged?.Invoke(CurrentWeapon);
    }

    public Weapon SpawnModel(Weapon weaponTemplate)
    {
        return Instantiate(weaponTemplate, weaponHolder);
    }
}
