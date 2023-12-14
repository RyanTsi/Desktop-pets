#include <QtGlobal>
#include "utils.h"
#include <cstdio>
#include <stdarg.h>
#include <sys/stat.h>
#include <iostream>
#include <fstream>
#include <QIODevice>
#include <QFile>
#include <Model/CubismMoc.hpp>
#include "LAppDefine.hpp"

using std::endl;
using namespace Csm;
using namespace std;

// double l2dPal::s_currentFrame = 0.0;
// double l2dPal::s_lastFrame = 0.0;
// double l2dPal::s_deltaTime = 0.0;

// QElapsedTimer l2dPal::timer;

csmByte* l2dPal::LoadFileAsBytes(const string filePath, csmSizeInt* outSize)
{
    QFile file(QString(filePath.c_str()));
    if(file.open(QIODevice::ReadOnly))
    {
        QByteArray byteArray = file.readAll();
        *outSize = byteArray.size();
        char* buffer = new char[*outSize];
        memcpy(buffer, byteArray.data(), *outSize);
        return reinterpret_cast<csmByte*>(buffer);
    }
    else
    {
        *outSize = 0;
        if (LAppDefine::DebugLogEnable)
            PrintLog("file open error");
        return nullptr;
    }
}

void l2dPal::ReleaseBytes(csmByte* byteData)
{ delete[] byteData; }

// csmFloat32  l2dPal::GetDeltaTime()
// {  return static_cast<csmFloat32>(s_deltaTime); }

// void l2dPal::UpdateTime()
// {
//     static bool flag_init = false;
//     if(!flag_init) {
//         timer.start();
//         flag_init = true;
//     }
//     s_currentFrame = timer.elapsed();
//     s_deltaTime = (s_currentFrame - s_lastFrame) / 1000;
//     s_lastFrame = s_currentFrame;
// }

void l2dPal::PrintLog(const csmChar* format, ...)
{
    va_list args;
    csmChar buf[256];
    va_start(args, format);
#ifdef Q_OS_WIN
    vsnprintf_s(buf, sizeof(buf), format, args); // 標準出力でレンダリング
#endif
#ifdef Q_OS_LINUX
    vsnprintf(buf, sizeof(buf), format, args);
#endif
#ifdef CSM_DEBUG_MEMORY_LEAKING
// メモリリークチェック時は大量の標準出力がはしり重いのでprintfを利用する
    std::printf(buf);
#else
    std::cerr << buf << std::endl;
#endif
    va_end(args);
}

void l2dPal::PrintMessage(const csmChar* message)
{
    PrintLog("%s", message);
}
