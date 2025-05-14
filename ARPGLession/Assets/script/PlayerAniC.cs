using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniC : MonoBehaviour
{
    public Animator ani;
    public Vector2 m_Movement;
    public bool m_atkTrigger;
    void getInput()
    {
        m_Movement = InputC.instance.m_Movement;
        m_atkTrigger = InputC.instance.m_atkTrigger;
    } 
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    void move()
    {
        ani.SetFloat("水平速度", m_Movement.x);
        ani.SetFloat("垂直速度", m_Movement.y); 
    } 
    void atk()
    {
        if (m_atkTrigger)
        {
            ani.SetTrigger("攻击触发");
        }
    }
    // Update is called once per frame
    void Update()
    {
        getInput();
        move();
        atk();
    }
}
