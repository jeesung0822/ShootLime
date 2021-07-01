using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript2 : MonoBehaviour
{
    Slider saSlider;

    void Start()
    {
        saSlider = GetComponent<Slider>();
    }

    void Update()
    {
        saSlider.value = DataManager.Instance.haveSA - DataManager.Instance.useSA;
    }
}
