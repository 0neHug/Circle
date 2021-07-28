using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{

    private Quaternion rotationRight = Quaternion.AngleAxis(2.2f, new Vector3(1f, 0, 0));
    private Quaternion rotationLeft = Quaternion.AngleAxis(-2.2f, new Vector3(1f, 0, 0));
    private Quaternion RotationCircle;
    private Quaternion NoRotation = Quaternion.AngleAxis(0f, new Vector3(0f, 0, 0));

    public GameObject OneCircle;

    public Vector3 Cursor;
    public Vector3 Direction_Vector = new Vector3(0f,0f,0f);
    public static Vector3 Direct = new Vector3(0f,0f,0f);
    float Max = 0f;
    
   
    void Start()
    {
        Max = 0f;
        Cursor *= 0f;
        Direction_Vector *= 0f;
        Direct *= 0;
    }
    void Awake()
    {
        Max = 0f;
        Cursor *= 0f;
        Direction_Vector *= 0f;
        Direct *= 0;
    }

    void OnMouseDown()
    {

        Cursor = Input.mousePosition;
        Cursor = Camera.main.ScreenToViewportPoint(Cursor);
        //Debug.Log(Cursor);
    }
    

    void OnMouseDrag()
    {
        Direction_Vector = Input.mousePosition;
        Direction_Vector = Camera.main.ScreenToViewportPoint(Direction_Vector);

        if (Direction_Vector.x >= Cursor.x)
        {
            if (Max-0.01f <= Direction_Vector.x)
            {
                Max = Direction_Vector.x;
            }
            else
            {
                Cursor = Direction_Vector;
            }
        }
        if (Direction_Vector.x <= Cursor.x)
        {
            if (Max+0.01f >= Direction_Vector.x )
            {
                Max = Direction_Vector.x;
            }
            else
            {
                Cursor = Direction_Vector;

            }
        }



        Direct = Direction_Vector - Cursor;


    }
    void OnMouseUp()
    {
        Direct *= 0;
        Max = 0;
        Cursor *= 0;
        Direction_Vector *= 0;
    }
        void Update()
    {
        //Debug.Log(Direct.x);
    }
}
