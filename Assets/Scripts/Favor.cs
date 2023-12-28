using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Favor : MonoBehaviour
{
    public static int level ;

    public static int exp;

    public Text levelText;

    public Slider expSlider;

    public Text expValue;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level",0);
            level = 0;
        }
            
        if (PlayerPrefs.HasKey("exp"))
        {
            exp = PlayerPrefs.GetInt("exp");
        }
        else
        {
            PlayerPrefs.SetInt("exp",0);
            exp = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        expValue.text = exp.ToString();
        levelText.text = level.ToString();
        expSlider.value = exp;
        if(level == 0 )
        {
            expSlider.maxValue = 0;
        }
        else if(level == 1 )
        {
            expSlider.maxValue = 22;
        }
        else if(level == 2 )
        {
            expSlider.maxValue = 59;
        }
        else if(level == 3 )
        {
            expSlider.maxValue = 161;
        }
        else if(level == 4)
        {
            expSlider.maxValue = 437;
        }
        else if(level == 5)
        {
            expSlider.maxValue = 1187;
        }
        else if(level == 6)
        {
            expSlider.maxValue = 3227;
        }
        PlayerPrefs.SetInt("level",level);
        PlayerPrefs.SetInt("exp",exp);
    }


    public static void addExp(int value) {//具体好感度增加时还要考虑心情带来的倍率影响；
        exp += value;
        if ( Random.Range(0,100) < 2) {
            exp += value;
        }
        // 检查是否满足升级条件
        if(level == 0 && exp >= 0)
        {
            level++;
            exp -= 0;
        }
        else if(level == 1 && exp >= 22)
        {
            level++;
            exp -= 22;
        }
        else if(level == 2 && exp >= 59)
        {
            level++;
            exp -= 59;
        }
        else if(level == 3 && exp >= 161)
        {
            level++;
            exp -= 161;
        }
        else if(level == 4 && exp >= 437)
        {
            level++;
            exp -= 437;
        }
        else if(level == 5 && exp >= 1187)
        {
            level++;
            exp -= 1187;
        }
        else if(level == 6 && exp >= 3227)
        {
            level++;
            exp -= 3227;
        }
    }
}
