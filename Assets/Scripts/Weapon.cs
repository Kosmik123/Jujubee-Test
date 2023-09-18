using UnityEngine;

public abstract class Weapon : ScriptableObject
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
    private GameObject model;
    public GameObject Model => model;
}
