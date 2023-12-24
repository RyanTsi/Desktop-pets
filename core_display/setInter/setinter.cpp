#include "setinter.h"
#include "src/ui_setinter.h"
#include <QButtonGroup>
SetInter::SetInter(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::SetInter)
{
    ui->setupUi(this);
    // ui->stackedWidget->setStyleSheet("QStackedWidget::tab-bar { width: 0; }");
    setWindowTitle(tr("设置"));
    this->setMaximumSize(this->size());
    this->setMinimumSize(this->size());
    QButtonGroup *buttonGroup = new QButtonGroup(this);
    buttonGroup->addButton(ui->favorPushButton);
    buttonGroup->addButton(ui->energyPushButton);
    buttonGroup->addButton(ui->healthyPushButton);
    buttonGroup->addButton(ui->moodPushButton);

}

SetInter::~SetInter()
{

    delete ui;
}

void SetInter::on_favorPushButton_clicked()
{

    ui->favorPushButton->setDown(true);
    ui->energyPushButton->setDown(false);
    ui->healthyPushButton->setDown(false);
    ui->moodPushButton->setDown(false);
    ui->stackedWidget->setCurrentIndex(0);
    qDebug()<<ui->stackedWidget->currentWidget();
}


void SetInter::on_moodPushButton_clicked()
{
    ui->favorPushButton->setDown(false);
    ui->energyPushButton->setDown(false);
    ui->healthyPushButton->setDown(false);
    ui->moodPushButton->setDown(true);
    ui->stackedWidget->setCurrentIndex(3);
    qDebug()<<ui->stackedWidget->currentWidget();
}



void SetInter::on_healthyPushButton_clicked()
{
    ui->favorPushButton->setDown(false);
    ui->energyPushButton->setDown(false);
    ui->healthyPushButton->setDown(true);
    ui->moodPushButton->setDown(false);
    ui->stackedWidget->setCurrentIndex(1);
    qDebug()<<ui->stackedWidget->currentWidget();
}


void SetInter::on_energyPushButton_clicked()
{
    ui->favorPushButton->setDown(false);
    ui->energyPushButton->setDown(true);
    ui->healthyPushButton->setDown(false);
    ui->moodPushButton->setDown(false);
    ui->stackedWidget->setCurrentIndex(2);
    qDebug()<<ui->stackedWidget->currentWidget();
}
void SetInter::closeEvent(QCloseEvent *e)
{
    e->ignore();
    this->hide();
}
