using UnityEngine;

public class EnemyImproved : MonoBehaviour
{
    public float shotDelay;
    public float speed;
    public float angle;
    public GameObject enemyExplosion;
    public GameObject laserShot;
    public Transform laserGun;
    GameObject player;
    Rigidbody enemyImproved;
    float nextShotTime;
    void Start()
    {
        enemyImproved = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerShip");

        enemyImproved.velocity = new Vector3(angle, 0, -speed);
    }

    void Update()
    {
        if (Time.time > nextShotTime && player != null)
        {
            var targetDir = player.transform.position - transform.position;
            var forward = player.transform.forward;
            float angleBetween = Vector3.SignedAngle(targetDir, forward, Vector3.up);
            angleBetween *= -1;

            Instantiate(laserShot, laserGun.position, Quaternion.Euler(0,angleBetween,0));
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
