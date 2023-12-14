#pragma once

#include <QAbstractNativeEventFilter>
#include <QObject>
#include <QEvent>
#include <QPoint>

#ifdef Q_OS_WIN
#include "Windows.h"
#endif

class AppNativeEvFilter : public QObject,  public QAbstractNativeEventFilter
{
    Q_OBJECT
public:
    AppNativeEvFilter();

    virtual bool nativeEventFilter
        (const QByteArray &eventType, void *message, qintptr *result) override;

private:
#ifdef Q_OS_WIN
    static const UINT WM_IONAGL_LOOKAT;
#endif

signals:
    void sendGlMouseEvent
        (const QEvent::Type type, const Qt::MouseButton b, const QPoint pt);
};
