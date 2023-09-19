using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    protected Image image;

    protected Weapon weapon;
    public Weapon Weapon
    {
        get => weapon;
        set
        {
            weapon = value;
            gameObject.SetActive(weapon != null);
            if (weapon != null) 
                FillUIElements();
        }
    }

    protected virtual void FillUIElements()
    {
        image.sprite = weapon.Config.Icon;
    }
}
