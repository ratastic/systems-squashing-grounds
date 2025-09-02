using System.Collections;
using UnityEngine;

public class BugSpawnLogic : MonoBehaviour
{
    public GameObject bugDown;
    public float spawnInterval = 1f;
    public Vector2 topSpawnRange = new Vector2(-6.5f, 6.5f);
    public float topSpawnPosY = 5f;

    public Vector3 squashPos;
    public float bugSpeed = 3f;

    //public BugDownMovement bugMovement;
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
            //yield return new WaitForSeconds(5f);
            float randomX = Random.Range(topSpawnRange.x, topSpawnRange.y);
            Vector3 bugDownSpawn = new Vector3(randomX, topSpawnPosY, 0f);
            
            GameObject newBugDown = Instantiate(bugDown, bugDownSpawn, Quaternion.identity);
            Rigidbody2D bugDownRb = newBugDown.GetComponent<Rigidbody2D>();

            // https://discussions.unity.com/t/vector2-normalized-why-do-we-use-it/707794
            Vector2 trajectory = (squashPos - bugDownSpawn).normalized;
            bugDownRb.linearVelocity = trajectory * bugSpeed;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
