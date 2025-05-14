using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //单例
    public static AudioManager Instance;
    //音乐播放器
    public AudioSource bgmPlayer;
    //音效播放器
    public AudioSource sePlayer;

    void Awake()
    {
        Instance = this;
    }
    //播放音乐
    public void PlayBgm(string path)
    {
        if(bgmPlayer.isPlaying == false)
        {
            //从Resources文件夹中读取一个音频文件
            AudioClip clip=Resources.Load<AudioClip>(path);
            //设置播放器的音频片段
            bgmPlayer.clip=clip;
            //播放
            bgmPlayer.Play();
        }
    }
    //停止音乐
    public void StopBgm(string path)
    {
        if(bgmPlayer.isPlaying == true)
        {
            //停止
            bgmPlayer.Stop();
        }
    }
    //播放音效
    public void PlaySe(string path)
    {
        if(bgmPlayer.isPlaying == false)
        {
            //从Resources文件夹中读取一个音频文件
            AudioClip clip=Resources.Load<AudioClip>(path);
            //播放音效
            sePlayer.PlayOneShot(clip);
        }
    }
}
