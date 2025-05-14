using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponC_new : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DamageAbleObj>(out DamageAbleObj damageAbleObj))
        {
            damageAbleObj.behit();
        }
    }
}
