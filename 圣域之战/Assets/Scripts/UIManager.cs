using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //单例
    public static UIManager Instance;
    private Image dialog;
    private Image hpBar;
    private PlayerControl player;
    private int questid;
    void Start()
    {
        Instance = this;
        hpBar = transform.Find("Head").Find("HpBar").GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        dialog = transform.Find("Dialog").GetComponent<Image>();
        dialog.gameObject.SetActive(false);
    }

    void Update()
    {
        //更新血条
        hpBar.fillAmount = (float)player.Hp / player.MaxHp;        
    }

    //显示对话框，参数为对话标题、内容、相关的任务
    public void Show(string name,string content,int id = -1)
    {
        //呼出鼠标指针
        Cursor.lockState = CursorLockMode.None;
        //显示对话框
        dialog.gameObject.SetActive(true);

        dialog.transform.Find("NameText").GetComponent<Text>().text = name;

        questid = id;

        if(QuestManager.Instance.HasQuest(id))
        {
            dialog.transform.Find("ContentText").GetComponent<Text>().text = "你已经接受该任务了";
        }
        else
        {
            dialog.transform.Find("ContentText").GetComponent<Text>().text = content;
        }
    }

    public void AcceptButtonClick()
    {
        dialog.gameObject.SetActive(false);
        QuestManager.Instance.AddQuest(questid);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CancelButtonClick()
    {
        dialog.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
