using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColSlime : MonoBehaviour
{
    public bool isColl;
    bool sObjOn;
    bool sWallOn;

    int fireStack;
    int waterStack;
    
    public float distance;
    public CircleCollider2D stealthC;
    public GameObject babyBombPrefab;
    Rigidbody2D rigid;
    Vector3 coll = new Vector3();
    Vector3 sObjColl = new Vector3();

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(DataManager.Instance.selectS == 4) // Stealth Slime
        {
             if(col.gameObject.CompareTag("SOBJ"))
            {
                stealthC.isTrigger = false;
            }
            else if(col.gameObject.CompareTag("DESSERT"))
            {
                DataManager.Instance.score += 15;
                Destroy(col.gameObject);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        coll = transform.position;
        sObjColl = col.transform.position;
        isColl = true;
        

        if(DataManager.Instance.selectS == 5) // Bomb Slime
        {
            DataManager.Instance.bombCount++;

            if(DataManager.Instance.bombCount == 1)
            {
                GameObject babyBomb = Instantiate(babyBombPrefab, transform.position, transform.rotation);
                BabyBomb bb = babyBomb.GetComponent<BabyBomb>();
                bb.BabyBombBoom(transform.position.normalized, 700f);
                
                Destroy(gameObject);
                DataManager.Instance.bombCount++;
            }
        }  
        else if (DataManager.Instance.selectS == 7) // Gravity Slime
        {
            GameObject gravityZone =  Instantiate(DataManager.Instance.gravityZone, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(gravityZone, 3f);
        }  
        else if(DataManager.Instance.selectS == 8) // Glue Slime
        {  
            rigid.bodyType = RigidbodyType2D.Static;
            rigid.bodyType = RigidbodyType2D.Dynamic;
            rigid.gravityScale = 0;

            transform.position = coll;
            if(col.gameObject.CompareTag("SOBJ"))
            {
                transform.position = sObjColl;
                sObjOn = true;
            }
            else if(col.gameObject.CompareTag("DESSERT"))
            {
                rigid.gravityScale = 1;
            }
            else if(col.gameObject.CompareTag("SWALL"))
            {
                sWallOn = true;
            }
        }
        else if(DataManager.Instance.selectS == 9) // Pig Slime
        {
            if(col.gameObject.CompareTag("DESSERT"))
            {
                DataManager.Instance.score += (50 * DataManager.Instance.pigStack);
                DataManager.Instance.pigStack++;
            }
        }
        else if(DataManager.Instance.selectS == 10) // FIre Slime
        {
            fireStack++;
        }
        else if(DataManager.Instance.selectS == 11) // Water Slime
        {
            // waterStack++;
            if(col.gameObject.CompareTag("DESSERT"))
            {
                DataManager.Instance.haveSA += 10;
            }
        }
    }

    void Update()
    {
        if(isColl)
        {
            distance = Vector3.Distance(transform.position, coll);
            if(distance >= 3)
            {
                rigid.gravityScale = 1;
            }

            if(sObjOn && DataManager.Instance.leverOn)
            {
                LeverCol();
            }
            else if(sWallOn && (DataManager.Instance.leverOn || DataManager.Instance.buttonOn))
            {
                rigid.gravityScale = 1;
                sWallOn = false;
                DataManager.Instance.buttonOn = false;
            }
        }

        if(fireStack > 0)
        {   
            DataManager.Instance.score++;
            fireStack--;
        }

        // if(waterStack > 1)
        // {   
        //     DataManager.Instance.haveSA++;
        //     waterStack-= 2;
        // }

    }

    public void LeverCol()
    {
        transform.position = sObjColl;
        sObjOn = false;
        DataManager.Instance.leverOn = false;
    }

}