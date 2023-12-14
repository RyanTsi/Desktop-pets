#pragma once

#include <QObject>
#include "gl_handle.h"
#include <QOpenGLWidget>
#include <QOpenGLShader>
#include <QOpenGLShaderProgram>
#include <QOpenGLVertexArrayObject>
#include <QOpenGLBuffer>
#include <QOpenGLTexture>
#include <GL/glu.h>


class GLObjectBase : public QObject
{
    Q_OBJECT
    friend class GLWidget;
public:
    GLObjectBase(QOpenGLWidget* parent)
        : QObject(parent) {}
    virtual ~GLObjectBase(){}
    virtual void init() = 0;
    virtual void resize(){}
    virtual void paint() = 0;

private:

protected:

};