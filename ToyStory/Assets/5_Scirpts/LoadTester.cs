using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadingSceneController.Instance.LoadScene("SphereTest");
        }
            
    }
}
