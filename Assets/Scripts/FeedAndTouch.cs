using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class FeedAndTouch : MonoBehaviour
{
    public Button touchButton;

    public Button feedButton;

    public static int index;

    public static int value;
    private DateTime lastTime;
    private DateTime today;
    private DateTime lastTimeHour;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = DateTime.Now;
        lastTimeHour = new DateTime(2023, 12, 28, 00, 00, 00);
        touchButton.onClick.AddListener(touchAction);
        feedButton.onClick.AddListener(feedAction);
        if (PlayerPrefs.HasKey("Day"))
        {
            DateTime temp = DateTime.ParseExact(
                PlayerPrefs.GetString("Day"), "MM/dd/yyyy", null);
            if (DateTime.Now.Subtract(temp).Duration().TotalDays >= 1)
            {
                PlayerPrefs.SetString("Day",DateTime.Now.ToString("MM/dd/yyyy"));
                PlayerPrefs.SetFloat("moodValue",Random.Range(-100f,100f));
                PlayerPrefs.SetInt("index",0);
            }
        }
        else
        {
            PlayerPrefs.SetString("Day",DateTime.Now.ToString("MM/dd/yyyy"));
            
        }

        if (PlayerPrefs.HasKey("index"))
        {
            index = PlayerPrefs.GetInt("index");
        }
        else 
        {
            PlayerPrefs.SetInt("index",0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Subtract(lastTime).Duration().TotalSeconds > 3.0f)
        {
            touchButton.enabled = true;
        }

        if (DateTime.Now.Subtract(lastTimeHour).Duration().TotalHours >=1f&&index<6)
        {
            feedButton.enabled = true;
        }
    }

    private void touchAction()
    {
        value = Mathf.CeilToInt(Random.Range(1, 4)*Mood.magnification);
        Debug.Log("add:"+value);
        Favor.addExp(value);
        touchButton.enabled = false;
        lastTime = DateTime.Now;
    }

    private void feedAction()
    {
        
        index++;
        PlayerPrefs.SetInt("index",index);
        value = Mathf.CeilToInt(Random.Range(8, 21) * Mood.magnification);
        Debug.Log("add:"+value);
        Favor.addExp(value);
        feedButton.enabled = false;
        lastTimeHour = DateTime.Now;
    }
}
