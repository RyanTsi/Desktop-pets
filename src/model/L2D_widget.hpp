#ifndef L2D_WIDGET_H
#define L2D_WIDGET_H

#include <QApplication>
#include <GL/glew.h>
#include <QOpenGLWidget>
#include <QTimer>
#include <LAppDelegate.hpp>


class L2D_widget : public QOpenGLWidget {
    Q_OBJECT
    QTimer* ter;
public:
    L2D_widget(QWidget *parent = 0);
    ~L2D_widget();
protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);
    void mousePressEvent(QMouseEvent *event);
    void mouseReleaseEvent(QMouseEvent *event);
    void mouseMoveEvent(QMouseEvent *event);
    void timerEvent(QTimerEvent *event) override;
    void closeEvent(QCloseEvent * e) override;
};

#endif // L2D_WIDGET_H