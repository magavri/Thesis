using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    //final score for the left hand
    public Text finalLeft;
    //final score for the right hand
    public Text finalRight;
    //menu with the score
    public Canvas canvas;

    /// <summary>
    /// Converting the int result to string and displaying to the user
    /// </summary>
    public void FinalScore ()
    {
        StartCoroutine(EnableAfterSeconds(6, canvas));
        string tempL = Score.sumL.ToString();
        string tempR = Score.sumR.ToString();
        finalLeft.text = tempL;
        finalRight.text = tempR;
        //finalLeft.text = temp+"/"+CreateObjects.amount; //in case if the amount will change
    }
    /// <summary>
    /// Enabling final score menu after a set time
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="canvas"></param>
    /// <returns></returns>
    IEnumerator EnableAfterSeconds(int seconds, Canvas canvas)
    {
        yield return new WaitForSeconds(seconds);
        canvas.gameObject.SetActive(true);
    }
    /// <summary>
    /// Returning back to menu and saving collected data to the file
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        DataCollection.FirstGameData(); //save the game score to the file
    }

}
