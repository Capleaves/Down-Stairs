using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCnew : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 4;
    public Animator ani;
    public GameObject weaponObj;
    float ComboTimer;
    bool isControl = true;
    
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        Atk();
        Move();
        ResetParams();
    }
    private void Move()
    {  
        
        //if (!isControl) return;
        Vector3 dir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")));
        controller.SimpleMove(dir * walkSpeed);
        ani.SetFloat("ˮƽ�ٶ�", Input.GetAxis("Horizontal"));
        ani.SetFloat("��ֱ�ٶ�", Input.GetAxis("Vertical"));
    }
    void Atk()
    {
        if (Input.GetMouseButtonDown(0) && isControl)
        {
        
            ComboTimer = 2;
            
            ani.SetInteger("����", (ani.GetInteger("����")+1)%3); 
            ani.SetTrigger("��������");
            //if (ani.GetInteger("����") == 2)
            {
                isControl = false;
            }
        }
    }
    void ResetParams()
    {
        if (ComboTimer <= 0 && ani.GetInteger("����") != 0)
        {
            ani.SetInteger("����",0);
        }
        else
        {
            ComboTimer -= Time.deltaTime;
        } 
    }

    public void enbaleWeapon()
    {
        weaponObj.SetActive(true);
    }
    public void closeWeapon()
    {
        weaponObj.SetActive(false);
    }
    public void resetControlState()
    {
        isControl = true;
    }
}
