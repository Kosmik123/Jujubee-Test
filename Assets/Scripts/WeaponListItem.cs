using UnityEngine;
using UnityEngine.UI;

public class WeaponListItem : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void SetWeapon(Weapon weapon)
    {
        image.sprite = weapon.Icon;
    }
}
