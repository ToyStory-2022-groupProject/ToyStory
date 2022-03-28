using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUi;
    public GameObject player;
    public GameObject menu_camera;
    public GameObject game_camera;
    public GameObject subMenu;
    public Sphere sphere;
    
    public bool isSub;
    
    void Update()
    {
        OpenSub();
    }
    
    public void GameStart()
    {
        player.SetActive(true);
        menu_camera.SetActive(false);
        mainUi.SetActive(false);
        game_camera.SetActive(true);
    }

    public void GameExit()
    {
        Debug.Log("게임이 종료되었습니다.");
        Application.Quit();
    }
    
    void OpenSub()
    {
        if (!isSub && Input.GetButtonDown("Cancel"))
        {
            subMenu.SetActive(false);
            isSub = !isSub;
            sphere.isMenu = false;
        }
        else if (isSub && Input.GetButtonDown("Cancel"))
        {
            subMenu.SetActive(true);
            isSub = !isSub;
            sphere.isMenu = true;

        } 
    }
    
    void OnMenu()
    {
        Sphere sphere = GetComponent<Sphere>();
        //sphere.move.velocity = Vector3.zero;
    }

    void OffMenu()
    {
        
    }
}
