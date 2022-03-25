using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUi;
    public GameObject player;
    public void GameStart()
    {
        player.SetActive(true);
        mainUi.SetActive(false);
    }

    public void GameExit()
    {
        Debug.Log("게임이 종료되었습니다.");
        Application.Quit();
    }
}
