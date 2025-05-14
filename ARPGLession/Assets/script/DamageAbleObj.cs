using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbleObj : MonoBehaviour
{
    public Animator ani;
    public Transform target;
    public SkinnedMeshRenderer meshRenderer;
    bool ishit;
    float hitValue = 1.6f;
    public GameObject HitFx;
    public void behit()
    {
        ishit = true;
        //Destroy(this.gameObject);
        ani.SetTrigger("getHit");
        hitValue = 4;
        meshRenderer.material.SetFloat("_Brightness", hitValue);
        Instantiate(HitFx, this.transform.position , Quaternion.identity);
    }
    private void Update()
    {
        this.transform.LookAt(target);
        if (ishit&& hitValue>1.6f)
        {
            hitValue -= Time.deltaTime*15;
            meshRenderer.material.SetFloat("_Brightness", hitValue);
        }
    }
}
