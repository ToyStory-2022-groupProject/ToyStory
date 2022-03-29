using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject initUi;
    public GameObject mainUi;
    public GameObject player;
    public GameObject menuCamera;
    public GameObject gameCamera;
    public GameObject subMenu;
    public GameObject settingMenu;
    public GameObject display;
    public GameObject sound;
    public GameObject keySetting;
    
    

    public bool isSub;
    bool isMain;
    bool isSetting;

    void Update()
    {
        OpenSub();
    }
    
    public void GameStart()
    {
        player.SetActive(true);
        menuCamera.SetActive(false);
        gameCamera.SetActive(true);
        initUi.SetActive(false);
        isSub = false;
        isMain = true;
    }

    public void GameExit()
    {
        Debug.Log("게임이 종료되었습니다.");
        Application.Quit();
    }
    
    public void BackToMain()
    {
        subMenu.SetActive(false);
        initUi = mainUi;
        initUi.SetActive(true);
        isMain = false;
    }
    
    void OpenSub()
    {
        if (!isSub && Input.GetButtonDown("Cancel") && isMain)
        {
            SubOn();
        }
        else if (isSub && Input.GetButtonDown("Cancel") && isMain)
        {
            if (isSetting)
            {
                SettingOff();
                Debug.Log("여기 들어왔다.");
            }
            else
                SubOff();
        } 
    }

    void SubOn()
    {
        menuCamera.SetActive(true);
        subMenu.SetActive(true);
        isSub = !isSub;
    }

    void SubOff()
    {
        menuCamera.SetActive(false);
        subMenu.SetActive(false);
        isSub = !isSub;
    }

    public void SettingOn()
    {
        subMenu.SetActive(false);
        settingMenu.SetActive(true);
        isSetting = true;
    }

    void SettingOff()
    {
        subMenu.SetActive(true);
        settingMenu.SetActive(false);   
        isSetting = false;
    }


}
