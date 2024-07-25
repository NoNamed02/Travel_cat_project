using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end_txt_manager : MonoBehaviour
{
    public TextAsset txt;
    string[,] Sentence;
    int rowSize, colSize;
    public Text chat;
    public int currentLine = 0;

    private bool next = false;
    private bool can_talk = true;
    public GameObject END_UI;
    public Button back_btn;

    void Start()
    {
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
        strar_chat();
    }

    void strar_chat(){
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentLine < rowSize)
        {
            chat.text = Sentence[currentLine, 2];
        }
        if(Sentence[currentLine, 3] == "1"){
            back_btn.gameObject.SetActive(true);
        }
        if(Sentence[currentLine+1,2]!="end"){
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
    }

    public void travel_action(){
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
        GAMEMANAGER.Instance.travel_left--;
    }

    public void back(){
        END_UI.SetActive(false);
    }
}