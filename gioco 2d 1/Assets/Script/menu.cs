using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject pannello;
    public void interrutore()
    {
        bool IsActive = pannello.activeSelf;
        pannello.SetActive(!IsActive);
        
    }
    
    public void stratGame()
    {
        SceneManager.LoadScene(1);
    }
}
