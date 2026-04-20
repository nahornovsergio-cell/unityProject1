using UnityEngine;

public class BolleSpownManger : MonoBehaviour
{
    [SerializeField] GameObject BollePrefab;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    private float nextTime = -1;
    Transform[] list;
    void Start()
    {
        list = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime < 0)
        {
            int i = Random.Range(0, list.Length);
            var g = Instantiate(BollePrefab);
            //var t
        }
    }
}
