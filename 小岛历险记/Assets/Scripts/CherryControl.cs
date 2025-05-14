using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            UIManager.Instance.AddScore();
            Destroy(gameObject);
            transform.parent.GetComponent<CherryManager>().SpawnCherry();
        }
    }
}
