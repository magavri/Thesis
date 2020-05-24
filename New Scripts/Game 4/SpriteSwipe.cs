using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpriteSwipe : MonoBehaviour
{
    public Sprite yellow;
    public GameObject particles;
    private int i = 0, j=0, k=0, m=0;
    public static float endTime;
    public static int tempEnd = 0;
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
   private void Swapping()
    {
        particles.GetComponent<ParticleSystem>().Play();
        PointsList.circles[i+1].gameObject.AddComponent<CircleCollider2D>();
        PointsList.circles[i+1].GetComponent<SpriteRenderer>().sprite = yellow;
        PointsList.stars[j].gameObject.SetActive(true);
        j++;
        i++;
    }

   private void ParticlePosition()
   {
       Vector3 tempPos = new Vector3();
       tempPos = PointsList.circles[i].gameObject.transform.position;
       tempPos.z = -16;
       particles.gameObject.transform.position = tempPos;
   }
   private void NameEnable()
   {
       PointsList.names[k].gameObject.SetActive(true);
       k++;
   }

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
