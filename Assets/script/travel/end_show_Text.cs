using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end_show_Text : MonoBehaviour
{
    public Text ride;
    public Text place;
    public Text state;
    public Text bill;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1) // 나중에 2개로 분리
            place.text = "목적지    : 강릉";
        else if(GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3)
            place.text = "목적지    : 부산";
        else if(GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5)
            place.text = "목적지    : 전주";


        if(GAMEMANAGER.Instance.how == 1){
            ride.text = "탈것   : 기차";
        }
        else if(GAMEMANAGER.Instance.how == 2){
            ride.text = "탈것   : 버스";
        }
        else if(GAMEMANAGER.Instance.how == 3){
            ride.text = "탈것   : 자전거";
        }
        
        if(GAMEMANAGER.Instance.how == 1 && (GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1)){
            state.text = "피로도 : -15\n행복도 : +40";
            bill.text = "총 비용 : 35";
        }
        else if(GAMEMANAGER.Instance.how == 2 && (GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1)){
            state.text = "피로도 : -25\n행복도 : +20";
            bill.text = "총 비용 : 17";
        }
        else if(GAMEMANAGER.Instance.how == 3 && (GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1)){
            state.text = "피로도 : -35\n행복도 : +10";
            bill.text = "총 비용 : 1";
        }

        if(GAMEMANAGER.Instance.how == 1 && (GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3)){
            state.text = "피로도 : -17\n행복도 : +43";
            bill.text = "총 비용 : 43";
        }
        else if(GAMEMANAGER.Instance.how == 2 && (GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3)){
            state.text = "피로도 : -35\n행복도 : +25";
            bill.text = "총 비용 : 23";
        }
        else if(GAMEMANAGER.Instance.how == 3 && (GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3)){
            state.text = "피로도 : -45\n행복도 : +9";
            bill.text = "총 비용 : 2";
        }

        if(GAMEMANAGER.Instance.how == 1 && (GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5)){
            state.text = "피로도 : -12\n행복도 : +40";
            bill.text = "총 비용 : 35";
        }
        else if(GAMEMANAGER.Instance.how == 2 && (GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5)){
            state.text = "피로도 : -20\n행복도 : +22";
            bill.text = "총 비용 : 20";
        }
        else if(GAMEMANAGER.Instance.how == 3 && (GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5)){
            state.text = "피로도 : -20\n행복도 : +10";
            bill.text = "총 비용 : 1";
        }
    }
}
