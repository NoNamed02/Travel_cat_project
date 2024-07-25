using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nogada_move : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 움직이는 속도
    private bool move_right = true;
    public GameObject loading;

    private int count = 0;
    private bool is_true = false;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveSpeed, 0f,0f);
        if(transform.position.x < 1.5 && move_right){
            transform.position += move;
            animator.SetInteger("ani",0);
        }
        else{
            count++;
            move_right = false;
        }
        
        if(transform.position.x > -1.5 && !move_right){
            transform.position -= move;
            animator.SetInteger("ani",1);
        } 
        else{
            count++;
            move_right = true;
        }


        if(count >= 200){
            GAMEMANAGER.Instance.money += 10;
            GAMEMANAGER.Instance.happy -= 3;
            GAMEMANAGER.Instance.stemina -= 5;
            count = 0;
        }
        if(GAMEMANAGER.Instance.stemina <= 20){
            GAMEMANAGER.Instance.is_no_stemina = true;
            goto_room();
        }
        
    }

    void CheckEdgeAndTurn()
    {
        if (transform.position.x >= 1.5f && move_right)
        {
            // 오른쪽 끝에 닿았을 때
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // 180도 회전
            move_right = false; // 방향 변경
        }
        else if (transform.position.x <= -1.5f && !move_right)
        {
            // 왼쪽 끝에 닿았을 때
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // 초기 방향으로 회전
            move_right = true; // 방향 변경
        }
    }

    public void goto_room(){
        loading.SetActive(true);
    }
}
