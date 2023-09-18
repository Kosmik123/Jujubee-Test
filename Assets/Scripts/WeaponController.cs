using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon> OnWeaponChanged;

    [SerializeField]
    private Weapon currentWeapon;

    public Weapon CurrentWeapon
    {
        get => currentWeapon;
        set
        {
            currentWeapon = value;
            OnWeaponChanged?.Invoke(currentWeapon);
        }
    }
}
