using UnityEngine;

public class HandSpriteEnable : MonoBehaviour
{
    //left hand sprite
    public GameObject leftHand;
    //right hand sprite
    public GameObject rightHand;
    private void Start()
    {
        //enabling the hand sprite based on selected option
        if (ThirdGameMenu.tempHand == 0)
        {
            leftHand.gameObject.SetActive(true);
        }
        else rightHand.gameObject.SetActive(true);
    }
}
