using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] floorPrefabs;
    // Start is called before the first frame update
    public void SpawnFloor()
    {
        int r = Random.Range(0,floorPrefabs.Length);
        GameObject floor = Instantiate(floorPrefabs[r],transform);
        floor.transform.position = new Vector3(Random.Range(-3.5f,3.5f),-6f,0f);
    }
}
