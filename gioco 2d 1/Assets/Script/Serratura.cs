using System;
using UnityEngine;

public class Serratura : MonoBehaviour
{
    int cout = 3;
    public event Action RaccoltoTutto;
    
    public void Accettatore()
    {
        Debug.Log("Oggetto disattivato");
        Debug.Log("Cout: " + cout);
        cout--;
        if(cout == 0)
        {
            RaccoltoTutto?.Invoke();
        }
    }

}
