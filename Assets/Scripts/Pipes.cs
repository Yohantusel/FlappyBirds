using UnityEngine;

public class PipePair : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -10f;
    bool dying;

    void Update()
    {
        if (dying) return;

        transform.position += Vector3.left * (speed * Time.deltaTime);

        if (transform.position.x <= destroyX)
        {
            dying = true;
            Destroy(gameObject);
        }
    }
}

    
