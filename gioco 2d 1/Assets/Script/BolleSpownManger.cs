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
            nextTime = Random.Range(minTime, maxTime);
            int i = Random.Range(0, list.Length);
            var a = list[i];
            var g = Instantiate(BollePrefab, a);
        }
        nextTime -= Time.deltaTime;
    }
}
