using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_new : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 3;
    public Animator ani;
    public GameObject weaponObj;
    float ComboTimer;
    bool isControl = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Atk();
        ResetParams();
    }
    void Move()
    {
        Vector3 dir = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")));
        controller.SimpleMove(dir * walkSpeed);
        ani.SetFloat("前后速度",Input.GetAxisRaw("Vertical"));
        ani.SetFloat("左右速度",Input.GetAxisRaw("Horizontal"));
    }

    void Atk()
    {
        if(Input.GetMouseButtonDown(0)&& isControl)
        {
            isControl = false;
            ComboTimer = 2;
            ani.SetTrigger("攻击触发");
            ani.SetInteger("连段",(ani.GetInteger("连段")+1)% 3);
        }
    }
    public void enableWeapon()
    {
        weaponObj.SetActive(true);
    }
    public void disableWeapon()
    {
        weaponObj.SetActive(false);
    }

    void ResetParams()
    {
        if(ComboTimer<=0&& ani.GetInteger("连段")!=0)
        {
            ani.SetInteger("连段",0);
        }
        else
        {
            ComboTimer-=Time.deltaTime;
        }
    }
    public void resetControl()
    {
        isControl=true;
    }
}
