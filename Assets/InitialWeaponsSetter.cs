using System.Collections.Generic;
using UnityEngine;

public class InitialWeaponsSetter : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController;

    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        foreach (var weapon in weapons)
            weaponController.AddWeapon(weapon);
    }
}
