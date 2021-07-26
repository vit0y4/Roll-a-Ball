using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            float newEnemySpawnTime = Time.time + secondsBetweenSpawn;
            float posX = Random.Range(-8, 8);
            ObjectPooler.Instance.SpawnFromPool("Enemy", new Vector3(posX,transform.position.y,transform.position.z), Quaternion.identity);
        }
    }
}