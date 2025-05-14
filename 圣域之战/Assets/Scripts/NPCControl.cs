using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    public string Name = "村民";
    public string Content = "最近村外石头人比较多，快去击杀两个吧！";
    public int QuestID = 1001;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float dis = Vector3.Distance(player.position,transform.position);

        if(dis<4&&Input.GetKeyDown(KeyCode.F))
        {
            UIManager.Instance.Show(Name,Content,QuestID);
        }        
    }
}
