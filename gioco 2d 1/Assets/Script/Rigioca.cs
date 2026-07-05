using UnityEngine;
using UnityEngine.SceneManagement;

public class Rigioca : MonoBehaviour
{
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void highScreen()
    {
        Debug.Log("hai schiacciato il pulsante");
        SceneManager.LoadScene(1);
    }
}
