using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    bool counted;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (counted) return;
        if (!other.CompareTag("Player")) return;
        counted = true;
        GameManager.Instance.AddScore(1);
    }
}