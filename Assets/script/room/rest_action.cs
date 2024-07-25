using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rest_action : MonoBehaviour
{
    public Slider stemina;
    public GameObject button1;
    public GameObject button2;

    public bool is_end = false;

    public bool stemina_heal = false;

    void Start()
    {
        stemina.value = GAMEMANAGER.Instance.stemina;
    }

    void Update()
    {
        if (!is_end)
        {
            button1.SetActive(false);
            button2.SetActive(true);
        }
        else
        {
            button1.SetActive(true);
            button2.SetActive(false);
        }
    }

    public void OK()
    {
        Soundmanager.Instance.Playsound("in_btn");
        GAMEMANAGER.Instance.travel_time -= 30;
        GAMEMANAGER.Instance.money -= 20;
        gameObject.SetActive(false);
        //is_end = true;
    }

    public IEnumerator IncreaseStaminaSmoothly()
    {
        stemina_heal = true;
        float targetStamina = GAMEMANAGER.Instance.stemina + 20;
        float increaseSpeed = 10f; // 초당 증가 속도

        while (GAMEMANAGER.Instance.stemina < targetStamina && stemina_heal == true)
        {
            GAMEMANAGER.Instance.stemina += increaseSpeed * Time.deltaTime;
            stemina.value = GAMEMANAGER.Instance.stemina;
            if(GAMEMANAGER.Instance.stemina >= 100)
                break;
            yield return null;
        }
        GAMEMANAGER.Instance.happy += 10;
        yield return new WaitForSeconds(1f);
        is_end = true;
        //gameObject.SetActive(false);
    }

    public void cancel()
    {
        Soundmanager.Instance.Playsound("out_btn");
        stemina_heal = false;
        GAMEMANAGER.Instance.stemina = GAMEMANAGER.Instance.pre_stemina;
        gameObject.SetActive(false);
    }
}
