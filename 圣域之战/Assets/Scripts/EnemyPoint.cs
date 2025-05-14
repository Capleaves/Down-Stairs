using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject EnemyPre;
    public int Num = 3;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>2)
        {
            timer = 0;
            int n = transform.childCount;
            if(n<Num)
            {
                Vector3 v = transform.position;
                v.x += Random.Range(-5,5);
                v.z += Random.Range(-5,5);

                Quaternion q = Quaternion.Euler(0,Random.Range(0,360),0);

                GameObject go = GameObject.Instantiate(EnemyPre,v,q);
                
                go.transform.SetParent(transform);
            }
        }
    }
}
