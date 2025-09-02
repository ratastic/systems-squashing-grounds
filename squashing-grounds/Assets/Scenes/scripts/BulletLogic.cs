using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Transform player;
    public GameObject bulletPrefab;
    public Rigidbody2D bulletRb;
    public float bulletSpeed = 5f;
    public Vector2 bulletSpawnOffsetPosX = new Vector2(.5f, 0f);
    public Vector2 bulletSpawnOffsetNegX = new Vector2(-.5f, 0f);
    public Vector2 bulletSpawnOffsetPosY = new Vector2(0f, .5f);
    public Vector2 bulletSpawnOffsetNegY = new Vector2(0f, -.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 bulletSpawn = (Vector2)player.position + bulletSpawnOffsetPosX;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(bulletSpeed, 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 bulletSpawn = (Vector2)player.position + bulletSpawnOffsetNegX;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(-bulletSpeed, 0f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 bulletSpawn = (Vector2)player.position + bulletSpawnOffsetPosY;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0f, bulletSpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 bulletSpawn = (Vector2)player.position + bulletSpawnOffsetNegY;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0f, -bulletSpeed);
        }
    }
}
