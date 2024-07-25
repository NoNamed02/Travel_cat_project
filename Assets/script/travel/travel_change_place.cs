using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travel_change_place : MonoBehaviour
{
    public GameObject []place = new GameObject[4];

    public int i = 0;


    void Update()
    {
        for(int j = 0; j < 6 ; j++){
            if(i == j)
                place[j].SetActive(true);
            else
                place[j].SetActive(false);
        }
        if(GAMEMANAGER.Instance.choice_place == 0){
            if(i == 2){
                i = 0;
            }
            else if(i == -1){
                i = 1;
            }
        }
        else if(GAMEMANAGER.Instance.choice_place == 2){
            if(i == 4){
                i = 2;
            }
            else if(i == 1){
                i = 3;
            }
        }
        else if(GAMEMANAGER.Instance.choice_place == 4){
            if(i == 6){
                i = 4;
            }
            else if(i == 3){
                i = 5;
            }
        }
        
        GAMEMANAGER.Instance.where = i;
    }

    public void next(){
        Soundmanager.Instance.Playsound("in_btn");
        i++;
        GAMEMANAGER.Instance.where = i;
    }
    public void back(){
        Soundmanager.Instance.Playsound("in_btn");
        i--;
        GAMEMANAGER.Instance.where = i;
    }
}
