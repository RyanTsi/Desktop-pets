// HealthSystem.cpp
#include "HealthSystem.h"
#include <iostream>
#include <ctime>
#include <cstdlib>

HealthSystem::HealthSystem() : health(100), mood(100), energy(100), isSick(false), canGetSick(true) {

    std::srand(std::time(nullptr));
}

HealthSystem::~HealthSystem() {

}

void HealthSystem::updateHealth(int temperature, int energy) {
    if (canGetSick) {
        int probability = std::min(30, std::abs(temperature - 21)) * std::max(0, 40 - energy);
        double sicknessProbability = static_cast<double>(probability) / 3600.0;

        if ((rand() % 100) < (sicknessProbability * 100)) {
            isSick = true;
            canGetSick = false;
            mood = std::max(0, mood - 1);  // 生病状态下心情降低
            std::cout << "我要寄了！" << std::endl;
        }
    }
    // 更新精力
    if (isConcentrating) {
        energy -= 0.5;  // 专注模式下持续消耗精力
        mood += 0.5;    // 专注模式下提高心情
    }
    else {
        energy -= 1;  // 其他状态下持续消耗精力
    }

    // 检查精力小于15，心情-1/min
    if (energy < 15) {
        mood = std::max(0, mood - 1);
    }

    // 检查精力小于5，心情-5/min
    if (energy < 5) {
        mood = std::max(0, mood - 5);
    }
}

void HealthSystem::takeMedicine() {
    if (isSick) {
        std::cout << "我磕药了，我又行了！" << std::endl;
        // 吃药可以治愈
        health = std::min(100, health + 1);
        health = 100;
        if (health == 100) {
            isSick = false;
            canGetSick = false;  // 一天只能生病一次
        }
    }
}

void HealthSystem::sleep() {
    if (isSick) {
        std::cout << "一觉睡完，活力满满！" << std::endl;
        // 在睡觉期间好转
        health = std::min(100, health + 2);  // 每分钟好转2点健康
        if (health == 100) {
            isSick = false;
            canGetSick = false;  // 一天只能生病一次
        }
    }
    else {
        // 睡觉状态下持续恢复精力，每分钟增加5
        energy = std::min(100, energy + 5);
        std::cout << "睡觉才有精力玩！" << std::endl;
    }
}

void HealthSystem::startConcentration() {
    isConcentrating = true;
    std::cout << "我认真了！" << std::endl;
}

void HealthSystem::stopConcentration() {
    isConcentrating = false;
    std::cout << "我坚持不下去了！" << std::endl;
}

void HealthSystem::displayHealth() const {
    std::cout << "健康度: " << health << std::endl;
    std::cout << "心情值: " << mood << std::endl;
    std::cout << "精力值: " << energy << std::endl;
    std::cout << "生病: " << (isSick ? "是" : "否") << std::endl;
    std::cout << "专注模式: " << (isConcentrating ? "是" : "否") << std::endl;
}

