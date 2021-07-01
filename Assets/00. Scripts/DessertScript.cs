using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertScript : MonoBehaviour
{
    public bool isBigCake;

    Rigidbody2D rigid;
    public int score;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!isBigCake && (col.gameObject.CompareTag("SLIME") || col.gameObject.CompareTag("BOX")))
        {
            DataManager.Instance.score += score;
            DataManager.Instance.dessertCount--;
            gameObject.SetActive(false);
        }
        else if(isBigCake && !DataManager.Instance.eatBigCake && (col.gameObject.CompareTag("SLIME") || col.gameObject.CompareTag("BOX")))
        {
            DataManager.Instance.score += score; 
            DataManager.Instance.dessertCount--;
            gameObject.SetActive(false);
            DataManager.Instance.eatBigCake = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("GRAVITYZONE"))
        {   
            rigid.gravityScale = 1;
        }
    }

}
