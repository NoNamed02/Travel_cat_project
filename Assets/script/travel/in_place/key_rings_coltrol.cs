using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_rings_control : MonoBehaviour
{
    public GameObject [] key_ring_image = new GameObject[3];
    public GameObject already_buy_image;

    // Update is called once per frame
    void Update()
    {
        if((GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1) && GAMEMANAGER.Instance.travel_keyring[0] == false){
            key_ring_image[0].SetActive(true);
            key_ring_image[1].SetActive(false);
            key_ring_image[2].SetActive(false);
            already_buy_image.SetActive(false);
        }
        else if((GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3) && GAMEMANAGER.Instance.travel_keyring[1] == false){
            key_ring_image[0].SetActive(false);
            key_ring_image[1].SetActive(true);
            key_ring_image[2].SetActive(false);
            already_buy_image.SetActive(false);
        }
        else if((GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5) && GAMEMANAGER.Instance.travel_keyring[2] == false){
            key_ring_image[0].SetActive(false);
            key_ring_image[1].SetActive(false);
            key_ring_image[2].SetActive(true);
            already_buy_image.SetActive(false);
        }
        else
            already_buy_image.SetActive(true);
    }
}
