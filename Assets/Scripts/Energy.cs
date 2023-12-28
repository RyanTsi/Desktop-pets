using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Energy : MonoBehaviour
{
    public Slider energyValue;

    public Text energyStatus;

    public Text energyBuff;

    public static int energyNum = 100;

    public static string energySta;

    private DateTime lastTime;
    
    private int status;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("energyValue"))
        {
            energyNum = PlayerPrefs.GetInt("energyValue");
        }
        else
        {
            PlayerPrefs.SetInt("energyValue",100);
        }
        lastTime = DateTime.Now;
        status = Random.Range(0, 3);
        if (status == 0)
        {
            energySta = "FOCUS";
            energyBuff.text = "-1/2min";
        }else if (status == 1)
        {
            energySta = "SLEEP";
            energyBuff.text = "+5/min";
        }
        else
        {
            energySta = "OTHER";
            energyBuff.text = "-1/5min";
        }
        energyStatus.text = energySta;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == 0)
        {
            if (DateTime.Now.Subtract(lastTime).Duration().TotalMinutes == 2.0f)
            {
                energyNum -= 1;
                if (energyNum < 0)
                {
                    energyNum = 0;
                }
                Mood.ChangeValue(1);
                if (energyNum < 15 && energyNum >= 5)
                {
                    Mood.ChangeValue(-2);
                }else if (energyNum < 5 && energyNum >= 0)
                {
                    Mood.ChangeValue(-10);
                }
                lastTime = DateTime.Now;
            }
        }else if (status == 1)
        {
            if (DateTime.Now.Subtract(lastTime).Duration().TotalMinutes == 1.0f)
            {
                energyNum += 5;
                if (energyNum > 100)
                {
                    energyNum = 100;
                }
                if (energyNum < 15 && energyNum >= 5)
                {
                    Mood.ChangeValue(-1);
                }else if (energyNum < 5 && energyNum >= 0)
                {
                    Mood.ChangeValue(-5);
                }
                lastTime = DateTime.Now;
            }
        }
        else if(status == 2)
        {
            if (DateTime.Now.Subtract(lastTime).Duration().TotalMinutes == 5.0f)
            {
                energyNum -= 1;
                if (energyNum < 0)
                {
                    energyNum = 0;
                }
                lastTime = DateTime.Now;
                if (energyNum < 15 && energyNum >= 5)
                {
                    Mood.ChangeValue(-5f);
                }else if (energyNum < 5 && energyNum >= 0)
                {
                    Mood.ChangeValue(-25f);
                }
            }
        }

        energyValue.value = energyNum;
        PlayerPrefs.SetInt("energyValue",energyNum);

    }
}
