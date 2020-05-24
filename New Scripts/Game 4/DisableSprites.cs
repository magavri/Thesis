using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSprites : MonoBehaviour
{
    //score canvas
    public GameObject endMenu;
    public GameObject leftHand;
    //right hand sprite
    public GameObject rightHand;

    private void Update()
    {
        if (SpriteSwipe.tempEnd == 1)
        {
            //enabling score canvas
            StartCoroutine(EnableAfterSeconds(6, endMenu));
            //disabling the hand sprite
            if (leftHand.gameObject.activeSelf)
            {
                leftHand.gameObject.SetActive(false);
            }
            else
            {
                rightHand.gameObject.SetActive(false);
            }
        }
    }
    
    IEnumerator EnableAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.gameObject.SetActive(true);
    }
}
