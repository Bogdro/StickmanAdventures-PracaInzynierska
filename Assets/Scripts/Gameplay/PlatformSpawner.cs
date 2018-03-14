using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public IEnumerator WaitForSpawn(float timeToSpawn, GameObject gameObject)
    {
        yield return new WaitForSeconds(timeToSpawn);
        Debug.Log("Pojawionko!");
        gameObject.SetActive(true);
    }

    public void SpawnPlatform(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("destroy", false);
        gameObject.SetActive(true);
    }

}
