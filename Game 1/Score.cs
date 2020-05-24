using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //left hand score display
    public Text scoreLeft;
    //right hand score display
    public Text scoreRight; 
    //left hand score value
    public static int sumL = 0;
    //right hand score value
    public static int sumR = 0;

    /// <summary>
    /// Updates amount of hit obstacles for the left hand
    /// and displays value during the game
    /// </summary>
    public void ScoreLeft()
    {
        sumL++;
        scoreLeft.text = sumL.ToString();
    }
    /// <summary>
    /// Updates amount of hit obstacles for the right hand
    /// and displays value during the game
    /// </summary>
    public void ScoreRight()
    {
        sumR++;
        scoreRight.text = sumR.ToString();
    }
}
