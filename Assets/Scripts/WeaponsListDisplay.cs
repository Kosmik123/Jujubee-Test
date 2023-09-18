using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class WeaponsListDisplay : MonoBehaviour
{
    [SerializeField]
    private WeaponListItem listItemTemplate;
    [SerializeField]
    private Image windowImage;

    private ObjectPool<WeaponListItem> listItemsPool;
    private WeaponController weaponController;

    private void Awake()
    {
        listItemsPool = new ObjectPool<WeaponListItem>(SpawnListItem);
    }

    public void Init(WeaponController weaponController)
    {
        this.weaponController = weaponController;
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        bool isVisible = weaponController.Weapons.Count > 0;
        windowImage.enabled = isVisible;

        foreach (var weapon in weaponController.Weapons)
        {
            var listItem = listItemsPool.Get();
            listItem.SetWeapon(weapon);
        }
    }

    private WeaponListItem SpawnListItem()
    {
        return Instantiate(listItemTemplate, transform);
    }
}
