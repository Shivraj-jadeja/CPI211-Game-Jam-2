using UnityEngine.SceneManagement;
using UnityEngine;

public class EnterZone : MonoBehaviour
{
    public Transform objectA; 
    public Transform objectB; 
    public float maxDistance = 5f; 

    void Update()
    {
        float distance = Vector3.Distance(objectA.position, objectB.position);
        if (distance <= maxDistance)
        {
            Debug.Log("Object B is close to Object A!");
        }
    }
}