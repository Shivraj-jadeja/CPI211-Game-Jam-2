using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileAI: MonoBehaviour
{
    public Transform horse;
    public float speed = 1.5f;
    public float groundY = 0f; 
    public float stopDistance = 5f;

    void Update()
    {
        if (horse == null) {
            return;
        }

        Vector3 horsePos = new Vector3(
            horse.position.x,
            groundY,
            horse.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            horsePos,
            speed * Time.deltaTime
        );


       Vector3 lookDir = horsePos - transform.position;
        lookDir.y = 0f; 

    if (lookDir != Vector3.zero)
    {
        transform.rotation = Quaternion.LookRotation(lookDir);
    }

    float sqrDistance = (horse.position - transform.position).sqrMagnitude;

    if (sqrDistance <= stopDistance * stopDistance)
    {
        SceneManager.LoadSceneAsync(3);
    }
    }
}