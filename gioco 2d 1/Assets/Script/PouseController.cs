using UnityEngine;
public class PauseController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GameManager.Instance.TogglePause(); 
        }
    }
}

