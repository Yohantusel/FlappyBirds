using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePairPrefab; 
    public float spawnInterval = 1.4f;
    public float minCenterY = -1f;    
    public float maxCenterY = 2f;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            if (!GameManager.Instance.Started)
                return;
            _timer = 0f;

            float centerY = Random.Range(minCenterY, maxCenterY);
            var go = Instantiate(
                pipePairPrefab,
                new Vector3(transform.position.x, centerY, 0f),
                Quaternion.identity
            );
        }
    }
}