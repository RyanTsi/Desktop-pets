cmake_minimum_required(VERSION 3.16)

# 设置名字 版本 所用语言
set(APP_NAME Demo)
set(APP_VERSION 1.0.0)
project(${APP_NAME} VERSION ${APP_VERSION} LANGUAGES C CXX)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# 搜索 OpenGL QT
find_package(OpenGL REQUIRED)
find_package(QT NAMES Qt6 Qt5 REQUIRED COMPONENTS Core Gui Widgets Multimedia OpenGL OpenGLWidgets Core5Compat)
find_package(Qt${QT_VERSION_MAJOR} REQUIRED COMPONENTS Core Gui Widgets Multimedia OpenGL OpenGLWidgets Core5Compat)
# 设置 QT 资源自动编译选项
set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)

# 设置路径
set(THIRD_PARTY_PATH ${CMAKE_CURRENT_SOURCE_DIR}/thirdParty)
set(CORE_PATH ${THIRD_PARTY_PATH}/cubism/Core)
set(FRAMEWORK_PATH ${THIRD_PARTY_PATH}/cubism/Framework)
set(STB_PATH ${THIRD_PARTY_PATH}/stb)
set(RES_PATH ${CMAKE_CURRENT_SOURCE_DIR}/res)
set(GL_HANDLE_PATH ${THIRD_PARTY_PATH}/GLHandle)

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/bin/${APP_NAME})

set(CMAKE_SUPPRESS_REGENERATION ON)

# Determine win / linux (msvc 2022)
add_library(Live2DCubismCore STATIC IMPORTED)
if(CMAKE_HOST_WIN32)
    set_target_properties(Live2DCubismCore
    PROPERTIES 
        IMPORTED_LOCATION_DEBUG ${CORE_PATH}/lib/windows/Live2DCubismCore_MTd.lib
        IMPORTED_LOCATION_RELEASE ${CORE_PATH}/lib/windows/Live2DCubismCore_MT.lib
        INTERFACE_INCLUDE_DIRECTORIES ${CORE_PATH}/include
    )
elseif(CMAKE_HOST_UNIX)
    set_target_properties(Live2DCubismCore
    PROPERTIES 
        IMPORTED_LOCATION ${CORE_PATH}/lib/linux/libLive2DCubismCore.a
        INTERFACE_INCLUDE_DIRECTORIES ${CORE_PATH}/include
    )
endif()


# 添加 Cubism Native Framework.
set(FRAMEWORK_SOURCE OpenGL)
add_subdirectory(${FRAMEWORK_PATH} ${CMAKE_CURRENT_BINARY_DIR}/Framework)
target_include_directories(Framework PUBLIC ${GL_HANDLE_PATH})
target_link_libraries(Framework Live2DCubismCore Qt${QT_VERSION_MAJOR}::OpenGL ${OPENGL_LIBRARIES})

# 添加头文件搜索路径
include_directories(src/ds)
include_directories(src/gl)
include_directories(src/views)

add_executable(${APP_NAME})
add_subdirectory(src)
add_subdirectory(thirdParty/GLHandle)
# add_subdirectory(hook)

# add_dependencies(${APP_NAME} Framework hook)

# 链接库
target_link_libraries(${APP_NAME}
PRIVATE
  Framework
  # hook
  Qt${QT_VERSION_MAJOR}::Core
  Qt${QT_VERSION_MAJOR}::Gui
  Qt${QT_VERSION_MAJOR}::Widgets
  Qt${QT_VERSION_MAJOR}::Multimedia
  Qt${QT_VERSION_MAJOR}::OpenGL
  Qt${QT_VERSION_MAJOR}::OpenGLWidgets
  Qt${QT_VERSION_MAJOR}::Core5Compat
  ${OPENGL_LIBRARIES}
  # Solve the MSVCRT confliction.
  debug -NODEFAULTLIB:libcmtd.lib
  optimized -NODEFAULTLIB:libcmt.lib
)


target_include_directories(${APP_NAME} PRIVATE ${STB_PATH})
target_compile_options(${APP_NAME} PRIVATE /MP)

# Copy resource directory to build directory.
add_custom_command(
  TARGET ${APP_NAME}
  POST_BUILD
  COMMAND
    ${CMAKE_COMMAND} -E
      copy_directory ${RES_PATH} $<TARGET_FILE_DIR:${APP_NAME}>/res
)

# Set project properties.
set_target_properties(${APP_NAME} PROPERTIES
  VS_DEBUGGER_WORKING_DIRECTORY
    ${CMAKE_CURRENT_BINARY_DIR}/bin/${APP_NAME}/${CMAKE_CFG_INTDIR}
)