using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void LoadFirstGame()
    {
        SceneManager.LoadScene(2); 
    }

    public void LoadSecondGame()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadThirdGame()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadFourthGame()
    {
        SceneManager.LoadScene(8);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
