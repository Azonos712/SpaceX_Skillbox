using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float shotDelay;
    public GameObject laserShot;
    public GameObject laserLeftShot;
    public GameObject laserRightShot;
    public Transform laserGun;
    public Transform laserGunLeft;
    public Transform laserGunRight;
    public float tilt;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public GameObject playerExplosion;
    public Text shieldUI;
    Rigidbody player;
    float nextShotTime;
    float nextSideShotTime;
    private int shield;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        shield = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        var clampedX = Mathf.Clamp(player.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(player.position.z, zMin, zMax);

        player.position = new Vector3(clampedX, 0, clampedZ);

        player.rotation = Quaternion.Euler(tilt * player.velocity.z, 0, tilt * -player.velocity.x);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Time.time > nextSideShotTime && Input.GetButton("Fire2"))
        {
            Instantiate(laserLeftShot, laserGunLeft.position, Quaternion.Euler(0, -45, 0));
            Instantiate(laserRightShot, laserGunRight.position, Quaternion.Euler(0, 45, 0));
            nextSideShotTime = Time.time + shotDelay / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "PlayerShot")
            return;

        if (other.tag == "Shield")
        {
            shield++;
            Destroy(other.gameObject);
        }
        else
        {
            if (shield <= 0)
                Destroy(gameObject);

            shield--;
            Destroy(other.gameObject);
        }
        shield = Mathf.Clamp(shield, 0, 100);
        shieldUI.text = "Щиты: " + shield.ToString();
    }

    private void OnDestroy()
    {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
    }
}
