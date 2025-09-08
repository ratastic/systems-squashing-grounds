using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject bugPrefab;

    public float spawnInterval = 1f;
    public float fastestSpawnInterval = 0.9f;
    public float intervalChangeRate = .15f;
    public float changeRateInterval = 5f;

    public Vector2 horizontalSpawnRange = new Vector2(-8f, 8f);
    public float topSpawnPosY = 9.5f;
    public float bottomSpawnPosY = -4f;

    private Coroutine topBugSpawning;
    private Coroutine bottomBugSpawning;
    private Coroutine increaseSpawnFrequency;

    private List<GameObject> activeBugs = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartSpawning()
    {
        topBugSpawning = StartCoroutine(TopBugSpawning());
        bottomBugSpawning = StartCoroutine(BottomBugSpawning());
        increaseSpawnFrequency = StartCoroutine(IncreaseSpawnFrequency());
    }

    public IEnumerator TopBugSpawning()
    {
        while (true)
        {
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y); // range for random horizontal spawn position
            Vector3 bugSpawnPos = new Vector3(randomX, topSpawnPosY, -2f); // exact spawn position
            GameObject newBug = Instantiate(bugPrefab, bugSpawnPos, Quaternion.identity); // instantiate the new bug
            activeBugs.Add(newBug); // add bug to activeBugs list
            yield return new WaitForSeconds(spawnInterval); // time between each spawn
        }
    }

    public IEnumerator BottomBugSpawning()
    {
        while (true)
        {
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugSpawnPos2 = new Vector3(randomX, bottomSpawnPosY, -2f);
            GameObject newBug2 = Instantiate(bugPrefab, bugSpawnPos2, Quaternion.identity);
            activeBugs.Add(newBug2);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator IncreaseSpawnFrequency()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeRateInterval);
            
            if (spawnInterval > fastestSpawnInterval) // if the current interval larger than the smallest interval 
            {
                spawnInterval -= intervalChangeRate; // speed up spawn rate in increments
                spawnInterval = Mathf.Max(spawnInterval, fastestSpawnInterval); // transition 
                Debug.Log("speed is increasing");
            }
        }
    }

    public void StopSpawning()
    {
        if (topBugSpawning != null)
            StopCoroutine(topBugSpawning);

        if (bottomBugSpawning != null)
            StopCoroutine(bottomBugSpawning);

        if (increaseSpawnFrequency != null)
            StopCoroutine(increaseSpawnFrequency);

        foreach (GameObject bug in activeBugs)
        {
            Destroy(bug); // destroy all the active bugs on screen
        }

        activeBugs.Clear(); // clear list
    }
}
