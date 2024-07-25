using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt_manager : MonoBehaviour
{
    public TextAsset txt;
    public TextAsset txt2;
    public TextAsset txt3;
    string[,] Sentence;
    int rowSize, colSize;

    public Text Name;
    public Text chat;
    public int currentLine = 0;

    private bool next = false;
    private bool can_talk = true;

    public GameObject Loading_back;

    public GameObject food_UI;

    public GameObject shop_UI;

    public Button travel;
    public Button shop;
    public Button shop_back;
    public Button food;
    public Button food_back;
    public Text text;
    

    void Start()
    {
        Name.GetComponent<Text>();
        chat.GetComponent<Text>();
        

        if(GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1){
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
        }
        else if(GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3){
            string currentText = txt2.text.Trim(); 
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
        }
        else if(GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5){
            string currentText = txt3.text.Trim(); 
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
        }
        strar_chat();
    }

    void strar_chat(){
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentLine < rowSize)
        {
            Name.text = Sentence[currentLine, 1];
            chat.text = Sentence[currentLine, 2];
        }

        /////////////////////////////////////////////
        if(Sentence[currentLine, 3] == "1"){
            travel.gameObject.SetActive(true);
            shop.gameObject.SetActive(true);
            food.gameObject.SetActive(true);
        }
        else{
            travel.gameObject.SetActive(false);
            shop.gameObject.SetActive(false);
            food.gameObject.SetActive(false);
        }
        if(Sentence[currentLine+1,2]!="end"){
            Soundmanager.Instance.Playsound("next_talk");
            currentLine++;
        }
    }

    IEnumerator next_scence(){
        yield return new WaitForSeconds(2);
        //Loading.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)  && can_talk)
        {
            DisplayNextSentence();
        }
        text.text = (GAMEMANAGER.Instance.travel_time/60).ToString() + "시간 " + (GAMEMANAGER.Instance.travel_time%60).ToString()
        + "분 남았다냥";
    }

    public void travel_action(){
        GAMEMANAGER.Instance.stemina -= 5;
        GAMEMANAGER.Instance.happy += 15;
        
        GAMEMANAGER.Instance.travel_happy += 15;
        GAMEMANAGER.Instance.travel_time -= 20;
        Soundmanager.Instance.Playsound("in_btn");
        int i = Random.Range(1,4);
        if(i == 1){
            currentLine = 13;
            DisplayNextSentence();
        }
        else if(i == 2){
            currentLine = 18;
            DisplayNextSentence();
        }
        else if(i == 3){
            currentLine = 24;
            DisplayNextSentence();
        }
        //GAMEMANAGER.Instance.travel_left--;
    }

    public void shop_action(){
        Soundmanager.Instance.Playsound("in_btn");
        shop_UI.SetActive(true);
    }
    public void shop_back_btn(){
        Soundmanager.Instance.Playsound("out_btn");
        shop_UI.SetActive(false);
        //GAMEMANAGER.Instance.travel_left--;
        GAMEMANAGER.Instance.stemina -= 5;
        GAMEMANAGER.Instance.happy += 10;
        GAMEMANAGER.Instance.travel_happy += 10;
        GAMEMANAGER.Instance.travel_time -= 30;
    }
    public void food_action(){
        Soundmanager.Instance.Playsound("in_btn");
        food_UI.SetActive(true);
    }

    public void food_back_btn(){
        Soundmanager.Instance.Playsound("out_btn");
        food_UI.SetActive(false);
        //GAMEMANAGER.Instance.travel_left--;
        //GAMEMANAGER.Instance.travel_time -= 30;
        currentLine = 27;
        strar_chat();
    }
    public void food_eat_btn(){
        Soundmanager.Instance.Playsound("in_btn");
        food_UI.SetActive(false);
        //GAMEMANAGER.Instance.travel_left--;
        GAMEMANAGER.Instance.travel_time -= 30;
        GAMEMANAGER.Instance.money -= 20;
        GAMEMANAGER.Instance.happy += 10;
        GAMEMANAGER.Instance.travel_happy += 10;
        currentLine = 27;
        strar_chat();
    }

    public void loading_back(){
        Soundmanager.Instance.Playsound("out_btn");
        Loading_back.SetActive(true);
    }


    public void buy_keyring(){
        Soundmanager.Instance.Playsound("money");
        GAMEMANAGER.Instance.money -= 30;
        if((GAMEMANAGER.Instance.where == 0 || GAMEMANAGER.Instance.where == 1) && GAMEMANAGER.Instance.travel_keyring[0] == false)
            GAMEMANAGER.Instance.travel_keyring[0] = true;
        else if(GAMEMANAGER.Instance.where == 2 || GAMEMANAGER.Instance.where == 3 && GAMEMANAGER.Instance.travel_keyring[1] == false)
            GAMEMANAGER.Instance.travel_keyring[1] = true;
        else if(GAMEMANAGER.Instance.where == 4 || GAMEMANAGER.Instance.where == 5 && GAMEMANAGER.Instance.travel_keyring[2] == false)
            GAMEMANAGER.Instance.travel_keyring[2] = true;
    }
}