using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(DataManager.Instance.previewSlimeImage[i]);
        }
    }
}
