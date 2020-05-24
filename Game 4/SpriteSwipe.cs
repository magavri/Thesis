using System.Collections;
using UnityEngine;

public class SpriteSwipe : MonoBehaviour
{
    //yellow circle sprite
    public Sprite yellow;
    //particle system for the effect
    public GameObject particles;
    private int i = 0, j=0, k=0, m=0;
    //game end time
    public static float endTime;
    public static int tempEnd = 0;
   /// <summary>
   /// Detecting collision between hand and circle
   /// </summary>
   /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Circle1"))
        {
            ParticlePosition();
            Swapping();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag.Contains("CircleLast"))
        {
            if (other.gameObject.tag.Contains("GameEnd"))
            {
                if (endTime == 0)
                {
                    endTime = Time.time;
                }

                tempEnd = 1;
            }
            ParticlePosition();
            particles.GetComponent<ParticleSystem>().Play();
            PointsList.stars[j].gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            NameEnable(); 
            ConstellationChange();
            i++;
            j++;
        }
        else if (other.gameObject.tag.Contains("Circle"))
        {
            ParticlePosition();
            Swapping();
            other.gameObject.SetActive(false);
        }
    }
  /// <summary>
  /// Enabling particle system, adding collider to the circle, changing the white circle to yellow
  /// enabling star sprite
  /// </summary>
   private void Swapping()
    {
        particles.GetComponent<ParticleSystem>().Play();
        PointsList.circles[i+1].gameObject.AddComponent<CircleCollider2D>();
        PointsList.circles[i+1].GetComponent<SpriteRenderer>().sprite = yellow;
        PointsList.stars[j].gameObject.SetActive(true);
        j++;
        i++;
    }

  /// <summary>
  /// Moving the particle system to another position
  /// </summary>
  private void ParticlePosition()
   {
       Vector3 tempPos = new Vector3();
       tempPos = PointsList.circles[i].gameObject.transform.position;
       tempPos.z = -16;
       particles.gameObject.transform.position = tempPos;
   }
  
  /// <summary>
  /// Enabling game object containing the name of the constellation
  /// </summary>
  private void NameEnable()
   {
       PointsList.names[k].gameObject.SetActive(true);
       k++;
   }
  
  /// <summary>
  /// Disabling previous constellation and enabling the new one
  /// </summary>
   private void ConstellationChange()
   {
       StartCoroutine(DisableAfterSeconds(6, PointsList.constellations[m]));
       StartCoroutine(EnableAfterSeconds(8, PointsList.constellations[m + 1]));
       m++;
   }

   IEnumerator EnableAfterSeconds(int seconds, GameObject obj)
   {
       yield return new WaitForSeconds(seconds);
       obj.gameObject.SetActive(true);
   }
   IEnumerator DisableAfterSeconds(int seconds, GameObject obj)
   {
       yield return new WaitForSeconds(seconds);
       obj.gameObject.SetActive(false);
   }
}
