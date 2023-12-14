#pragma once

#include <QTimer>
#include <QMouseEvent>
#include <QElapsedTimer>
#include <QThread>

#include <QWidget>
#include <QOpenGLWidget>
#include <QPixmap>
#include "l2d.h"

class GLWidget : public QOpenGLWidget
{
    Q_OBJECT
    /* Widget Initialization */
public:
    explicit GLWidget(QWidget *parent);
    ~GLWidget() override;

private:
    // Camera
    QMatrix4x4  tf_camera;
    // Assets
    GLObj_L2d* asset_iona;

protected:
    void initializeGL() override;
    void resizeGL(int w, int h) override;
    void paintGL() override;

private slots:
    void glAnimateUpdate();
};