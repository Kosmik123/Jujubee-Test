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

    private readonly Dictionary<WeaponConfig, GameObject> weaponObjects = new Dictionary<WeaponConfig, GameObject>();

    private void Awake()
    {
        foreach (var weapon in weapons)
        {
            var weaponObject = SpawnModel(weapon);
            weaponObject.SetActive(false);
            weaponObjects.Add(weapon, weaponObject);
        }

        if (CurrentWeapon != null)
            weaponObjects[CurrentWeapon].SetActive(true);
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
        weaponObjects.Add(weapon, SpawnModel(weapon));
        OnWeaponAdded(weapon);
    }

    private void UseWeapon()
    {
        var weapon = CurrentWeapon;
        if (weapon == null)
            return;
 
        Debug.Log($"Used weapon {weapon.Name} and inflicted {weapon.Damage} damage");
    }

    private void ChangeWeapon()
    {
        if (CurrentWeapon != null)
            weaponObjects[CurrentWeapon].SetActive(false);

        currentWeaponIndex++;
        currentWeaponIndex %= weapons.Count;
        weaponObjects[CurrentWeapon].SetActive(true);
        
        OnWeaponChanged?.Invoke(CurrentWeapon);
    }

    public GameObject SpawnModel(WeaponConfig weapon)
    {
        return Instantiate(weapon.Model, weaponHolder);
    }
}
