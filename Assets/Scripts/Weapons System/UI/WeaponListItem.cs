using UnityEngine;
using UnityEngine.UI;

public class WeaponListItem : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void SetWeapon(Weapon weapon)
    {
        gameObject.SetActive(weapon != null);
        if (weapon == null)
            return;
            
        image.sprite = weapon.Config.Icon;
    }
}
