using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items;
    public float minDelay, maxDelay, spawnAngle;
    float nextLaunchTime;

    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            var positionY = 0;
            var positionZ = transform.position.z;
            var positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2) + transform.position.x;
            Instantiate(items[Random.Range(0, items.Length)], new Vector3(positionX, positionY, positionZ), Quaternion.Euler(0, spawnAngle, 0));
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
