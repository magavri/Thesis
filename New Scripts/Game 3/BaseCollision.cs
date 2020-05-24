using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollision : MonoBehaviour
{
    private static float heightMax = -5.74f;
    private static float heightMid = -6.57f;
    private static float heightMin = -6.75f;
    //height of the house part sprite
    private float height = 0f; 
    //temporary position for the house's base
    private Vector3 tempPosition;
    //shows the amount of houses completed
    public static int index = 0;
    //time completing the game
    public static float endTime;
    //score canvas
    public GameObject endMenu;
    public GameObject leftHand;
    //right hand sprite
    public GameObject rightHand;
    public GameObject car;
    
    private Vector3[] housePos =
    {
        new Vector3(-18.33f,heightMin),
        new Vector3(-6.5f,heightMax),
        new Vector3(6f,heightMin),
        new Vector3(12.9f,heightMid),
        new Vector3(26.5f,heightMin)

    };
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("HouseBox"))
        {
            other.transform.parent = null;
            other.gameObject.layer = 11;
            tempPosition = transform.position;
            other.gameObject.transform.position = transform.position;
            other.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            height = other.GetComponent<SpriteRenderer>().bounds.size.y - 0.1f;
            tempPosition.y += height;
            transform.position = tempPosition;
        }
        if (other.gameObject.tag.Contains("HouseBoxEnd"))
        {
            transform.position = housePos[index];  
            index++;
        }

        if (other.gameObject.tag.Contains("HouseBoxLast"))
        {
            if (endTime == 0)
            {
                endTime = Time.time;
            }
            //enabling score canvas
            StartCoroutine(EnableAfterSeconds(3, endMenu));
            //disabling the hand sprite
            if (leftHand.gameObject.activeSelf)
            {
                leftHand.gameObject.SetActive(false);
            }
            else
            {
                rightHand.gameObject.SetActive(false);
            }
            car.gameObject.SetActive(false);
        }

    }
    IEnumerator EnableAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.gameObject.SetActive(true);
    }
}
