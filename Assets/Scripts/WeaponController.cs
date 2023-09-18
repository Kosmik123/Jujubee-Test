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

    private readonly Dictionary<Weapon, GameObject> weaponObjects = new Dictionary<Weapon, GameObject>();

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

    public void AddWeapon(Weapon weapon)
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

    public GameObject SpawnModel(Weapon weapon)
    {
        return Instantiate(weapon.Model, weaponHolder);
    }
}
