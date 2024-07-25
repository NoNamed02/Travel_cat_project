using TMPro;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    private static GAMEMANAGER instance;

    public float happy = 100;
    public float stemina = 100;
    public int money = 100;

    public float Max_value = 100;

    public float pre_stemina;
    public int travel_left = 10;

    public int where = 0;
    public int how = 0;

    public string rank = "A";

    public int choice_place =  0;

    public int travel_time = 150;

    public int travel_happy = 0;
    private float timePassed;

    public bool[] travel_place = new bool[3];

    public bool[] travel_keyring = new bool[3];

    public bool is_ending = false;
    public bool is_no_stemina = false;

    public static GAMEMANAGER Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GAMEMANAGER>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GAMEMANAGER>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Initialize()
    {
        // 초기화 코드 작성
    }

    void Update()
    {
        // 값 범위 제한
        if (stemina > Max_value)
            stemina = Max_value;
        if (happy > Max_value)
            happy = Max_value;
        if (stemina < 0)
            stemina = 0;
        if (happy < 0)
            happy = 0;

        timePassed += Time.deltaTime;
        if (timePassed >= 60.0f)
        {
            travel_time--;
            timePassed = 0.0f;
        }
        if(travel_happy < 100){
            rank = "B";
        } 
        else if(travel_happy >= 100){
            rank = "A";
        }
    }

    // 저장 기능 구현
    public void Save()
    {
        PlayerPrefs.SetFloat("Happy", happy);
        PlayerPrefs.SetFloat("Stamina", stemina);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("TravelLeft", travel_left);
        PlayerPrefs.SetInt("Where", where);
        PlayerPrefs.SetInt("How", how);
        PlayerPrefs.SetString("Rank", rank);
        PlayerPrefs.SetInt("ChoicePlace", choice_place);

        PlayerPrefs.Save(); // 변경된 값들을 저장
    }

    // 불러오기 기능 구현
    public void Load()
    {
        if (PlayerPrefs.HasKey("Happy"))
            happy = PlayerPrefs.GetFloat("Happy");
        if (PlayerPrefs.HasKey("Stamina"))
            stemina = PlayerPrefs.GetFloat("Stamina");
        if (PlayerPrefs.HasKey("Money"))
            money = PlayerPrefs.GetInt("Money");
        if (PlayerPrefs.HasKey("TravelLeft"))
            travel_left = PlayerPrefs.GetInt("TravelLeft");
        if (PlayerPrefs.HasKey("Where"))
            where = PlayerPrefs.GetInt("Where");
        if (PlayerPrefs.HasKey("How"))
            how = PlayerPrefs.GetInt("How");
        if (PlayerPrefs.HasKey("Rank"))
            rank = PlayerPrefs.GetString("Rank");
        if (PlayerPrefs.HasKey("ChoicePlace"))
            choice_place = PlayerPrefs.GetInt("ChoicePlace");
    }

    public void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Saved data deleted.");
    }
}
