using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    // reference
    // https://www.google.com/search?sca_esv=b860543b1a2d43da&rlz=1C5OZZY_enUS1163US1163&sxsrf=AE3TifMmqFVZc8XYb4Ww0WdetL_GXMqoDw:1757139186088&udm=7&fbs=AIIjpHxU7SXXniUZfeShr2fp4giZ1Y6MJ25_tmWITc7uy4KIeioyp3OhN11EY0n5qfq-zEMZldv_eRjZ2XLYc5GnVnME7glWodDcaQwvGYJtospyF4hao4VocMoniUVvlzzwRcCLYvfsjPeiuln4CZ9mxRNzMJl71rp-WEM_b89yTboF0wE9FSbwRYrSVuB6YHexvLk_d7r_74zDurdYUrhSbdL5TbQGiA&q=camera+rumble+uity+2d&sa=X&ved=2ahUKEwiv04fIvcOPAxWyMVkFHW9iEGEQtKgLegQIFBAB&biw=1512&bih=857&dpr=2#fpstate=ive&vld=cid:47c3dc8d,vid:CgyLIWyDXqo,st:0

    public static CameraShakeManager instance;
    [SerializeField] private float shakeForce = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraRumble(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(shakeForce);
    }
}
