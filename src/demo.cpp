#include "demo.h"

demo::demo(QWidget* parent)
    : QMainWindow(parent)
    , ui(new Ui_demo)
{
    ui->setupUi(this);
}

demo::~demo()
{
    delete ui; 
}