using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_how : MonoBehaviour
{
    public int set;
    public void how(){
        GAMEMANAGER.Instance.how = set;
    }
}
