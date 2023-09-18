using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<WeaponConfig> OnWeaponChanged;
    public event Action<WeaponConfig> OnWeaponAdded;

    [SerializeField]
    private Transform weaponHolder;

    [SerializeField]
    private int currentWeaponIndex;
    public WeaponConfig CurrentWeapon => (currentWeaponIndex < 0 || currentWeaponIndex >= weapons.Count) ? null : weapons[currentWeaponIndex];

    [SerializeField]
    private List<WeaponConfig> weapons = new List<WeaponConfig>();
    public IReadOnlyList<WeaponConfig> Weapons => weapons;

    private readonly Dictionary<WeaponConfig, WeaponBehavior> weaponBehaviors = new Dictionary<WeaponConfig, WeaponBehavior>();

    private void Awake()
    {
        foreach (var weapon in weapons)
        {
            var weaponBehavior = SpawnModel(weapon);
            weaponBehavior.gameObject.SetActive(false);
            weaponBehaviors.Add(weapon, weaponBehavior);
        }

        if (CurrentWeapon != null)
            weaponBehaviors[CurrentWeapon].gameObject.SetActive(true);
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

    public void AddWeapon(WeaponConfig weapon)
    {
        if (weapons.Contains(weapon))
            return;

        weapons.Add(weapon);
        weaponBehaviors.Add(weapon, SpawnModel(weapon));
        OnWeaponAdded(weapon);
    }

    private void UseWeapon()
    {
        var weapon = CurrentWeapon;
        if (weapon == null)
            return;

        weaponBehaviors[weapon].Use();
    }

    private void ChangeWeapon()
    {
        if (CurrentWeapon != null)
            weaponBehaviors[CurrentWeapon].gameObject.SetActive(false);

        currentWeaponIndex++;
        currentWeaponIndex %= weapons.Count;
        weaponBehaviors[CurrentWeapon].gameObject.SetActive(true);
        
        OnWeaponChanged?.Invoke(CurrentWeapon);
    }

    public WeaponBehavior SpawnModel(WeaponConfig weapon)
    {
        return Instantiate(weapon.Model, weaponHolder);
    }
}
