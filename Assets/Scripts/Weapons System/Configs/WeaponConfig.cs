using UnityEngine;

public abstract class WeaponConfig : ScriptableObject
{
    [SerializeField]
    private new string name;
    public string Name => name;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon; 

    [SerializeField]
    private int damage;
    public int Damage => damage;

    [SerializeField]
    private Weapon model;
    public Weapon Model => model;
}
