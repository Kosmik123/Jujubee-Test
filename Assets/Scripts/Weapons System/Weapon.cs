using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract WeaponConfig Config { get; }
    public abstract void Use();
}

public abstract class Weapon<T> : Weapon where T : WeaponConfig
{
    [SerializeField]
    private T config;
    public T WeaponConfig => config;
    public override WeaponConfig Config => WeaponConfig;
}
