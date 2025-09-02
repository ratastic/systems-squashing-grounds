using System.Collections;
using UnityEngine;

public class BugSpawnLogic : MonoBehaviour
{
    public GameObject bugDown;
    public float spawnInterval = 1f;
    public Vector2 topSpawnRange = new Vector2(-6.5f, 6.5f);
    public float topSpawnPosY = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBugs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBugs()
    {
        while (true)
        {
            //WaitForSeconds(5);
            float randomX = Random.Range(topSpawnRange.x, topSpawnRange.y);
            Vector3 bugDownSpawn = new Vector3(randomX, topSpawnPosY, 0f);

            GameObject newBugDown = Instantiate(bugDown, bugDownSpawn, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
