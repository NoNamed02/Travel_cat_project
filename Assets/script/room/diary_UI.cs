using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diary_UI : MonoBehaviour
{
    public GameObject [] place = new GameObject[3];
    public int i = 0;

    void Update()
    {
        for(int j = 0; j < 3; j++){
            if(i == j)
                place[j].SetActive(true);
            else
                place[j].SetActive(false);
        }
        if(i == 3) i = 0;
        else if(i == -1) i = 2;
    }
    public void up(){
        Soundmanager.Instance.Playsound("book");
        i++;
    }
    public void down(){
        Soundmanager.Instance.Playsound("book");
        i--;
    }
}
