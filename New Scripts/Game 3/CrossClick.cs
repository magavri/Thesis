using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossClick : MonoBehaviour
{
    Color newColor = new Color(0.8f, 0.8f, 0.8f, 1f);
    /// <summary>
    /// Returning back to menu scene
    /// </summary>
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
        PickBox.index = 1;
        BaseCollision.index = 0;
        DataCollection.ThirdGameData();
    }

    /// <summary>
    /// Changing the sprite colour when the mouse is over
    /// </summary>
    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
    /// <summary>
    /// Changing back to original colour
    /// </summary>
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
