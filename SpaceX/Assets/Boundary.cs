using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
