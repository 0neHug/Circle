using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resrt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
