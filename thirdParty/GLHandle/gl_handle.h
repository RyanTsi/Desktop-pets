#pragma once

#include <QOpenGLFunctions>

class GLHandle : public QOpenGLFunctions {
public:
    inline static QOpenGLFunctions* get() {
        if(!instance)
            instance = new QOpenGLFunctions;
        return instance;
    }
    inline static void release() {
        if(!instance)
            delete instance;
        instance = nullptr;
    }
private:
    GLHandle(){}
    ~GLHandle(){}
    static QOpenGLFunctions* instance;
};