using System.Collections;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject bugPrefab;
    public float spawnInterval = 1f;
    public Vector2 horizontalSpawnRange = new Vector2(-6.5f, 6.5f);
    public float topSpawnPosY = 5f;
    public float bottomSpawnPosY = -5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TopBugSpawning());
        StartCoroutine(BottomBugSpawning());
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
}
