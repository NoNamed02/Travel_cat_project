using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place_UI : MonoBehaviour
{
    public GameObject []photo = new GameObject[3];
    public GameObject []keyring = new GameObject[3];
    public GameObject place_no;
    public GameObject keyring_no;
    void Update()
    {
        for(int i = 0; i < 3; i++){
            if(GAMEMANAGER.Instance.travel_place[i]){
                photo[i].SetActive(true);
                place_no.SetActive(false);
            }
            else{
                photo[i].SetActive(false);
                place_no.SetActive(true);
            }

            if(GAMEMANAGER.Instance.travel_keyring[i]){
                keyring[i].SetActive(true);
                keyring_no.SetActive(false);
            }
            else{
                keyring[i].SetActive(false);
                keyring_no.SetActive(true);
            }
        }
        
    }
}
