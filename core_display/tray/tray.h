#ifndef IONADESKTOP_CORE_DISPLAY_TRAY_H
#define IONADESKTOP_CORE_DISPLAY_TRAY_H

#include <QSystemTrayIcon>
#include <QVector>
#include <QAction>
#include "setInter/setinter.h"
namespace IonaDesktop {
namespace CoreDisplay {
    class Tray : public QSystemTrayIcon
    {
        Q_OBJECT
    public:
        Tray(QWidget* parent);
        void showInterForm();
    private:
        QMenu* menu;
        QAction* app_hide;
        QAction* app_reset_geo;
        QAction* app_exit;
        QAction* set_Form;
        SetInter *m_setForm;
    private slots:
        void terminate();

        // Unused. preserve for further feature
        void trayActivated(const QSystemTrayIcon::ActivationReason& reason);
    };
}
}


#endif // IONADESKTOP_CORE_DISPLAY_TRAY_H
