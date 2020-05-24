using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    void Update()
    {
        StartCoroutine(FadeOut(4, 1));
    }
    
    IEnumerator FadeOut(int seconds,  int levelIndex)
    {
        levelToLoad = levelIndex;
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
