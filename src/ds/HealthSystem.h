// HealthSystem.hpp
#pragma once

class HealthSystem {
public:
    HealthSystem();
    ~HealthSystem();

    void updateHealth(int temperature, int energy);
    void takeMedicine();  // 吃药
    void sleep();  // 睡觉

    void startConcentration();  // 开始专注
    void stopConcentration();   // 停止专注

    void displayHealth() const;  // 显示健康状态


private:
    int health;  // 健康状态
    int mood;    // 心情状态
    int energy;  // 精力状态

    bool isSick;  // 是否处于生病状态
    bool canGetSick;  // 是否可以生病

    bool isConcentrating;  // 是否处于专注模式


};
