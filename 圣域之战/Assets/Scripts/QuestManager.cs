using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestManager 
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
                instance = new QuestManager();
            return instance;
        }
    }
    //任务列表
    private List<QuestData> QuestList = new List<QuestData>();

    //是否接受任务
    public bool HasQuest(int id)
    {
        foreach(QuestData qd in QuestList)
        {
            if(qd.id == id)
                return true;
        }
        return false;
    }

    //添加任务
    public void AddQuest(int id)
    {
        if(!HasQuest(id))
        {
            QuestList.Add(QuestDataManager.Instance.QuestDic[id]);
        }

    }

    //击杀了敌人
    public void AddEnemy(int enemyid)
    {
        for(int i =0; i<QuestList.Count;i++)
        {
            QuestData qd = QuestList[i];
            //遍历任务中是否有该击杀敌人需求
            if(qd.enemyId == enemyid)
            {
                qd.currentCount++;
                if(qd.currentCount>=qd.count)
                {
                    Debug.Log("任务完成，这里可以制作任务奖励、光效等内容");
                    //删除任务
                    qd.currentCount = 0;
                    QuestList.Remove(qd);
                    //读取光效预制件
                    GameObject go = Resources.Load<GameObject>("fx_hr_arhur_pskill_03_2");
                    //获取主角
                    Transform player = GameObject.FindWithTag("Player").transform;
                    //创建光效
                    GameObject.Instantiate(go,player.position,player.rotation);
                }
            }
        }
    }
}

