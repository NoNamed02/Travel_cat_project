using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ride_time : MonoBehaviour
{
    public Text text;
    [SerializeField] private float timer = 600.0f;
    public GameObject loading;
    public TextAsset txt;
    string[,] Sentence;
    int rowSize, colSize;

    public GameObject eventA;
    public GameObject eventB;

    public GameObject[] background = new GameObject[3];

    public float eventInterval = 10.0f;
    private float nextEventTime = 0.0f;

    void Start(){
        string currentText = txt.text.Trim(); 
        string[] lines = currentText.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries); 
        
        rowSize = lines.Length;
        colSize = lines[0].Split('\t').Length;

        Sentence = new string[rowSize, colSize];


        for (int i = 0; i < rowSize; i++)
        {
            string[] columns = lines[i].Split('\t');
            for (int j = 0; j < colSize; j++)
            {
                if (j < columns.Length)
                {
                    Sentence[i, j] = columns[j];
                }
                else
                {
                    Sentence[i, j] = "";
                }
                Debug.Log(i + "," + j + "," + Sentence[i, j]);
            }
        }
        timer = float.Parse(Sentence[GAMEMANAGER.Instance.how, GAMEMANAGER.Instance.where+1]);
        background[GAMEMANAGER.Instance.how-1].SetActive(true);

        nextEventTime = timer - eventInterval;


        //GAMEMANAGER.Instance.travel_place[GAMEMANAGER.Instance.where] = true; 원래 코드
        if(GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1)
            GAMEMANAGER.Instance.travel_place[0] = true;
        else if(GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3)
            GAMEMANAGER.Instance.travel_place[1] = true;
        else if(GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5)
            GAMEMANAGER.Instance.travel_place[2] = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= nextEventTime)
        {
            int i = Random.Range(1, 11);
            if(i >= 1 && i < 4)
                AFunction();
            else if(i >= 4 && i < 7)
                BFunction();
            else
                Debug.Log("닷지");
            nextEventTime -= eventInterval;
        }

        if (timer < 0)
        {
            timer = 0;
            GAMEMANAGER.Instance.travel_left = 5;
            loading.SetActive(true);
        }

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        text.text = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
    }

    void AFunction()
    {
        Debug.Log("A 함수 실행");
        eventA.SetActive(true);
        GAMEMANAGER.Instance.happy -= 20;
    }
    void BFunction()
    {
        Debug.Log("B 함수 실행");
        eventB.SetActive(true);
        GAMEMANAGER.Instance.happy += 20;
    }
}
