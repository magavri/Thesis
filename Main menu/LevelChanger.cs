using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    //animator with scene change
    public Animator animator;
    //loading level index
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
}
