using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstGameMenu : MonoBehaviour
{
    //slider with the speed options
    public Slider speed;
    //range of motion limit
    public static int limit;
    //speed of the moving obstacles
    public static int tempSpeed;
    private void Update()
    {
        LimitSpeed(speed.value);
    }
    /// <summary>
    /// Loading scene with the game
    /// </summary>
    public void PlayGame()
    {
        Score.sumL = 0;
        Score.sumR = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /// <summary>
    /// Loading back menu scene
    /// </summary>
    public void QuitGame()
    {
        SceneManager.LoadScene(1);
    }
   /// <summary>
   /// Getting the limit value from slider
   /// </summary>
   /// <param name="value"></param>
    public void LimitRange(float value)
    {
        if (value == 0)
        {
            limit = 130;
        }
        if (value == 1)
        {
            limit = 90;
        }
        if (value == 2)
        {
            limit = 130;
        }
    }
   /// <summary>
   /// Getting speed value from slider
   /// </summary>
   /// <param name="value"></param>
    public void LimitSpeed(float value)
    {
        if (value == 0)
        {
            tempSpeed = 1;
        }
        if (value == 1)
        {
            tempSpeed = 2;
        }
        if (value == 2)
        {
            tempSpeed = 4;
        }
    }
    
    
}
