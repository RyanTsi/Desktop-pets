#include <QApplication>
#include <QTextCodec>
#include <QSharedMemory>
#include "gl_widget.h"
#include "app_content.h"
#include "app_msg_handler.h"
#include "app_param.h"
#include "app_native_ev_filter.h"

int main(int argc, char** argv) {
    QApplication app(argc, argv);
    
    QTextCodec *codec = QTextCodec::codecForName("UTF-8");
    QTextCodec::setCodecForLocale(codec);    
    QSharedMemory singleton_shared("desktop-core-display");
    if(singleton_shared.attach())
    {
        qDebug() << "[APP] CoreDisplay(Singleton) is already running. Exit.";
        return 0;
    }
    singleton_shared.create(1);
    // Load app singletons
    AppMsgHandler::getInstance();
    AppParam::getInstance();

    // Init native event filter for receiving mouse / keyboard message
    AppNativeEvFilter* native_evf = new AppNativeEvFilter();
    app.installNativeEventFilter(native_evf);
    AppContent* display = new AppContent();

    display->show();

    return app.exec();
}