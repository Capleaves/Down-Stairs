using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{

    public float walkSpeed = 2;
    Vector2 m_Movement;
    public GameObject weaponObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        move();
    }
    void getInput()
    {
        m_Movement = InputC.instance.m_Movement;

    }
    private void move()
    {
        // 如何把世界坐标系的方向, 转化为 角色自身坐标系的方向.
         Vector3 dir = transform.TransformDirection(new Vector3(m_Movement.x ,0,m_Movement.y));


        //Vector3 dir = new Vector3(m_Movement.x, 0, m_Movement.y);
       
        transform.Translate(dir * walkSpeed * Time.deltaTime, Space.World); //
                               
    }

    public void enbaleWeapon()
    {
        weaponObj.SetActive(true);
    }
    public void closeWeapon()
    {
        weaponObj.SetActive(false);
    }
}
