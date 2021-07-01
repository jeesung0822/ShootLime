using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    // enum slimes
    // {
    //     nomalS,
    //     dongdongS,
    //     metalS,
    //     randomS,
    //     stealthS,
    //     bombS,
    //     twinS,
    //     gravityS,
    //     glueS,
    //     pigS,
    //     fireS,
    //     waterS
    // }

    // slimes state;
    // int slimeNum;

    // void Start()
    // {
    //     state = slimes.nomalS;
    // }

    public Rigidbody2D radomR;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            switch(DataManager.Instance.selectS)
            {
                case 0:
                NomalS();
                break;

                case 1:
                DongdongS();
                break;

                case 2:
                MetalS();
                break;

                case 3:
                RandomS();
                break;

                case 4:
                StealthS();
                break;

                case 5:
                BombS();
                break;

                case 6:
                TwinS();
                break;

                case 7:
                GravityS();
                break;

                case 8:
                GlueS();
                break;

                case 9:
                PigS();
                break;

                case 10:
                FireS();
                break;

                case 11:
                WaterS();
                break;

                default:
                break;
            }

            DataManager.Instance.fireClick = false;
        }
        
    }

    void NomalS()
    {
        DataManager.Instance.useSA = 15;

    }

    void DongdongS()
    {
        DataManager.Instance.useSA = 18;
    }

    void MetalS()
    {
        DataManager.Instance.useSA = 18;
    }

    void RandomS()
    {
        DataManager.Instance.useSA = 10; 
        radomR.sharedMaterial.bounciness = UnityEngine.Random.Range(0f, 0.9f);
        DataManager.Instance.power = UnityEngine.Random.Range(100f, 1200f);
        DataManager.Instance.isRandomS = true;
    }

    void StealthS()
    {
        DataManager.Instance.useSA = 45;
    }

    void BombS()
    {
        DataManager.Instance.useSA = 38;
    }

    void TwinS()
    {
        DataManager.Instance.useSA = 22;
        DataManager.Instance.isTwinS = true;
        DataManager.Instance.twinSFire = true;
    }

    void GravityS()
    {
        DataManager.Instance.useSA = 25;
    }

    void GlueS()
    {
        DataManager.Instance.useSA = 12;
    }

    void PigS()
    {
        DataManager.Instance.useSA = 25;
        DataManager.Instance.pigStack = 0;
    }

    void FireS()
    {
        DataManager.Instance.useSA = 42;
    }

    void WaterS()
    {
        DataManager.Instance.useSA = 30;
    }
}
