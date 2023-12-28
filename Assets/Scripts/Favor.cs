using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Favor : MonoBehaviour
{
    public static int level;

    public static int exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void levelUp() {
        level++;
    }

    void addExp(int value) {//具体好感度增加时还要考虑心情带来的倍率影响；
        exp += value;
        if (rand() % 100 < 2) {
            exp += value;
        }
        // 检查是否满足升级条件
        if(level == 0 && exp >= 0){
            levelUp();
            exp -= 0;
        }
        else if(level == 1 && exp >= 22){
            levelUp();
            exp -= 22;
        }
        else if(level == 2 && exp >= 59){
            levelUp();
            exp -= 59;
        }
        else if(level == 3 && exp >= 161){
            levelUp();
            exp -= 161;
        }
        else if(level == 4 && exp >= 437){
            levelUp();
            exp -= 437;
        }
        else if(level == 5 && exp >= 1187){
            levelUp();
            exp -= 1187;
        }
        else if(level == 6 && exp >= 3227){
            levelUp();
            exp -= 3227;
        }
    }
}
