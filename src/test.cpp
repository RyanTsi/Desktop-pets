#include <QMainWindow>

class demo : public QMainWindow {
    Q_OBJECT
    
public:
    demo(QWidget* parent = nullptr);
    ~demo();

private:
    Ui_demo* ui;
};
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