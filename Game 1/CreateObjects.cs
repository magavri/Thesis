using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    //starting position for left hand obstacles
    int zPosL = -34; 
    //starting position for right hand obstacles
    int zPosR = -29; 
    //number of obstacles for one hand
    public static int amount = 10; 
    // prefab for the obstacle
    public GameObject prefab;
    //final obstacle generated
    private GameObject last;
    
    /// <summary>
    /// List with positions sorted by angles of the left shoulder rotation
    /// </summary>
   public static Vector3[] prefabPosL = {
        new Vector3 (-1.16f, 2.47f), //40
        new Vector3 (-1.29f, 2.8f), //30
        new Vector3 (-1.38f, 2.67f), //20
        new Vector3 (-1.35f, 2.47f), //10
        new Vector3 (-1.35f, 2.28f), //0
        new Vector3 (-1.33f, 1,99f), //-16
        new Vector3 (-1.21f, 1.71f), //-32
        new Vector3 (-0.98f, 1.48f), //-48
        new Vector3 (-0.74f, 1.32f), //-64
        new Vector3 (-0.58f, 1.18f) //80
    };
    private void Start()
    {
        //Checking for the limit set by user to limit positions in the list
        if (FirstGameMenu.limit == 90)
        {
            ObjectRandom(4);
        }
        else ObjectRandom(0);   
    }
     void FixedUpdate()
    {
        //if the last obstacle has passed this position
        //the script for the score menu appearance will be called
        if (last.transform.position.z < -46.5f)
        {
            FindObjectOfType<GameEnd>().FinalScore();
        }    
    }
     /// <summary>
     /// Generates obstacles at random position chosen from the list
     /// </summary>
     /// <param name="firstElement"></param>
    void ObjectRandom (int firstElement)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 temp = prefabPosL[Random.Range(firstElement, prefabPosL.Length)]; 
            temp.z = zPosL;
            //creating prefabs for the left side
            Instantiate(prefab, temp, Quaternion.identity); 
            Vector3 temp2 = prefabPosL[Random.Range(firstElement, prefabPosL.Length)];
            temp2.z = zPosR;
            //multiplying the x position to get the obstacles for the right hand
            temp2.x *= -1;
            //checking if the prefab is the last one and marking it
            if (i == amount - 1)
            {
                last = Instantiate(prefab, temp2, Quaternion.identity);
                last.name = "ObstacleLast";
                return;
            }
            //creating prefabs for the right hand
            Instantiate(prefab, temp2, Quaternion.identity); 
            //setting distance between each prefab 
            zPosL += 10;
            zPosR += 10;
        }
    }
}
