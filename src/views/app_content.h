#pragma once

#include <QWidget>
#include <gl_widget.h>
#include "../tray/tray.h"

class AppContent : public QWidget
{
    Q_OBJECT
public:
    explicit AppContent(QWidget *parent = nullptr);
    ~AppContent();

private:
    GLWidget* gl_widget;
    Tray *tray;

protected:
    void paintEvent(QPaintEvent* ev);

signals:

public slots:
    void trayRequestHide();
    void trayRequestResetGeometry();
private:
// #ifdef Q_OS_WIN
//     bool installHook();
//     bool uninstallHook();
// #endif
};
