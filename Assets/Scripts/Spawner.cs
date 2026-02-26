using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject cactusPrefab; // This has to be a prefab

    public float minSpawnTime = 10f;
    public float maxSpawnTime = 20f;

    public float spawnRadius = 5f;

    float nextSpawnTime;

    
    void Start()
    {
        nextSpawn();
    }

    
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            nextSpawn();
        }
    }

    void nextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(cactusPrefab, transform.position, transform.rotation);
        enemy.tag = "Enemy"; // Added to be detected by bullet
        
        Transform rootNode = enemy.transform.GetChild(0);
        
        rootNode.localRotation = Quaternion.Euler(-90f, 0f, 0f);

         enemy.transform.localScale = new Vector3(8f, 8f, 8f);
         
         HostileAI ai = enemy.AddComponent<HostileAI>();

         EnterZone ai2 = enemy.AddComponent<EnterZone>();

         ai.horse = GameObject.FindWithTag("Horse").transform; 
    }
}
