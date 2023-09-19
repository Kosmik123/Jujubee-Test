using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    protected Image image;

    protected Weapon weapon;

    public virtual void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        gameObject.SetActive(weapon != null);
        if (weapon == null)
            return;
            
        image.sprite = weapon.Config.Icon;
    }
}
