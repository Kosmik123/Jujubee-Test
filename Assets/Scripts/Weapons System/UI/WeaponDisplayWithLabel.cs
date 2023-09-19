using TMPro;
using UnityEngine;

public class WeaponDisplayWithLabel : WeaponDisplay
{
    [SerializeField]
    private TextMeshProUGUI label;

    public override void SetWeapon(Weapon weapon)
    {
        base.SetWeapon(weapon);
        if (weapon != null)
            label.text = weapon.Config.Name;
    }

    private void Reset()
    {
        label = GetComponentInChildren<TextMeshProUGUI>(); 
    }
}
