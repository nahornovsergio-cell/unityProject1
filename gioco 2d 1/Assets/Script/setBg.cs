using UnityEngine;
using UnityEngine.SceneManagement;

public class setBg : MonoBehaviour
{
    [SerializeField] SceneColorData colorsDataBase;
    void Start()
    {
        Camera.main.backgroundColor = colorsDataBase.GetColorForScene(SceneManager.GetActiveScene().name);
    }

    
    void Update()
    {
        
    }
}
