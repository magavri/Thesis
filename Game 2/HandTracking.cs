using UnityEngine;

public class HandTracking : MonoBehaviour
{
    //hand position
    private static Vector3 jointPos = Vector3.zero;
    //joint type 
    private KinectInterop.JointType joint;
   private void FixedUpdate()
    {
        //assigning the type of joint based on user selection
        if (SecondGameMenu.tempHand == 0)
        {
            joint = KinectInterop.JointType.HandLeft;
        }
        else joint = KinectInterop.JointType.HandRight;
        KinectManager kinectManager = KinectManager.Instance;
        //checking is the kinect is connected and intialized
        if (kinectManager && kinectManager.IsInitialized())
        {
            //checking for the users presence
            if (kinectManager.IsUserDetected())
            {
                long userID = kinectManager.GetPrimaryUserID();
                if (kinectManager.IsJointTracked(userID, (int)joint))
                {
                    jointPos = kinectManager.GetJointPosition(userID, (int)joint);
                    //scaling the ratio to fit the screen size
                    jointPos.z = 0;
                    jointPos.x *= 30;
                    jointPos.y *= 20;
                    jointPos.y -= 20;
                    transform.position = jointPos;
                }
            }
        }
    }
}
