using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hotel_btn : MonoBehaviour
{
    public GameObject Rest_UI;
    public rest_action rest_Action;
    public GameObject Loading_out;
    public Text text;

    public void Start(){
        GAMEMANAGER.Instance.travel_time = 150;
    }
    void Update(){
        text.text = (GAMEMANAGER.Instance.travel_time/60).ToString() + "시간 " + (GAMEMANAGER.Instance.travel_time%60).ToString()
        + "분 남았다냥";
    }
    public void out_hotel(){
        Soundmanager.Instance.Playsound("in_btn");
        Loading_out.SetActive(true);
    }
    public void hotel_rest(){
        Soundmanager.Instance.Playsound("in_btn");
        //GAMEMANAGER.Instance.travel_time -= 30;
        //GAMEMANAGER.Instance.travel_left--;
        GAMEMANAGER.Instance.pre_stemina = GAMEMANAGER.Instance.stemina;
        StartCoroutine(rest_Action.IncreaseStaminaSmoothly());
        Rest_UI.SetActive(true);
        rest_Action.is_end = false;
    }
}
