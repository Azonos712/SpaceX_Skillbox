using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    public float angle;

    //void Start()
    //{
        //GetComponent<Rigidbody>().velocity = new Vector3(angle, 0, speed);
    //}

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
