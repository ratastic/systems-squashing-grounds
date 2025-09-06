using UnityEngine;

public class BugMovement : MonoBehaviour
{
    private Transform player;
    public float bugSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, bugSpeed * Time.deltaTime);
    }
}
