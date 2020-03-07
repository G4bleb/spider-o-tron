using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int initialSpiderCount;
    public float spiderScale, spawnRadius;
    public GameObject spider;
    void Start()
    {
        GenerateSpiders();
    }

    void GenerateSpiders()
    {
        for (int i = 0; i < initialSpiderCount; i++)
        {
            SpawnEntityOnField(spider);
        }
    }

    public void SpawnSpider()
    {
        SpawnEntityOnField(spider);
    }
    void SpawnEntityOnField(GameObject obj)
    {
        Vector2 spawnPositionXZ = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPositionXYZ = new Vector3(spawnPositionXZ.x, transform.position.y, spawnPositionXZ.y);
        Vector3 scale = new Vector3(spiderScale,spiderScale,spiderScale);
        
        obj.transform.localScale = scale;
        Instantiate(obj, spawnPositionXYZ, Quaternion.identity);
    }
}
