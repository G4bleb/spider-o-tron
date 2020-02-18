using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpiders : MonoBehaviour
{
    // Start is called before the first frame update
    public int nbSpiderInit, SpawnRangeXmin, SpawnRangeXmax, SpawnRangeZmin, SpawnRangeZmax, SpawnY;
    public float SpiderScale;
    private GameObject spider;
    void Start()
    {
        GenerateSpider();
    }

    void GenerateSpider()
    {
        for (int i = 0; i < nbSpiderInit; i++)
        {
            SpawnEntityOnField(this.spider);
            Debug.Log("Spawned Spider");
        }
    }
    void SpawnEntityOnField(GameObject obj)
    {
        float spawnZ = Random.Range(SpawnRangeZmin, SpawnRangeZmax);
        float spawnX = Random.Range(SpawnRangeXmin, SpawnRangeXmax);

        Vector3 spawnPosition = new Vector3(spawnX, SpawnRangeY, spawnZ);
        Vector3 scale = new Vector3(SpiderScale,SpiderScale,SpiderScale);
        //obj.AddComponent(walking);
        obj.transform.localScale = scale;
        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}
