using UnityEngine;

[CreateAssetMenu(fileName = "Enemyconfig", menuName = "Scriptable Objects/Enemyconfig")]
public class Enemyconfig : ScriptableObject
{
    public float moveSpeed = 3.5f;
    public int maxHealth = 60;
}
