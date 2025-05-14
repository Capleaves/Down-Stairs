using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public GameObject HpTextPre;
    public void ShowText(string text)
    {
        GameObject go = Instantiate(HpTextPre,transform);
        go.GetComponent<HpControl>().SetText(text);
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);        
    }
}
