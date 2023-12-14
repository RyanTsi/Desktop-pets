cmake_minimum_required(VERSION 3.5)

project(hook)
set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

find_package(Qt6 REQUIRED COMPONENTS Core)

find_package(QT NAMES Qt6 Qt5 REQUIRED COMPONENTS Core)
find_package(Qt${QT_VERSION_MAJOR} REQUIRED COMPONENTS Core)

add_library(hook SHARED
    hook.h
    hook.cpp
)
target_compile_definitions(hook PUBLIC HOOK_LIBRARY)
target_link_libraries(hook 
  PRIVATE 
    QtQt${QT_VERSION_MAJOR}::Core
)
set_target_properties(hook 
PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY ${OUTPUT_PATH}
)
