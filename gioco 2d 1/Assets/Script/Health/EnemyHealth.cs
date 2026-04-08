public class EnemyHealth : Health
{
    protected override void Die()
    {
        // Сообщаем менеджеру, что враг убит
        if (GameManager.Instance != null)
        {
            GameManager.Instance.EnemyKilled(gameObject);
        }
       
        base.Die(); // Вызываем базовое уничтожение
    }
}