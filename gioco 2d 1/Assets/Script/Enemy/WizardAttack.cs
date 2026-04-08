using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab; // Сюда перетащи префаб фаербола
    [SerializeField] private Transform firePoint;     // Пустая точка перед колдуном, откуда летит магия
    [SerializeField] private float attackRate = 2f;    // Раз в 2 секунды
    private float nextAttackTime = 0f;

    [SerializeField] private Transform playerTransform;

    void Update()
    {
        if (playerTransform == null) return;

        // Поворачиваем колдуна (или точку стрельбы) в сторону игрока
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Стреляем по таймеру
        if (Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + attackRate;
        }
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }
}