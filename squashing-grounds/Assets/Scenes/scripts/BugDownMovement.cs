using UnityEngine;

public class BugDownMovement : MonoBehaviour
{
    public float speed = 3f;
    public Transform squashPos;
    public bool isReversed = false;
    private Vector3 trajectory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trajectory = (squashPos.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(trajectory * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet" && !isReversed)
        {
            Debug.Log("hitting");
            trajectory = -trajectory;
            isReversed = true;
        }
    }
}
