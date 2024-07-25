using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_bar : MonoBehaviour
{
    public Slider Slider;
    public int value = 0; // 0 행복, 1 스테, 2 돈

    void Start()
    {
        Slider.maxValue = GAMEMANAGER.Instance.Max_value;
    }

    void Update()
    {
        if(value == 0)
            Slider.value = GAMEMANAGER.Instance.happy;
        else if(value == 1)
            Slider.value =  GAMEMANAGER.Instance.stemina;
    }
}