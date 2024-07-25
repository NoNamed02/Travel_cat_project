using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_move : MonoBehaviour
{
    [SerializeField]private int count = 0;
    public GameObject loading;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count >= 80){
            Soundmanager.Instance.Playsound("coin");
            GAMEMANAGER.Instance.money += 8;
            GAMEMANAGER.Instance.happy -= 2;
            GAMEMANAGER.Instance.stemina -= 4;
            count = 0;
        }
        if(GAMEMANAGER.Instance.stemina <= 20){
            GAMEMANAGER.Instance.is_no_stemina = true;
            loading.SetActive(true);
        }
    }

    
    public void goto_room(){
        loading.SetActive(true);
    }
}
