using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travel_land_choice : MonoBehaviour
{
    public travel_change_place travel_Change_Place;
    public int i = 0;
    //public int j = 0;
    public void choice(){
        GAMEMANAGER.Instance.choice_place = i;
        travel_Change_Place.i = i;
    }
}
