using System.Collections;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    //amount of lighthouses that has been light up
    public static int goal = 0;
    /// <summary>
    /// Detecting collision between hand sprite and a lighthouse
    /// Setting active light rays
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Lighthouse"))
        {
            //checking whether the lights are turned on
            if (!other.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(RemoveAfterSeconds(5, other.gameObject));
                goal++;
            }
        }
    }
    /// <summary>
    /// Turning off light rays after some time
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    IEnumerator RemoveAfterSeconds (int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.transform.GetChild(0).gameObject.SetActive(false);
    }
}
