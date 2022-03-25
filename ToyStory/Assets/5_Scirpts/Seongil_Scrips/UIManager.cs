using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUi;
    public GameObject player;
    public GameObject menu_camera;
    public GameObject game_camera;
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
}
