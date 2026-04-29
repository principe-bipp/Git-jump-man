using UnityEngine;

public class Destroe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Destroy(other.gameObject);
        }
    }
}
