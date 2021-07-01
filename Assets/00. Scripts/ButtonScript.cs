using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool moveX;
    public bool bigCake;

    public GameObject bW;
    public GameObject On;
    public GameObject BigCake;

    public float speed = 1;
    public float moveDis;
    public float startX;
    public float startY;

    private bool isButtonON = false;

    void Start()
    {
        startX = bW.gameObject.transform.position.x;
        startY = bW.gameObject.transform.position.y;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("SLIME") || col.gameObject.CompareTag("BOX"))
        {
            Debug.Log("On");
            isButtonON = true;
            DataManager.Instance.buttonOn = true;
            On.SetActive(true);
        }

        if(col.gameObject.CompareTag("BOX") && bigCake && !DataManager.Instance.eatBigCake)
        {
            BigCake.SetActive(true);
            DataManager.Instance.eatBigCake = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("SLIME") || col.gameObject.CompareTag("BOX"))
        {
            Debug.Log("Off");
            isButtonON = false;
            DataManager.Instance.buttonOn = true;
            On.SetActive(false);
        }
    }

    void Update()
    {
        if(bW.transform.position.x < startX+1 && isButtonON && moveX)
       {
            bW.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else if(bW.transform.position.x > startX && !isButtonON && moveX)
        {
           bW.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }   

         if(bW.transform.position.y < startY+moveDis && isButtonON && !moveX)
       {
            bW.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        else if(bW.transform.position.y > startY && !isButtonON && !moveX)
        {
           bW.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }           
    }
}