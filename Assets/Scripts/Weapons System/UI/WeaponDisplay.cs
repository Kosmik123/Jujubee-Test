using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private Image image;
    
    private Weapon weapon;
    public Weapon Weapon
    {
        get => weapon; 
        set
        {
            weapon = value;
            gameObject.SetActive(weapon != null);
            if (weapon == null)
                return;

            label.text = weapon.Config.Name;
            image.sprite = weapon.Config.Icon;
        }
    }

    private void Reset()
    {
        label = GetComponentInChildren<TextMeshProUGUI>(); 
    }
}
