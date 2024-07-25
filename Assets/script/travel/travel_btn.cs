using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class travel_btn : MonoBehaviour
{
    public GameObject detail_UI;
    public GameObject detail_back_btn;
    public GameObject ride_UI;
    public GameObject ride_back_btn;
    public GameObject end_UI;
    //public GameObject end_back_btn;
    public GameObject back_btn;
    public GameObject back_loading;
    public GameObject travel_loading;

    //public travel_change_place travel_Change_Place;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void choice_detail_place(){
        Soundmanager.Instance.Playsound("in_btn");
        detail_UI.SetActive(true);
        back_btn.SetActive(false);
    }
    public void cancel_detail(){
        Soundmanager.Instance.Playsound("out_btn");
        back_btn.SetActive(true);
        detail_UI.SetActive(false);
    }
    public void goto_ride(){
        Soundmanager.Instance.Playsound("in_btn");
        detail_UI.SetActive(false);
        detail_back_btn.SetActive(false);
        ride_UI.SetActive(true);
    }

    public void goto_end(){
        Soundmanager.Instance.Playsound("in_btn");
        ride_UI.SetActive(false);
        end_UI.SetActive(true);
    }
    public void cancel_ride(){
        Soundmanager.Instance.Playsound("out_btn");
        detail_UI.SetActive(true);
        detail_back_btn.SetActive(true);
        ride_UI.SetActive(false);
    }

    public void cancel_end(){
        Soundmanager.Instance.Playsound("out_btn");
        end_UI.SetActive(false);
        ride_UI.SetActive(true);
        ride_back_btn.SetActive(true);
    }

    public void back(){
        Soundmanager.Instance.Playsound("out_btn");
        back_loading.SetActive(true);
    }

    public void go_travel(){
        Soundmanager.Instance.Playsound("in_btn");
        travel_loading.SetActive(true);
    }
}
