using System;
using UnityEngine;

public class Serratura : MonoBehaviour
{
    int cout = 3;
    public event Action raccoltoTutto;
    public void accettatore()
    {
        cout--;
        if(cout == 0)
        {
            raccoltoTutto?.Invoke();
        }
    }

}
