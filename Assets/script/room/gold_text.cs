using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gold_text : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text =  GAMEMANAGER.Instance.money.ToString();
    }
}
