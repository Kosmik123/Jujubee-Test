using UnityEngine;
using UnityEngine.Pool;

public class DamagePopupsManager : MonoBehaviour
{
    [SerializeField]
    private EnemiesManager enemiesManager;
    [SerializeField]
    private DamagePopup popupTemplate;

    private ObjectPool<DamagePopup> popupsPool;

    private void Awake()
    {
        popupsPool = new ObjectPool<DamagePopup>(
            CreatePopup,
            popup => popup.gameObject.SetActive(true),
            popup => popup.gameObject.SetActive(false));
    }

    private DamagePopup CreatePopup()
    {
        var popup = Instantiate(popupTemplate);
        popup.OnMovementEnded += () => popupsPool.Release(popup);
        return popup;
    }

    private void OnEnable()
    {
        enemiesManager.OnEnemyDamaged += ShowDamagePopup;
    }

    private void ShowDamagePopup(DamagableObject damagable, int damage)
    {
        var popup = popupsPool.Get();
        popup.Text = damage.ToString();
        popup.transform.position = damagable.transform.position + 2 * Vector3.up;
        popup.StartMoving();
    }

    private void OnDisable()
    {
        enemiesManager.OnEnemyDamaged -= ShowDamagePopup;
    }
}
