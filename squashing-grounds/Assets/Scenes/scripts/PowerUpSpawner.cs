using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps = new GameObject[3];
    public Vector2 xSpawnRange = new Vector2(-6.5f, 6.5f);
    public Vector2 ySpawnRange = new Vector2(-4f, 4f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPowers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnPowers()
    {
        while (true)
        {
            float randomX = Random.Range(xSpawnRange.x, ySpawnRange.y);
            Vector3 bugDownSpawn = new Vector3(randomX, topSpawnPosY, 0f);

            GameObject newBugDown = Instantiate(bugDown, bugDownSpawn, Quaternion.identity);
            Rigidbody2D bugDownRb = newBugDown.GetComponent<Rigidbody2D>();

            Vector2 trajectory = (squashPos - bugDownSpawn).normalized;
            bugDownRb.linearVelocity = trajectory * bugSpeed;

            yield return new WaitForSeconds(spawnInterval);
        }

    }
}
