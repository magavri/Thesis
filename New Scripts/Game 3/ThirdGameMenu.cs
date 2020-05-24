using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdGameMenu : MonoBehaviour
{
    public Toggle leftHand;
    public Toggle rightHad;
    //hand selection temp variable
    public static int tempHand;
    //game start time
    public static float startTime;
    
    
    /// <summary>
    /// Checking for the final hand selection
    /// and loading game scene
    /// </summary>
    public void PlayGame()
    {
        ActiveToggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        startTime = Time.time;
        SpriteSwipe.endTime = 0;
        BaseCollision.endTime = 0;
    }
    
    /// <summary>
    /// going back to game menu
    /// </summary>
    public void QuitGame()
    {
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// Assigning temporary value based on hand selection
    /// </summary>
    public void ActiveToggle()
    {
        if (leftHand.isOn)
        {
            tempHand = 0;
        }
        else if (rightHad.isOn)
        {
            tempHand = 1;
        }
    }
}
