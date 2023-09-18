using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ammoLabel;

    public void Refresh(Weapon weapon)
    {
        if (gameObject.activeInHierarchy == false)
            return;

        if (weapon is RangedWeapon rangedWeapon)
        {
            ammoLabel.text = $"{rangedWeapon.RemainingProjectiles}/{rangedWeapon.WeaponConfig.MaxProjectilesCount}";
        }
    }
}
