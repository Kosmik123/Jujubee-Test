using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private Image image;
    
    private WeaponConfig weapon;
    public WeaponConfig Weapon
    {
        get => weapon; 
        set
        {
            weapon = value;
            gameObject.SetActive(weapon != null);
            if (weapon == null)
                return;

            label.text = weapon.Name;
            image.sprite = weapon.Icon;
        }
    }

    private void Reset()
    {
        label = GetComponentInChildren<TextMeshProUGUI>(); 
    }
}
