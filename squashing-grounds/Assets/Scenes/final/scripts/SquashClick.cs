using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class SquashClick : MonoBehaviour
{
    public AudioSource bugSquashNoise;
    //public CinemachineImpulseSource impulseSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider.CompareTag("bugs"))
            {
                //CameraShakeManager.instance.CameraRumble(impulseSource);
                Destroy(hit.collider.gameObject);
                bugSquashNoise.Play();

            }
        }
    }
}
