using UnityEngine;

public class HostileAI: MonoBehaviour
{
    public Transform horse;
    public float speed = 3f;
    public float groundY = 0f; 

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
    }
}