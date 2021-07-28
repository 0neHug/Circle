using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneCircle : MonoBehaviour
{
    public Transform Begin;
    public Transform Finish;
    public Material[] Ranbow;
    
    [SerializeField]
    [Range(0, 100)]
    public int lenChapterRoad = 50;
    float touchRadius = 0.05f;
    
    private Quaternion rotationRight = Quaternion.AngleAxis(2.2f, new Vector3(1f, 0, 0));
    private Quaternion rotationLeft = Quaternion.AngleAxis(-2.2f, new Vector3(1f, 0, 0));
    private Quaternion NoRotation = Quaternion.AngleAxis(0f, new Vector3(0f, 0, 0));
    
    public GameObject[] Pad;
    int countPad ;
    
    void Start()
    {
        
        if (RoadMaker.countSchemePiece < lenChapterRoad)
        {
            RandomScheme();
        }
        if (RoadMaker.countSchemePiece > lenChapterRoad+2 && RoadMaker.countSchemePiece < lenChapterRoad*2)
        {
            SpiralScheme();
        }
        if (RoadMaker.countSchemePiece > lenChapterRoad*2+2 && RoadMaker.countSchemePiece < lenChapterRoad*3)
        {
            MixedScheme();
        }
        if (RoadMaker.countSchemePiece >= lenChapterRoad*3+2) 
        { 
            RoadMaker.countSchemePiece = 0; 
        }
    }
    void RandomScheme()
    {
        for (int i = 0; i < 8; i++)
        {
            Destroy(Pad[Random.Range(0, 16)]);
            
        }
        
    }

    void SpiralScheme()
    {
        countPad = RoadMaker.count;
        for (int i = 0; i < 10; i++)
        {

            if (countPad + i > 15) { countPad = 0 - i; }
            if (countPad + i <= 15)
            {
                Destroy(Pad[countPad + i]);
            }

        }
        
    }
    void MixedScheme()
    {
        countPad = RoadMaker.count;
        for (int i = 0; i < 7; i++)
        {

            if (countPad + i > 15) { countPad = 0 - i; }
            if (countPad + i <= 15)
            {
                Destroy(Pad[countPad + i]);
            }

        }
        for (int i = 0; i < 4; i++)
        {
            Destroy(Pad[Random.Range(0, 16)]);

        }
    }
    


    void FixedUpdate()
    {
        
        
        if (Touch.Direct.x > touchRadius) { this.transform.rotation *= rotationRight; } else if (Touch.Direct.x < -touchRadius) { this.transform.rotation *= rotationLeft; }
        if (Touch.Direct.x < touchRadius && Touch.Direct.x > -touchRadius) { this.transform.rotation *= NoRotation; }

      

       
    }
}

