using System.Collections.Generic;
using System.Xml;
using UnityEngine;

//任务数据类
public class QuestData
{
    //任务id
    public int id;
    //任务名称
    public string name;
    //任务敌人id
    public int enemyId;
    //任务敌人个数
    public int count;
    //当前敌人个数
    public int currentCount;
    //任务金钱
    public int money;
}
public class QuestDataManager 
{
    //单例
    private static QuestDataManager instance;
    public static QuestDataManager Instance
    {
        get
        {
            if(instance == null)
                instance = new QuestDataManager();
            
            return instance;
        }
    }
    //任务集合
    public Dictionary<int,QuestData> QuestDic = new Dictionary<int, QuestData>();

    private QuestDataManager()
    {
        //解析任务Xml
        XmlDocument doc = new XmlDocument();
        doc.Load(Application.dataPath+"/quest.xml");
        //根元素
        XmlElement rootEle = doc.LastChild as XmlElement;
        foreach(XmlElement questEle in rootEle)
        {
            //创建一个任务对象
            QuestData qd = new QuestData();
            //设置任务id
            qd.id = int.Parse(questEle.GetElementsByTagName("id")[0].InnerText);
            //设置任务名称
            qd.name = questEle.GetElementsByTagName("name")[0].InnerText;
            //设置敌人id
            qd.enemyId = int.Parse(questEle.GetElementsByTagName("enemyid")[0].InnerText);

            //需要攻击的敌人个数
            qd.count = int.Parse(questEle.GetElementsByTagName("count")[0].InnerText);

            XmlElement reward = questEle.GetElementsByTagName("reward")[0] as XmlElement;
            qd.money = int.Parse(reward.GetElementsByTagName("money")[0].InnerText);
            //添加到任务id
            QuestDic.Add(qd.id,qd);
        }
    }
}
