using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travel_end : MonoBehaviour
{
    public GameObject Loading;
    void Update()
    {
        if(GAMEMANAGER.Instance.travel_left <= 0 || GAMEMANAGER.Instance.travel_time <= 0){
            Loading.SetActive(true);
        }
    }
}
