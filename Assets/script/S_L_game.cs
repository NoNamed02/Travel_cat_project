using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_L_game : MonoBehaviour
{
    public void save(){
        GAMEMANAGER.Instance.Save();
    }
    public void load(){
        GAMEMANAGER.Instance.Load();
    }
}
