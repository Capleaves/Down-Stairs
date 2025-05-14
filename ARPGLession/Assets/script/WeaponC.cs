using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponC : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<DamageAbleObj>() != null)
        {
            other.gameObject.GetComponent<DamageAbleObj>().behit();
        }


    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
