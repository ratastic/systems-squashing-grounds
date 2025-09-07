using UnityEngine;

public class BugMovement : MonoBehaviour
{
    // reference
    // https://www.google.com/search?q=how+to+make+enemies+folow+meunity&rlz=1C5OZZY_enUS1163US1163&oq=how+to+make+enemies+folow+meunity&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIJCAEQIRgKGKABMgkIAhAhGAoYoAEyCQgDECEYChigATIJCAQQIRgKGKABMgkIBRAhGAoYqwIyCQgGECEYChirAjIHCAcQIRiPAtIBCDg2NTNqMGo0qAIAsAIB&sourceid=chrome&ie=UTF-8#fpstate=ive&vld=cid:2b12e781,vid:4zAN5QBwGt8,st:0

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
        transform.position = Vector2.MoveTowards(transform.position, player.position, bugSpeed * Time.deltaTime); // chases after player
    }
}
