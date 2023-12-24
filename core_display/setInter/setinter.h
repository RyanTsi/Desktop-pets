#ifndef SETINTER_H
#define SETINTER_H

#include <QWidget>
#include <QCloseEvent>
namespace Ui {
class SetInter;
}

class SetInter : public QWidget
{
    Q_OBJECT

public:
    explicit SetInter(QWidget *parent = nullptr);
    ~SetInter();
    void closeEvent(QCloseEvent *e);
private slots:
    void on_favorPushButton_clicked();

    void on_moodPushButton_clicked();

    void on_healthyPushButton_clicked();

    void on_energyPushButton_clicked();

private:
    Ui::SetInter *ui;
};

#endif // SETINTER_H
