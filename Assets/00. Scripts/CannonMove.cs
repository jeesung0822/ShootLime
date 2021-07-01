using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonMove : MonoBehaviour
{
    public float angleSpeed = 60f; 

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,0, angleSpeed * Time.deltaTime));    

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,0, -angleSpeed * Time.deltaTime));
        }

        // 좌우이동 //
        
        //  if(Input.GetKey(KeyCode.UpArrow) && transform.position.x < 0.8 )
        // {
        //     gameObject.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        // }
        // else if(Input.GetKey(KeyCode.DownArrow) && transform.position.x > -0.8 )
        // {
        //     gameObject.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
        // }

    }
}
