using UnityEngine;

public class FallingFish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogWarning("ScoreManager not found!");
            return;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Fish hit the player - score +10");
            scoreManager.AddScore(10);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Floor"))
        {
            Debug.Log("Fish hit the floor - score -5");
            scoreManager.AddScore(-5);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Fish hit an unknown object: " + other.name);
        }
    }
}
