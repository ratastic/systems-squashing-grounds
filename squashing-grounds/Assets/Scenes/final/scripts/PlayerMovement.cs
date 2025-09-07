using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 1f;
    private Rigidbody2D rb2d;

    public CinemachineImpulseSource playerHit;
    //public CinemachineImpulseSource playerWalk;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb2d.linearVelocity = new Vector2(moveX * moveForce, moveY * moveForce);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            //CameraShakeManager.instance.CameraRumble(playerWalk);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bugs"))
        {
            CameraShakeManager.instance.CameraRumble(playerHit);
            Destroy(col.gameObject);
        }
    }
}
