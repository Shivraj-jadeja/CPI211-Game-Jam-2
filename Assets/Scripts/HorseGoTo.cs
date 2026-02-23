using UnityEngine;

public class HorseGoTo: MonoBehaviour
{
    public Transform sky;
    public float speed = 3f; 

    void Update()
    {
        if (sky == null) {
            return;
        }

        Vector3 skyPos = new Vector3(
            sky.position.x,
            sky.position.y,
            sky.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            skyPos,
            speed * Time.deltaTime
        );
    }
}