using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputC : MonoBehaviour
{
    public static InputC instance; 
    public Vector2 m_Movement;
    public Vector3 m_Camera;
    public bool m_atkTrigger;

    private void Awake()
    {
        instance = this; 
    } 
    void Start()
    { 
    }  
    void Update()
    { 
        //  AD     左右                                  WS   上下箭头
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));    
        m_Camera.Set( Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse ScrollWheel") );
        m_atkTrigger = Input.GetMouseButtonDown(0);

        Debug.Log(m_Camera.z);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("你按下了A键");
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("你按下了鼠标左键");
        //}
    }

}
