using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpiders : MonoBehaviour
{
    // Start is called before the first frame update
    public int InitialSpiderCount;
    public float SpiderScale, SpawnRangeXmin, SpawnRangeXmax, SpawnRangeZmin, SpawnRangeZmax, SpawnY;
    public GameObject Spider;
    void Start()
    {
        // GenerateSpiders();
    }

    void GenerateSpiders()
    {
        for (int i = 0; i < InitialSpiderCount; i++)
        {
            SpawnEntityOnField(Spider);
            Debug.Log("Spawned Spider");
        }
    }

    public void SpawnSpider()
    {
        SpawnEntityOnField(Spider);
    }
    void SpawnEntityOnField(GameObject obj)
    {
        float spawnZ = Random.Range(SpawnRangeZmin, SpawnRangeZmax);
        float spawnX = Random.Range(SpawnRangeXmin, SpawnRangeXmax);

        Vector3 spawnPosition = new Vector3(spawnX, SpawnY, spawnZ);
        Vector3 scale = new Vector3(SpiderScale,SpiderScale,SpiderScale);
        //obj.AddComponent(walking);
        obj.transform.localScale = scale;
        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}
