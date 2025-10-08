using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 1f; //THIS
    private Rigidbody2D rb2d; //THIS

    public CinemachineImpulseSource playerHit;
    //public CinemachineImpulseSource playerWalk;

    private Animator animator;

    public HeartManager heartManager;
    private float cooldown = 1.0f;
    private float lastHitTime;

    public Color[] heartColors;
    private SpriteRenderer playerRenderer;
    private int currentColor = 0;

    private AudioSource hitSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //THIS
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // THIS
        float moveY = Input.GetAxisRaw("Vertical"); // THIS 
        rb2d.linearVelocity = new Vector2(moveX * moveForce, moveY * moveForce); // THIS

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
        if (col.gameObject.CompareTag("bugs") && Time.time - lastHitTime > cooldown) // 1 second cooldown; i don't think it works
        {
            CameraShakeManager.instance.CameraRumble(playerHit);
            Destroy(col.gameObject);
            hitSound.Play();

            if (currentColor < heartColors.Length)
            {
                playerRenderer.color = heartColors[currentColor];
                Debug.Log("color changing" + heartColors[currentColor]);

                currentColor++;
            }

            heartManager.LoseHeart(1); // calls method from manager script and passes in 1 to represent damage amount
            lastHitTime = Time.time; // resets cooldwon
        }
    }
}
