using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    Animator anim;

    // 골드를 몇 초마다 지급하는지 초를 정해주는 변수입니다.
    public float GoldGetTime = 3;

    // 골드를 얼마나 얻을지에 대한 변수입니다.
    public float GoldValue = 10;

    

    // 컴퓨터가 고장나는 시간 변수입니다.
    [SerializeField]
    float BreakTime;
    [SerializeField]
    float BrokenTime = 10;

    private float moneyGetTime;

    // 고양이가 앉아 있냐 를 뜻하는 변수입니다.
    public bool IsSit = false;

    // 컴퓨터가 부셔졌나 를 뜻하는 변수
    public bool IsBreak = false;

    // 고양이가 일을 하고 있는가를 뜻하는 변수입니다
    public bool IsWork = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (IsSit == true && IsBreak == false && IsWork == true)
        {
            moneyGetTime += Time.deltaTime;
            if (moneyGetTime >= GoldGetTime)
            {
                moneyGetTime -= GoldGetTime;
                GameManager.gold += GoldValue;
            }
            BreakTime += Time.deltaTime;
            if (BreakTime >= BrokenTime) 
            {
                IsBreak = true;
            }
        }

        else if (IsSit == false)
        {
            IsBreak = false;
            IsWork = false;
            BreakTime = 0;
        }

        if (IsBreak == true)
        {
            moneyGetTime = 0;
            IsWork = false;
            anim.SetBool("IsBroken", true);
        }
        else if (IsBreak == false)
        {
            anim.SetBool("IsBroken", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            IsSit = true;
            if (IsSit == true)
                IsWork = true;
            else if (IsSit == true && IsBreak == true)
                IsWork = false;
            Debug.Log("지금 작동중입니다.");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            IsSit = false;
            Debug.Log("작동이 끝났습니다.");
        }
    }
}
