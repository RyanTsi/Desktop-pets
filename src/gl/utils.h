#pragma once

#include <CubismFramework.hpp>
#include <string>
#include <iostream>
#include <QElapsedTimer>
#include <ICubismAllocator.hpp>
#include <QFile>
#include "LAppDefine.hpp"

using namespace Csm;


class l2dPal
{
public:
    static Csm::csmByte* LoadFileAsBytes(const std::string filePath, Csm::csmSizeInt* outSize);
    static void ReleaseBytes(Csm::csmByte* byteData);

    static void PrintLog(const Csm::csmChar* format, ...);
    static void PrintMessage(const Csm::csmChar* message);

//     static Csm::csmFloat32 GetDeltaTime();
//     static void UpdateTime();
//     static double s_currentFrame;
//     static double s_lastFrame;
//     static double s_deltaTime;
// private:
//     static QElapsedTimer timer;
};



// 内存分配器
class Allocator : public Csm::ICubismAllocator {

    void* Allocate(const Csm::csmSizeType size) {
        return malloc(size);
    }

    void Deallocate(void* memory) {
        free(memory);
    }

    void* AllocateAligned(const Csm::csmSizeType size, const Csm::csmUint32 alignment) {
        size_t offset, shift, alignedAddress;
        void* allocation;
        void** preamble;
        offset = alignment - 1 + sizeof(void*);
        allocation = Allocate(size + static_cast<csmUint32>(offset));
        alignedAddress = reinterpret_cast<size_t>(allocation) + sizeof(void*);
        shift = alignedAddress % alignment;
        if (shift) {
            alignedAddress += (alignment - shift);
        }
        preamble = reinterpret_cast<void**>(alignedAddress);
        preamble[-1] = allocation;
        return reinterpret_cast<void*>(alignedAddress);
    }

    void DeallocateAligned(void* alignedMemory) {
        void** preamble;
        preamble = static_cast<void**>(alignedMemory);
        Deallocate(preamble[-1]);
    }
};
