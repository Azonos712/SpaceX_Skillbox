using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float shotDelay;
    public float speed;
    public GameObject laserShot;
    public Transform laserGun;
    public GameObject enemyExplosion;
    float nextShotTime;

    Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();

        enemy.velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(laserShot, laserGun.position, Quaternion.Euler(0, 0, 0));
            nextShotTime = Time.time + shotDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Shield" || other.tag == "Player")
            return;

        Destroy(gameObject);
        Destroy(other.gameObject);
        //Instantiate(enemyExplosion, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
    }
}
