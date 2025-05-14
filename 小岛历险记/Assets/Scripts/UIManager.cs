using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text ScoreText;
    public int Score = 0;
    void Awake()
    {
        Instance = this;
    }
    public void AddScore()
    {
        Score++;
        ScoreText.text="x"+Score;
    }
}
