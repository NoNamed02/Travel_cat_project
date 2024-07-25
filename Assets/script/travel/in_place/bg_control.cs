using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_control : MonoBehaviour
{
    public GameObject[] bg = new GameObject[3];

    // Update is called once per frame
    void Update()
    {
        if(GAMEMANAGER.Instance.where > -1 && GAMEMANAGER.Instance.where <= 1)
            bg[0].SetActive(true);
        else if(GAMEMANAGER.Instance.where > 1 && GAMEMANAGER.Instance.where <= 3)
            bg[1].SetActive(true);
        else if(GAMEMANAGER.Instance.where > 3 && GAMEMANAGER.Instance.where <= 5)
            bg[2].SetActive(true);
    }
}
