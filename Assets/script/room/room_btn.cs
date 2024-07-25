using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_btn : MonoBehaviour
{
    public GameObject Rest_UI;
    public rest_action rest_Action;
    public GameObject Work_UI;
    public GameObject diary_UI;
    public GameObject option_UI;
    public GameObject END_UI;
    public GameObject travel_loading; 
    public GameObject nogada_loading; 
    public GameObject store_loading; 
    public GameObject food_loading;
    public GameObject no_stemina;

    void Update(){
        if(GAMEMANAGER.Instance.is_ending == false &&
        GAMEMANAGER.Instance.travel_place[0] == true &&
        GAMEMANAGER.Instance.travel_place[1] == true &&
        GAMEMANAGER.Instance.travel_place[2] == true){
            END_UI.SetActive(true);
            GAMEMANAGER.Instance.is_ending = true;
        }
        if(GAMEMANAGER.Instance.is_no_stemina == true){
            no_stemina.SetActive(true);
            GAMEMANAGER.Instance.is_no_stemina = false;
        }
    }

    public void rest()
    {
        Soundmanager.Instance.Playsound("in_btn");
        GAMEMANAGER.Instance.pre_stemina = GAMEMANAGER.Instance.stemina;
        StartCoroutine(rest_Action.IncreaseStaminaSmoothly());
        Rest_UI.SetActive(true);
        rest_Action.is_end = false;
    }

    public void work()
    {
        Soundmanager.Instance.Playsound("in_btn");
        Work_UI.SetActive(true);
    }
    public void work_out(){
        Soundmanager.Instance.Playsound("out_btn");
        Work_UI.SetActive(false);
    }
    public void diary_open(){
        Soundmanager.Instance.Playsound("in_btn");
        diary_UI.SetActive(true);
    }
    public void diary_close(){
        Soundmanager.Instance.Playsound("out_btn");
        diary_UI.SetActive(false);
    }
    public void option_open(){
        Soundmanager.Instance.Playsound("in_btn");
        option_UI.SetActive(true);
    }
    public void option_close(){
        Soundmanager.Instance.Playsound("out_btn");
        option_UI.SetActive(false);
    }

    public void goto_nogada(){
        Soundmanager.Instance.Playsound("in_btn");
        nogada_loading.SetActive(true);
    }
    public void goto_store(){
        Soundmanager.Instance.Playsound("in_btn");
        store_loading.SetActive(true);
    }
    public void goto_food(){
        Soundmanager.Instance.Playsound("in_btn");
        food_loading.SetActive(true);
    }

    public void travel()
    {
        Soundmanager.Instance.Playsound("in_btn");
        travel_loading.SetActive(true);
    }
}
