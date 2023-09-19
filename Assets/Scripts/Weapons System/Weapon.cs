using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event System.Action OnUsed;

    public abstract WeaponConfig Config { get; }

    public abstract void Use();

    protected void CallUseEvent()
    {
        OnUsed?.Invoke();   
    }
}

public abstract class Weapon<T> : Weapon where T : WeaponConfig
{
    [SerializeField]
    private T config;
    public T WeaponConfig => config;
    public override WeaponConfig Config => WeaponConfig;
}
