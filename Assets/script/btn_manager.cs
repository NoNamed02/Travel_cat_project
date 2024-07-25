using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_manager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public List<GameObject> loadings = new List<GameObject>();
    
    public GameObject Loading;
    public GameObject Loading2;

    public bool is_reset = false;

    void Start()
    {
        if(is_reset == true)
            GAMEMANAGER.Instance.DeleteSavedData();
        Button[] foundButtons = GetComponentsInChildren<Button>();
        buttons.AddRange(foundButtons);

        foreach (Button btn in buttons)
        {
            if (btn.name == "StartButton")
            {
                btn.onClick.AddListener(() => StartLoading("Loading1"));
            }
            else if (btn.name == "ExitButton")
            {
                btn.onClick.AddListener(() => ExitGame());
            }
            else if (btn.name == "rest_btn")
            {
                btn.onClick.AddListener(() => StartLoading("rest_action"));
            }
            else if (btn.name == "work_btn")
            {
                btn.onClick.AddListener(() => StartLoading("Loading2"));
            }
            else if (btn.name == "travel_btn")
            {
                btn.onClick.AddListener(() => StartLoading("Loading3"));
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GAMEMANAGER.Instance.Load();
            if (PlayerPrefs.HasKey("Happy") && PlayerPrefs.HasKey("Stamina") && PlayerPrefs.HasKey("Money"))
            {
                FunctionA();
            }
            else
            {
                FunctionB();
            }
        }
    }

    void FunctionA()
    {
        Debug.Log("세이브된 데이터가 있습니다. A 기능 실행");
        GAMEMANAGER.Instance.Load();
        Loading2.SetActive(true);
    }

    void FunctionB()
    {
        Debug.Log("세이브된 데이터가 없습니다. B 기능 실행");
        Loading.SetActive(true);
    }

    void StartLoading(string loading_name)
    {
        foreach (GameObject loading in loadings)
        {
            loading.SetActive(false);
        }

        GameObject loadingToActivate = loadings.Find(l => l.name == loading_name);
        if (loadingToActivate != null)
        {
            loadingToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("해당 이름을 가진 로딩 화면을 찾을 수 없습니다: " + loading_name);
        }
    }

    void ExitGame()
    {
        Application.Quit(); // 빌드된 상태에서만 동작
    }
}
