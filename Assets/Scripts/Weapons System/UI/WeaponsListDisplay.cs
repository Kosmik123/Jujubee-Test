using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsListDisplay : MonoBehaviour
{
    [SerializeField]
    private WeaponListItem listItemTemplate;
    [SerializeField]
    private Image windowImage;
    [SerializeField]
    private Transform itemsContainer;
    [SerializeField]
    private Image activeItemCursor;

    private WeaponController weaponController;

    private readonly Dictionary<Weapon, WeaponListItem> listItemsByWeapon = new Dictionary<Weapon, WeaponListItem>();

    public void Init(WeaponController weaponController)
    {
        this.weaponController = weaponController;
        Refresh();
    }

    public void AddNewListItem(Weapon weapon)
    {
        if (listItemsByWeapon.ContainsKey(weapon))
            return;

        var listItem = SpawnListItem();
        listItem.SetWeapon(weapon);
        listItemsByWeapon.Add(weapon, listItem);
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        bool isVisible = weaponController.Weapons.Count > 0;
        activeItemCursor.enabled = isVisible;
        windowImage.enabled = isVisible;
        UpdateCursorPosition();
    }

    public void UpdateCursorPosition()
    {
        if (weaponController.CurrentWeapon == null) 
            return;

        StartCoroutine(SetCursorPositionAfterLayoutRebuiltCo());
    }

    private IEnumerator SetCursorPositionAfterLayoutRebuiltCo()
    {
        yield return null;
        var position = listItemsByWeapon[weaponController.CurrentWeapon].transform.position;
        activeItemCursor.transform.position = position;
    }

    private WeaponListItem SpawnListItem()
    {
        var weaponListItem = Instantiate(listItemTemplate, itemsContainer);
        return weaponListItem;
    }
}
