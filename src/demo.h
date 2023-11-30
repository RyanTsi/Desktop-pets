#pragma once
#include "ui_demo.h"
#include <QMainWindow>

class demo : public QMainWindow {
    Q_OBJECT
    
public:
    demo(QWidget* parent = nullptr);
    ~demo();

private:
    Ui_demo* ui;
};