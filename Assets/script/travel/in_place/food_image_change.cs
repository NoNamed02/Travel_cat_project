using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_image_change : MonoBehaviour
{
    public GameObject [] food_image = new GameObject[3];
    void Update()
    {
        if(GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1){
            food_image[0].SetActive(true);
            food_image[1].SetActive(false);
            food_image[2].SetActive(false);
        }
        else if(GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3){
            food_image[0].SetActive(false);
            food_image[1].SetActive(true);
            food_image[2].SetActive(false);
        }
        else if(GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5){
            food_image[0].SetActive(false);
            food_image[1].SetActive(false);
            food_image[2].SetActive(true);
        }
    }
}
