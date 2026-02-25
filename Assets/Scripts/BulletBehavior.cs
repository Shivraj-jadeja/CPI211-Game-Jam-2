using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Bullet prefab 
    void Start()
    {
        
    }

    // UNFINISHED: Destroy command should be triggered by collision
    // If bullet collides with environment, destroy; if with enemy, destroy and add point
    void Update()
    {
        if (Time.deltaTime > 3f) Destroy(gameObject);
    }
}