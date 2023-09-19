using TMPro;
using UnityEngine;

public class WeaponDisplayWithLabel : WeaponDisplay
{
    [SerializeField]
    private TextMeshProUGUI label;

    protected override void FillUIElements()
    {
        base.FillUIElements();
        label.text = weapon.Config.Name;
    }

    private void Reset()
    {
        label = GetComponentInChildren<TextMeshProUGUI>(); 
    }
}
