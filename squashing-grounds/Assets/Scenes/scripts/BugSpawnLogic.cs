using System.Collections;
using UnityEngine;

public class BugSpawnLogic : MonoBehaviour
{
    public GameObject bugDown;
    public float spawnInterval = .2f;
    public Vector2 horizontalSpawnRange = new Vector2(-6.5f, 6.5f);
    public float topSpawnPosY = 5f;
    public float bottomSpawnPosY = -5f;

    public Vector3 squashPos;
    public float bugSpeed = 3f;

    //public BugDownMovement bugMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBugs()); //top spawner
        StartCoroutine(SpawnBugs2()); //bottom spawner

        //StartCoroutine(SpawnBug3()); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnBugs()
    {
        while (true)
        {
            //yield return new WaitForSeconds(5f);
            float randomX = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugDownSpawn = new Vector3(randomX, topSpawnPosY, 0f);
            
            GameObject newBugDown = Instantiate(bugDown, bugDownSpawn, Quaternion.identity);
            Rigidbody2D bugDownRb = newBugDown.GetComponent<Rigidbody2D>();

            // https://discussions.unity.com/t/vector2-normalized-why-do-we-use-it/707794
            Vector2 trajectory = (squashPos - bugDownSpawn).normalized;
            bugDownRb.linearVelocity = trajectory * bugSpeed;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator SpawnBugs2()
    {
        while (true)
        {
            //yield return new WaitForSeconds(5f);
            float randomX2 = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
            Vector3 bugUpSpawn = new Vector3(randomX2, bottomSpawnPosY, 0f);

            GameObject newBugUp = Instantiate(bugDown, bugUpSpawn, Quaternion.identity);
            Rigidbody2D bugUpRb = newBugUp.GetComponent<Rigidbody2D>();

            // https://discussions.unity.com/t/vector2-normalized-why-do-we-use-it/707794
            Vector2 trajectory2 = (squashPos - bugUpSpawn).normalized;
            bugUpRb.linearVelocity = trajectory2 * bugSpeed;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
