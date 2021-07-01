using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool moveX;

    public GameObject lW;
    public float speed = 1;
    public float moveDis;
    public float startX;
    public float startY;

    private bool isLeverOn = false;
    
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;

    void Start()
    {
        sprite1 = GetComponent<SpriteRenderer>();
        sprite2 = GetComponent<SpriteRenderer>();     
        startX = lW.gameObject.transform.position.x;
        startY = lW.gameObject.transform.position.y;   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("SLIME") || col.gameObject.CompareTag("BOX"))
        {
            Debug.Log("Lever On");
            if(isLeverOn)
            {
                isLeverOn = false;
                DataManager.Instance.leverOn = true;
                sprite1.flipX = true;
                sprite2.flipX = true;
            }
            else
            {
                isLeverOn = true;
                DataManager.Instance.leverOn = true;
                sprite1.flipX = false;
                sprite2.flipX = false;
            }
        }
    }

      void Update()
    {
        if(lW.transform.position.x < startX+moveDis && isLeverOn && moveX)
       {
            lW.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else if(lW.transform.position.x > startX && !isLeverOn && moveX)
        {
           lW.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }   

         if(lW.transform.position.y < startY+moveDis && isLeverOn && !moveX)
       {
            lW.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        else if(lW.transform.position.y > startY && !isLeverOn && !moveX)
        {
           lW.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }   
    }
}
