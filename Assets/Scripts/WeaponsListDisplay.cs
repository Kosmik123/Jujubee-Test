using UnityEngine;
using UnityEngine.Pool;

public class WeaponsListDisplay : MonoBehaviour
{
    [SerializeField]
    private WeaponListItem listItemTemplate;

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

    public void Refresh()
    {
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
