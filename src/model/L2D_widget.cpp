#include <QApplication>
#include <GL/glew.h>
#include <QOpenGLWidget>
#include <QTimer>
#include <LAppDelegate.hpp>
#include <L2D_widget.hpp>

namespace {
    constexpr int frame = 40;
    constexpr int fps = 1000/frame;
}

L2D_widget::L2D_widget(QWidget *parent) : QOpenGLWidget(parent) {
    this->startTimer(fps);
}

L2D_widget::~L2D_widget() { }

void L2D_widget::initializeGL() {
    LAppDelegate::GetInstance()->Initialize(this);
    LAppDelegate::GetInstance()->resize(this->width(),this->height());
}

void L2D_widget::paintGL() {
    LAppDelegate::GetInstance()->update();
}

void L2D_widget::resizeGL(int width, int height) {
    LAppDelegate::GetInstance()->resize(width,height);
}

void L2D_widget::mousePressEvent(QMouseEvent *event) {
    
}

void L2D_widget::mouseReleaseEvent(QMouseEvent *event) {
    
}

void L2D_widget::mouseMoveEvent(QMouseEvent *event) {
    
}

void L2D_widget::timerEvent(QTimerEvent*) {
    this->update();
}

void L2D_widget::closeEvent(QCloseEvent * e) {

}