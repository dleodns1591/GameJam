using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{

    public GameObject button;
    public void GameStart() 
    {
        GameManager.IsGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void GoTitle() 
    {
        SceneManager.LoadScene(0);
    }
    public void Credit()
    {
        SceneManager.LoadScene(2);
    }
    public void GameQuit() 
    {
        Application.Quit();
    }
    public void LockedOff2() 
    {
        Floor2System.ClickButton = true;
        if (GameManager.gold >= 800) 
        {
            GameManager.gold -= 800;
            button.SetActive(false);
        }
    }
    public void LockedOff3()
    {
            Floor3System.ClickButton2 = true;
        if (Cat_Manager.Inst.BuyFloor_Idx == 1)
        {
            GameManager.gold -= 3000;
            button.SetActive(false);
        }
    }
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
