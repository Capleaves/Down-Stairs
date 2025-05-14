using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    idle,
    run,
    die,
    attack,
    attack2
}
public class PlayerControl : MonoBehaviour
{
    private PlayerState state = PlayerState.idle;
    private Rigidbody rBody;
    private Animator animator;
    public int MaxHp = 100;
    public int Hp = 100;
    private List<Transform> fxList;
    void Start()
    {
        rBody=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.lockState=CursorLockMode.Locked;
        fxList = new List<Transform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //显示指针
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked? CursorLockMode.None:CursorLockMode.Locked;
        }

        if(Cursor.lockState == CursorLockMode.None) return;

        switch(state)
        {
            case PlayerState.idle:
                Rotate();
                Move();
                Attack();
                animator.SetBool("Run",false);
                break;
            case PlayerState.run:
                Rotate();
                Move();
                Attack();
                animator.SetBool("Run",true);    
                break;
            case PlayerState.die:
                break;
            case PlayerState.attack:
                break;
            case PlayerState.attack2:
                break;
        }
        Transform fx = null;
        foreach(Transform trans in fxList)
        {
            //特效移动
            trans.Translate(Vector3.forward*20*Time.deltaTime);
            Collider[] colliders = Physics.OverlapSphere(trans.position,1f);
            //遍历特效
            foreach(Collider collider in colliders)
            {
                if(collider.tag == "Enemy")
                {
                    collider.GetComponent<EnemyControl>().GetDamage(20);
                    fx = trans;
                    GameObject fxPre = Resources.Load<GameObject>("Explosion");
                    GameObject go = Instantiate(fxPre,collider.transform.position,collider.transform.rotation);
                    Destroy(go,2f);
                    break;
                }
            }
        }
        if(fx != null)
        {
            fxList.Remove(fx);
        }
        
    }

    void Rotate()
    {
        transform.rotation=Camera.main.transform.parent.rotation;
    }

    void Move()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector3 dir =new Vector3(horizontal,0,vertical);

        if(dir!=Vector3.zero)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {                              
                //加速
                rBody.velocity=transform.forward*vertical*20;
                rBody.velocity+=transform.right*horizontal*10;
                state = PlayerState.run;
            }
            else
            {
                //纵向移动
                rBody.velocity=transform.forward*vertical*4;
                //横向移动
                rBody.velocity+=transform.right*horizontal*2;
                state = PlayerState.run;
            }
        }
        else
        {
            state = PlayerState.idle;
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            state = PlayerState.attack;
        }

        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack2");
            state = PlayerState.attack2;
        }
    }

    void AttackEnd()
    {
        state = PlayerState.idle;
    }

    public void GetDamage(int damage)
    {
        Hp -=damage;
        if(Hp<=0)
        {
            state = PlayerState.die;
            animator.SetTrigger("Die");
            Invoke("Revive",3f);
        }
    }

    public void Revive()
    {
        if(state == PlayerState.die)
        {
            Hp = MaxHp;
            animator.SetTrigger("Revive");
            state = PlayerState.idle;
            transform.position = transform.position;
        }
    }

    void Damage(int damage)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,3f);
        foreach(Collider collider in colliders)
        {
            //如果敌人在60°的攻击范围内
            if(collider.tag == "Enemy" && Vector3.Angle(collider.transform.position-transform.position,transform.forward)<60)
            {
                collider.GetComponent<EnemyControl>().GetDamage(damage);
            }
        }
    }

    Transform FX(string name, float desTime)
    {
        //加载特效预制件
        GameObject fxPre = Resources.Load<GameObject>(name);
        //实例化特效
        GameObject go = Instantiate(fxPre,transform.position,transform.rotation);
        //销毁特效物体
        Destroy(go,desTime);
        return go.transform;
    }
    void Attack1_1()
    {
        Damage(20);
        FX("fx_hr_arthur_attack_01_1",0.5f);
    }

    void Attack1_2()
    {
        Damage(20);
        FX("fx_hr_arthur_attack_01_2",0.5f);
        for(int i = 0;i<5;i++)
        {
            Transform fire = FX("Magic fire pro red",1f);
            fire.transform.rotation = transform.rotation;
            fire.transform.Rotate(fire.transform.up,15*i-30);
            fxList.Add(fire);
            Invoke("ClearFXList",1f);
        }
    }
    void ClearFXList()
    {
        fxList.Clear();
    }

    void Attack2_0()
    {
        FX("fx_hr_arthur_pskill_03_1",0.5f);
        FX("RotatorPS2",4f);
    }

    void Attack2_1()
    {
        Damage(80);
        FX("fx_hr_arthur_pskill_01",1.8f);
    }

    void Attack2_2()
    {
        Damage(20);
    }
}
