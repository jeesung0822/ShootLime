using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBomb : MonoBehaviour
{
    public Rigidbody2D[] babyRigid;

    void Awake()
    {
        babyRigid = GetComponentsInChildren<Rigidbody2D>();    
    }

    public void BabyBombBoom(Vector2 dir, float power)
    {
        foreach(Rigidbody2D r in babyRigid)
        {
            r.AddForce(dir * power, ForceMode2D.Impulse);
        }
    }
    

}
