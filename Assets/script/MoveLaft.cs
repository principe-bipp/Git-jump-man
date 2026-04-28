using UnityEngine;

public class MoveLaft : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.left *  speed * Time.deltaTime);
    }





}
