using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ArrowClick : MonoBehaviour
{
    Color newColor = new Color(0.8f, 0.8f, 0.8f, 1f);
    /// <summary>
    /// Returning back to menu scene
    /// </summary>
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
        DataCollection.SecondGameData();
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
