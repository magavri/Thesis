using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondGameMenu : MonoBehaviour
{
    //slider for selecting the goal value
    public Slider goal;
    //hand options
    public Toggle leftHand;
    public Toggle rightHad;
    //selected goal value
    public static int tempGoal;
    //hand selection temp variable
    public static int tempHand;
    //game start time
    public static float startTime;

    private void Update()
    {
        SetGoal(goal.value);
    }

    /// <summary>
    /// Checking for the final hand selection
    /// and loading game scene
    /// </summary>
    public void PlayGame()
    {
        ActiveToggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        startTime = Time.time;
        CollisionDetect.goal = 0;
        SpritesEnable.endTime = 0;
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
    /// <summary>
    /// Assigning goal value
    /// </summary>
    /// <param name="value"></param>
    public void SetGoal(float value)
    {
        if (value == 0)
        {
            tempGoal = 10;
        }
        if (value == 1)
        {
            tempGoal = 20;
        }
        if (value == 2)
        {
            tempGoal = 30;
        }
    }
  
}
