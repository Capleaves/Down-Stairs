using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour
{
    public GameObject[] cherryPrefabs;
    public void SpawnCherry()
    {
        int r = Random.Range(0,cherryPrefabs.Length);
        GameObject cherry = Instantiate(cherryPrefabs[r],transform);
        cherry.transform.position = new Vector3(Random.Range(-1.5f,1.8f),Random.Range(-0.16f,0.7f),0f);
    }
}
