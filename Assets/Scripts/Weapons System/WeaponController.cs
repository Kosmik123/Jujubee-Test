using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon> OnWeaponChanged;
    public event Action<Weapon> OnWeaponAdded;
    public event Action<Weapon> OnWeaponUsed;

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
            weapon.gameObject.SetActive(false);

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

    public void AddWeapon(Weapon weaponTemplate)
    {
        var weapon = SpawnModel(weaponTemplate);
        weapons.Add(weapon);
        if (weapons.Count == 1)
            CurrentWeapon.gameObject.SetActive(true);

        OnWeaponAdded?.Invoke(weapon);
    }

    private void UseWeapon()
    {
        var weapon = CurrentWeapon;
        if (weapon == null)
            return;

        CurrentWeapon.Use();
        OnWeaponUsed?.Invoke(weapon);
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
        var weapon = Instantiate(weaponTemplate, weaponHolder);
        weapon.gameObject.SetActive(false);
        return weapon;
    }
}
