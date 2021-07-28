using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColor : MonoBehaviour
{   
   
    //bool Coin_Up_Play = false;
    public Material Enter;
    public Material Exit;
    public Material buf_hardVision;
    // public Material[] Ranbow;

    // Start is called before the first frame update
    void Start()
    {
        
        if (Random.Range(0, 10) == 5)
        {

            
            Renderer render = GetComponent<Renderer>();
            render.material = buf_hardVision;
            this.tag = "buf_hardVision";
        }
    }
    private IEnumerator OnCollisionEnter(Collision collision)
 //Check to see if you just set the
    {
        
       
        Renderer render = GetComponent<Renderer>();
        render.material = Enter;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        
    }
   /* private IEnumerator ChangeRanbow()
    {
        Renderer render = GetComponent<Renderer>();
        render.material = Ranbow[Random.Range(0, 6)];
        yield return new WaitForSeconds(3f);
        

    }*/

    
    // Update is called once per frame
    void Update()
    {
        
    }


    
}
