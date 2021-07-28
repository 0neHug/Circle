using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    float Speed;
    AudioSource SoundSource;
    public AudioClip CoinUpClip;
    public static int CoinScore;

    [SerializeField]
    [Range(0f, 5f)]
    float lerpTime;
    float t = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        CoinScore = 0;

    }
    void Awake()
    {
        
        CoinScore = 0;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "buf_hardVision")
        {
            t = 0f;
            collision.gameObject.tag = "Untagged";
            SoundSource = GetComponent<AudioSource>();
            SoundSource.pitch += 0.025f;
            SoundSource.PlayOneShot(CoinUpClip,1.0f);
            CoinScore++;

        }
    }
    void Update()
    {
        Speed = rb.velocity.magnitude;

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            SoundSource = GetComponent<AudioSource>();
            SoundSource.pitch = 0.7f;
            
        }
    }
    void FixedUpdate()
    {
        if (Speed <= 20f) { rb.AddForce(new Vector3(0f, 0f, 0.3f), ForceMode.Impulse); }
       





    }

   
}
