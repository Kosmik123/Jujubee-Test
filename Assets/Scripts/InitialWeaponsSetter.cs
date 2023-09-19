using System.Collections.Generic;
using UnityEngine;

public class InitialWeaponsSetter : MonoBehaviour
{
    [Header("To Link")]
    [SerializeField]
    private WeaponController weaponController;
    [SerializeField]
    private WeaponsSpawner weaponsSpawner;
    [SerializeField]
    private ProjectilesSpawner projectilesSpawner;

    [Header("Settings")]
    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            var weaponInstance = weaponsSpawner.Spawn(weapon);
            if (weaponInstance is RangedWeapon rangedWeapon)
            {
                rangedWeapon.ProjectilesSpawner = projectilesSpawner;
            }
            weaponController.AddWeapon(weaponInstance);
        }
    }
}
