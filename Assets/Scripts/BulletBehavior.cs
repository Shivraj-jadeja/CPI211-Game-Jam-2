using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehavior : MonoBehaviour
{
    [HideInInspector] public int points = 0; // Not sure what this is for yet
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        // This should end up only triggering if it doesn't hit anything (e.g. shooting up into the sky lol)
        timer += Time.deltaTime;
        if (timer > 3f) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Temporary line -- could delete later
        Debug.Log("Hit " + collision.gameObject.name);

        // Check for a specific tag to perform specific actions.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy that object
            Destroy(collision.gameObject);

            // Add points or whatever here?
            points++;
            Debug.Log(points + " point(s)");
        }

        // Destroy bullet
        Destroy(gameObject);
    }
}