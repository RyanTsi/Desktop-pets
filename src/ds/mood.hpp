#pragma once

#include <iostream>
#include <ctime>
#include <chrono>
#include <cmath>
#include <string>
#include <thread>


class Mood {
private:
    float value; // 心情数值
    std::string type; // 心情类型
    float magnification; // 好感倍率
    std::chrono::time_point<std::chrono::system_clock> lastUpdate; // 上次更新时间

public:
    Mood() {
        value = 0;
        type = "normal";
        magnification = 1;
        lastUpdate = std::chrono::system_clock::now();
    }

    void update() {
        // 获取当前时间
        auto now = std::chrono::system_clock::now();
        // 计算距离上次更新的时间差，单位为分钟
        std::chrono::duration<double> diff = now - lastUpdate;
        double minutesPassed = diff.count() / 60.0;

        // 心情数值衰减
        value *= pow(0.98, minutesPassed);

        // 更新上次更新时间为当前时间
        lastUpdate = now;
        updateMood();
    }

    void changeValue(float f1) { // 增加或减少心情
        value += f1;
        if (value <= -100.0) {
            value = -100.0;
        }
        if (value >= 100.0) {
            value = 100.0;
        }
        updateMood();
    }

    void updateMood() {
        if (value <= -70.0) {
            type = "sad";
            magnification = 0.5;
        }
        else if (value <= -30.0) {
            type = "cold";
            magnification = 0.8;
        }
        else if (value <= 30.0) {
            type = "normal";
            magnification = 1;
        }
        else if (value <= 70.0) {
            type = "happy";
            magnification = 1.2;
        }
        else {
            type = "overjoyed";
            magnification = 1.5;
        }
    }

    int getMood() {
        return static_cast<int>(value);
    }

    std::string getType() {
        return type;
    }

    float getMagnification() {
        return magnification;
    }
};

class Affection {
private:
    int level; // 等级
    int exp; // 经验值

public:
    Affection() {
        level = 0;
        exp = 0;
    }

    void levelUp() {
        level++;
        std::cout << "好感度等级提升为 Lv" << level << std::endl;
    }

    void addExp(int value) {//具体好感度增加时还要考虑心情带来的倍率影响；
        exp += value;
        if (rand() % 100 < 2) {
            exp += value;
            std::cout << "获得双倍好感度！" << std::endl;
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
            exp == 3227;
        }
    }
    //动作模块应该单独写一个类，方便调用
    // void touch() {
    //     int min = 1;
    //     int max = 3;
    //     int affection = rand() % (max - min + 1) + min;

    //     addExp(affection);
    //     std::cout << "获得" << affection << "好感度！" << std::endl;
    // }

    // void feed() {
    //     int min = 8;
    //     int max = 20;
    //     int affection = rand() % (max - min + 1) + min;

    //     // 2%概率双倍好感度

    //     addExp(affection);
    //     std::cout << "获得" << affection << "好感度！" << std::endl;
    // }

    int getLevel() {
        return level;
    }

    int getExp() {
        return exp;
    }

    void printLevel() {
        std::cout << "当前好感度等级：Lv" << level << std::endl;
    }

    void printExp() {
        std::cout << "当前好感度经验值：" << exp << std::endl;
    }
};

class Pet {
private:
    Mood mood; // 心情
    Affection affection; // 好感度

public:
    void feed() {
        int min = 8;
        int max = 20;
        int affectionValue = rand() % (max - min + 1) + min;

        affection.addExp(static_cast<int>(affectionValue*mood.getMagnification()));
        std::cout << "获得" << static_cast<int>(affectionValue*mood.getMagnification()) << "好感度！" << std::endl;

        // 改变心情数值
        float moodChange = affectionValue * mood.getMagnification() * 0.1;
        mood.changeValue(moodChange);
    }

    void touch() {
        int min = 1;
        int max = 3;
        int affectionValue = rand() % (max - min + 1) + min;

        affection.addExp(static_cast<int>(affectionValue*mood.getMagnification()));
        std::cout << "获得" << static_cast<int>(affectionValue*mood.getMagnification()) << "好感度！" << std::endl;

        // 改变心情数值
        float moodChange = affectionValue * mood.getMagnification() * 0.05;
        mood.changeValue(moodChange);
    }

    Mood getMood(){
        return mood;
    }

    Affection getAffection(){
        return affection;
    }
};

// int main() {
//     Mood mood;
//     std::cout << mood.getType() << std::endl;
//     mood.changeValue(-70.0);
//     std::cout << mood.getType() << std::endl;
//     Pet pet;

//     // 喂食
//     pet.feed();
//     pet.feed();
//     pet.feed();

//     // 触摸
//     pet.touch();
//     pet.touch();
//     pet.touch();

//     // 输出好感度等级和经验值
//     pet.getAffection().printLevel();
//     pet.getAffection().printExp();

//     // 模拟每分钟调用一次 update 函数
//     for (int i = 0; i < 3; ++i) {
//         std::this_thread::sleep_for(std::chrono::minutes(1));
//         pet.getMood().update();
//         std::cout << pet.getMood().getMood() << std::endl;
//     }
//     return 0;
// }
