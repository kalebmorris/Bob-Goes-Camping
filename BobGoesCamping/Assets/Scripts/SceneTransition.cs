using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    float t;
    bool canFade = false;
    [SerializeField]
    private float fadeDuration = 5f;
    [SerializeField]
    private ScreenTransitionImageEffect transition;
    [SerializeField]
    private Button playButton;


    IEnumerator Wait() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("HLScene");

    }

    public void ToGame()
    {
        playButton.interactable = false;
        t = 0.5f;
        canFade = true;
        StartCoroutine(Wait());
    }
    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ToIntro() 
    {
        SceneManager.LoadScene("Intro");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void EndGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (canFade) {
            t += Time.deltaTime / fadeDuration;
            transition.maskValue = Mathf.Lerp(0f, 1f, t);
        }
    }
}
