using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingGame3 : MonoBehaviour
{
    //hand position
    private static Vector3 jointPos = Vector3.zero;
    //joint type 
    private KinectInterop.JointType joint;
    private void FixedUpdate()  
    {
        //initializing hand joint based on player selection
        if (ThirdGameMenu.tempHand == 0)
        {
            joint = KinectInterop.JointType.HandLeft;
        }
        else joint = KinectInterop.JointType.HandRight; 
        
        KinectManager kinectManager = KinectManager.Instance;
        //checking is tke kinect is connected and intialized
        if (kinectManager && kinectManager.IsInitialized()) 
        {
            //checking for the users presence
            if (kinectManager.IsUserDetected())
            {
                long userID = kinectManager.GetPrimaryUserID();
                if (kinectManager.IsJointTracked(userID, (int)joint))
                {
                    //constant value for y-axis position throughout the game 
                    jointPos = kinectManager.GetJointPosition(userID, (int)joint);
                    jointPos.z = 0;
                    jointPos.y *= 15;
                    jointPos.y -= 15;
                    
                    if (BaseCollision.index < 2)
                    {
                        //Kinect x-axis movement regarding a reference point located at (-20,0,0)
                        jointPos.x *= 30f;
                        jointPos.x -= 20;
                    }
                    if (BaseCollision.index == 2)
                    {
                        //Kinect x-axis movement regarding a reference point located at (0,0,0)
                        jointPos.x *= 30f;
                    }
                    if (BaseCollision.index >= 3 && BaseCollision.index < 5 )
                    {
                        //Kinect x-axis movement regarding a reference point located at (10,0,0)
                        jointPos.x *= 30f;
                        jointPos.x += 10;
                    }
                    if (BaseCollision.index >= 5)
                    {
                        //Kinect x-axis movement regarding a reference point located at (20,0,0)
                        jointPos.x *= 30f;
                        jointPos.x += 20;
                    }
                    transform.position = jointPos;

                }
            }
        }
    }
}
