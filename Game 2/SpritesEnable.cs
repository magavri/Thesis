using UnityEngine;

public class SpritesEnable : MonoBehaviour
{
    //left hand sprite
    public GameObject leftHand;
    //right hand sprite
    public GameObject rightHand;
    //score canvas
    public GameObject endMenu;
    //text informing about goal achievement
    public GameObject goalText;
    //game end time
    public static float endTime = 0;
    private void Start()
    {
        //enabling the hand sprite based on selected option
        if (SecondGameMenu.tempHand == 0)
        {
            leftHand.gameObject.SetActive(true);
        }
        else rightHand.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        if (CollisionDetect.goal == SecondGameMenu.tempGoal)
        {
            //setting the game end time after the goal was achieved
            if (endTime == 0)
            {
                endTime = Time.time;
            }
            //enabling score canvas
            endMenu.gameObject.SetActive(true);
            //enabling text to notify the user
            goalText.gameObject.SetActive(true);
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
}
