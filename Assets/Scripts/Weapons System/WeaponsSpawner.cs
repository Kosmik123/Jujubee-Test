using UnityEngine;

public class WeaponsSpawner : MonoBehaviour
{
    public Weapon Spawn(Weapon weaponTemplate)
    {
        var weapon = Instantiate(weaponTemplate);
        weapon.gameObject.SetActive(false);
        return weapon;
    }
}
