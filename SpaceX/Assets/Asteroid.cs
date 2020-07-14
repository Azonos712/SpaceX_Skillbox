using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float minSpeed, maxSpeed;
    public float rotationSpeed;
    Rigidbody asteroid;
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;//угловая скорость

        asteroid.velocity = new Vector3(0, 0, -Random.Range(minSpeed, maxSpeed));
    }

    //сработает при входе
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Shield" || other.tag == "Player")
            return;

        Destroy(gameObject);
        Destroy(other.gameObject);
        //Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }
}
