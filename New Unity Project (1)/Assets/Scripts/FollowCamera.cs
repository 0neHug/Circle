using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FollowCamera : MonoBehaviour
{

    public Transform Hero;

    private Vector3 _cameraOffset;
    [Range(0.01f, 5f)]
    public float SmoothFactor = 0.2f;
    
    [SerializeField] [Range(0f, 5f)] 
    float lerpTime;
    
    [SerializeField] 
    Color[] Colors;
    
    int colorVar = 0;
    float t = 0f;
    int len;
    PostProcessVolume volume ;
    Bloom bloomLayer = null;
    void Start()
    {
        len = Colors.Length;
        
        _cameraOffset = transform.position - Hero.position;
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloomLayer);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(colorVar);
        Vector3 newPos = Hero.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        bloomLayer.color.value = Color.Lerp(bloomLayer.color.value, Colors[colorVar], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorVar++;
            if (colorVar >= len) colorVar = 1;
            
        }


    }
}