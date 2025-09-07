using System.Collections;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject bugPrefab;

    public float spawnInterval = 1f;
    public float fastestSpawnInterval = 0.9f;
    public float intervalChangeRate = .25f;
    public float changeRateInterval = 5f;

    public Vector2 horizontalSpawnRange = new Vector2(-8f, 8f);
    public float topSpawnPosY = 9.5f;
    public float bottomSpawnPosY = -4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TopBugSpawning());
        StartCoroutine(BottomBugSpawning());
        StartCoroutine(IncreaseSpawnFrequency());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator TopBugSpawning()
    {
        while (true)
        {
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugSpawnPos = new Vector3(randomX, topSpawnPosY, -2f);
            GameObject newBug = Instantiate(bugPrefab, bugSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator BottomBugSpawning()
    {
        while (true)
        {
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugSpawnPos2 = new Vector3(randomX, bottomSpawnPosY, -2f);
            GameObject newBug2 = Instantiate(bugPrefab, bugSpawnPos2, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator IncreaseSpawnFrequency()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeRateInterval);
            
            if (spawnInterval > fastestSpawnInterval)
            {
                spawnInterval -= intervalChangeRate;
                spawnInterval = Mathf.Max(spawnInterval, fastestSpawnInterval);
                Debug.Log("speed is increasing");
            }
        }
    }
}
