using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    public Transform Hero;
    public OneCircle CirclePrefabs;
    public OneCircle FirstCircle;
    public List<OneCircle> SpawnedCircle ;
    public static int count = 0;
    public static int countSchemePiece = 0;

    public int depthCreateRoad = 118;
    

    void Start()
    {
        count = 0;
        countSchemePiece = 0;
        SpawnedCircle = new List<OneCircle>();
        SpawnedCircle.Add(FirstCircle);
        

        
    }
    private void SpawnMake()
    {
        OneCircle NewCircle = Instantiate(CirclePrefabs);

        NewCircle.transform.position = SpawnedCircle[SpawnedCircle.Count - 1].Finish.position + new Vector3(0,0,2f) - new Vector3(0, 0.1f, 0);
        NewCircle.transform.rotation = SpawnedCircle[SpawnedCircle.Count - 1].transform.rotation;
        SpawnedCircle.Add(NewCircle);
        
        if (SpawnedCircle.Count >= 30)
        {
            
            Destroy(SpawnedCircle[0].gameObject);
            SpawnedCircle.RemoveAt(0);
            
        }
        if (count <= 15) { count++; }
        if (count > 15) { count = 0;  }
        countSchemePiece++;

    }
    // Update is called once per frame
    void Update()
    {
        if (Hero.position.z > SpawnedCircle[SpawnedCircle.Count - 1].Finish.position.z - depthCreateRoad)
        {
            
            SpawnMake();
            
        }
    }
}
