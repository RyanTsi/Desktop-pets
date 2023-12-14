#include "app_content.h"
#include "app_param.h"
#include "app_msg_handler.h"

AppContent::AppContent(QWidget *parent)
    : QWidget(parent)
{
    this->setWindowFlag(Qt::Tool);
    this->setWindowFlag(Qt::FramelessWindowHint);
    this->setAttribute(Qt::WA_TranslucentBackground);
    this->setWindowFlag(Qt::WindowStaysOnTopHint);
    this->setWindowFlag(Qt::NoDropShadowWindowHint);
    QPoint widget_pos;
    AppParam::getInstance().getParam("S$window/pos", widget_pos);
    this->setGeometry(QRect(widget_pos, QSize(400, 300)));
    AppParam::getInstance().setParam("D$window/center", this->geometry().center());

    AppMsgHandler::getInstance().bindSlot
        ("/window/hide", this, SLOT(trayRequestHide()));
    AppMsgHandler::getInstance().bindSlot
        ("/window/reset_geometry", this,  SLOT(trayRequestResetGeometry()));
    tray = new Tray(this);
    gl_widget = new GLWidget(this);
    gl_widget->lower();
    gl_widget->show();

}

AppContent::~AppContent()
{
}

void AppContent::paintEvent(QPaintEvent* ev)
{
    ev->accept();
}

void AppContent::trayRequestHide()
{
    if(this->isHidden())
        this->show();
    else this->hide();
}

void AppContent::trayRequestResetGeometry()
{
    this->setGeometry(0, 0, 400, 300);
    update();
}

// #ifdef Q_OS_WIN
// bool AppContent::installHook()
// {
// //    HMODULE hDll = nullptr;
//     HWND m_hWnd = (HWND)this->winId();
//     BOOL hookMouseState = Hook::InstallMouseHook(m_hWnd);
// //    BOOL hookKeybordState = Hook::InstallKeybordHook();
//     if (!hookMouseState)
//         qDebug() << "[Hook] Install failed";
//     else
//         qDebug() << "[Hook] install success";
//     return hookMouseState;
// }

// bool AppContent::uninstallHook()
// {
//     BOOL hookMouseState = Hook::UnInstallMouseHook();
// //    BOOL hookKeybordState = Hook::UnInstallKeybordHook();
//     if (!hookMouseState)
//         qDebug() << "[Hook] Uninstall failed";
//     else
//         qDebug() << "[Hook] Uninstall success";
//     return hookMouseState;
// }
// #endif
