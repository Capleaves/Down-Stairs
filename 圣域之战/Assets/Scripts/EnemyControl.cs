using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //敌人i
    public int ID = 101;
    //主角
    public PlayerControl player;
    //血量
    public int Hp = 100;
    //攻击力
    public int Attack = 20;
    //出生点位置
    private Vector3 position;
    //动画器组件
    private Animator animator;
    //攻击计时器
    private float timer = 1;
    //当前是否正在攻击
    private bool isAttack = false;
    public GameObject PotionPre;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        //获取出生点位置
        position = transform.position;

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //主角死亡或敌人死亡，则停止一切动作
        if(player.Hp<=0||Hp<=0)
        {
            animator.SetBool("Run",false);
            animator.SetBool("Attack",false);
            return;
        }

        //获取与主角的距离
        float distance = Vector3.Distance(player.transform.position,transform.position);

        //敌人7m内没发现主角
        if(distance>7f)
        {
            //距离出生点超过1m
            if(Vector3.Distance(transform.position,position)>1f)
            {
                //转向出生点
                transform.LookAt(new Vector3(position.x,transform.position.y,position.z));
                //向前移动
                transform.Translate(Vector3.forward*2*Time.deltaTime);
                //播放移动动画
                animator.SetBool("Run",true);
            }
            else
            {
                animator.SetBool("Run",false);
            }
        }
        else if(distance > 3f)
        {
            //敌人与主角距离在3-7之间，则朝玩家移动
            //可以直接移动或使用导航功能移动
            transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
            transform.Translate(Vector3.forward*2*Time.deltaTime);

            animator.SetBool("Run",true);
            isAttack = false;
            animator.SetBool("Attack",false);
        }
        else
        {
            //3m内停止移动，开始攻击
            animator.SetBool("Run",false);

            transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));

            animator.SetBool("Attack",true);
            
            if(isAttack == false)
            {
                isAttack = true;
                timer = 1;
            }

            timer += Time.deltaTime;
            if(timer>=2)
            {
                timer = 0;
                //打出伤害
                player.GetDamage(Attack);
            }         
        }
    }

    public void GetDamage(int damage)
    {
        if(Hp>0)
        {
            //弹出伤害值
            GetComponentInChildren<HpManager>().ShowText("-"+damage);
            Hp -= damage;
            if(Hp<=0)
            {
                //掉落血瓶
                Instantiate(PotionPre,transform.position,transform.rotation);
                animator.SetTrigger("Die");
                QuestManager.Instance.AddEnemy(ID);
                Destroy(gameObject,2f);
            }
        }
    }

}
