using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Mood : MonoBehaviour
{
    public static float moodValue; // 心情数值
    public static string moodType; // 心情类型
    public static float magnification; // 好感倍率
    private DateTime lastUpdate; // 上次更新时间
    public Text moodText;
    public Text moodStatus;
    public Text moodBuff;

    void Start()
    {
  
        lastUpdate = DateTime.Now;
        if (PlayerPrefs.HasKey("moodValue"))
        {
            moodValue = PlayerPrefs.GetFloat("moodValue");
        }
        else
        {
            moodValue = Random.Range(-100f, 100f);
            PlayerPrefs.SetFloat("moodValue",moodValue);
        }
        changeMoodType();
        moodText.text = moodValue.ToString("f2");
        moodStatus.text = moodType;
        moodBuff.text = (magnification * 100)+"%";
    }
    void Update()
    {
        if (DateTime.Now.Subtract(lastUpdate).Duration().TotalMinutes == 1.0f)
        {
            moodValue *= 0.98f;
            lastUpdate = DateTime.Now;
            changeMoodType();
        }
        
        moodText.text = moodValue.ToString("f2");
        moodStatus.text = moodType;
        moodBuff.text = (magnification * 100).ToString();
        PlayerPrefs.SetFloat("moodValue",moodValue);
    }

    public static void ChangeValue(float f1)
    { // 增加或减少心情
        moodValue += f1;
        if (moodValue <= -100.0f)
        {
            moodValue = -100.0f;
        }
        if (moodValue >= 100.0f)
        {
            moodValue = 100.0f;
        }
        changeMoodType();
    }

    public static void changeMoodType()
    {
        if (moodValue <= -70.0f)
        {
            moodType = "sad";
            magnification = 0.5f;
        }
        else if (moodValue <= -30.0f)
        {
            moodType = "cold";
            magnification = 0.8f;
        }
        else if (moodValue <= 30.0f)
        {
            moodType = "normal";
            magnification = 1f;
        }
        else if (moodValue <= 70.0f)
        {
            moodType = "happy";
            magnification = 1.2f;
        }
        else
        {
            moodType = "overjoyed";
            magnification = 1.5f;
        }
    }
}
