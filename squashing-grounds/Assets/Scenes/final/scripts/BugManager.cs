using System.Collections;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject bugPrefab;
    public float spawnInterval = 1f;
    public Vector2 horizontalSpawnRange = new Vector2(-6.5f, 6.5f);
    public float topSpawnPosY = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BugSpawning());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator BugSpawning()
    {
        while (true)
        {
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugSpawnPos = new Vector3(randomX, topSpawnPosY, -2f);
            GameObject newBug = Instantiate(bugPrefab, bugSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
