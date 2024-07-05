using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    public GameObject transition;
    public Image transitionImage;
    public float fadeDuration = 1.0f;

    private void Awake()
    {
        // 确保只有一个TransitionManager实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 开始时淡入
        DontDestroyOnLoad(transition);
        StartCoroutine(FadeIn());
    }

    public void SwitchScene(string sceneName)
    {
        
        StartCoroutine(FadeOutIn(sceneName));
    }

    private IEnumerator FadeIn()
    {
        transition.SetActive(true);
        float elapsedTime = 0.0f;
        Color color = transitionImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1.0f - (elapsedTime / fadeDuration));
            transitionImage.color = color;
            yield return null;
        }

        color.a = 0.0f;
        transitionImage.color = color;
    }

    private IEnumerator FadeOutIn(string sceneName)
    {
        transition.SetActive(true);
        float elapsedTime = 0.0f;
        Color color = transitionImage.color;

        // 淡出
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            transitionImage.color = color;
            yield return null;
        }

        color.a = 1.0f;
        transitionImage.color = color;

        // 加载新场景
        SceneManager.LoadScene(sceneName);
        yield return null;

        // 确保场景加载完成
        yield return new WaitForEndOfFrame();

        // 在新场景中淡入
        elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1.0f - (elapsedTime / fadeDuration));
            transitionImage.color = color;
            yield return null;
        }

        color.a = 0.0f;
        transitionImage.color = color;
    }
}

