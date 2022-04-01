using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class LoadingSceneController : MonoBehaviour
{
    static LoadingSceneController instance;

    public static LoadingSceneController Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<LoadingSceneController>();
                
                if (obj != null)
                    instance = obj;
                else
                    instance = Create();
            }
            return instance;
        }
    }

    [SerializeField] Image progressBar;
    [SerializeField] CanvasGroup canvasGroup;

    string loadSceneName;
    bool isWait;
    static LoadingSceneController Create()
    {
        var loadPrefab = Resources.Load<LoadingSceneController>("LoadScene");
        return Instantiate(loadPrefab);
    }
    
    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName) // 씬 불러오는 함수
    {
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        loadSceneName = sceneName;
        StartCoroutine(Load());

    }

    IEnumerator Load()
    {
        progressBar.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        AsyncOperation async = SceneManager.LoadSceneAsync(loadSceneName);
        async.allowSceneActivation = false;

        float timer = 0f;
        while (!async.isDone)
        {
            yield return null;

            timer += Time.unscaledTime * 0.001f; // 수정
            if (progressBar.fillAmount < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(0, async.progress, timer);
                progressBar.color = Color.Lerp(Color.red, Color.green, timer);
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1, timer * 0.1f);
                progressBar.color = Color.Lerp(progressBar.color, Color.green, timer);
                if (progressBar.fillAmount >= 0.99999f)
                {
                    async.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledTime * 0.001f; // 이 부분 나중에 수정
            canvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);

        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }

    void LoadSceneEnd(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= LoadSceneEnd;
        }
    }
}
