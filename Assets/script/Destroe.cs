using UnityEngine;
using TMPro;
public class Destroe : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText.text = $"Score: {score}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Destroy(other.gameObject);
            scoreText.text = $"Score: {score++}";
        }
    }
}
