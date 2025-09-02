using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bugDown")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
