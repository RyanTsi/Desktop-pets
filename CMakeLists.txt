cmake_minimum_required(VERSION 3.16)

set(CMAKE_INCLUDE_CURRENT_DIR OFF)
# 设置名字 版本 所用语言
set(APP_NAME Demo)
set(APP_VERSION 1.0.0)
project(${APP_NAME} VERSION ${APP_VERSION} LANGUAGES C CXX)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# 设置路径
set(SDK_ROOT_PATH ${CMAKE_CURRENT_SOURCE_DIR})
set(CORE_PATH ${SDK_ROOT_PATH}/Core)
set(FRAMEWORK_PATH ${SDK_ROOT_PATH}/Framework)
set(THIRD_PARTY_PATH ${SDK_ROOT_PATH}/thirdParty)
set(STB_PATH ${THIRD_PARTY_PATH}/stb)
set(GLEW_PATH ${THIRD_PARTY_PATH}/glew)
set(GLFW_PATH ${THIRD_PARTY_PATH}/glfw)
set(RES_PATH ${SDK_ROOT_PATH}/Resources)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/bin/${APP_NAME})

# 设置 QT 资源自动编译选项
set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)

# Set configuration (Release and Debug only).
set(CMAKE_CONFIGURATION_TYPES Debug Release
  CACHE STRING "Configurations" FORCE
)
set(CMAKE_SUPPRESS_REGENERATION ON)
set(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
set(GLFW_INSTALL OFF CACHE BOOL "" FORCE)
set(BUILD_UTILS OFF CACHE BOOL "" FORCE)

# 添加 live2D 库
set(ARCH x86_64)
set(COMPILER 143)
set(CRT MT)
add_library(Live2DCubismCore STATIC IMPORTED)
set(CORE_LIB_SUFFIX ${CORE_PATH}/lib/windows/${ARCH}/${COMPILER})
set_target_properties(Live2DCubismCore
  PROPERTIES
    IMPORTED_LOCATION_DEBUG
      ${CORE_LIB_SUFFIX}/Live2DCubismCore_${CRT}d.lib
    IMPORTED_LOCATION_RELEASE
      ${CORE_LIB_SUFFIX}/Live2DCubismCore_${CRT}.lib
    INTERFACE_INCLUDE_DIRECTORIES ${CORE_PATH}/include
)
# 添加 GLEW ,GLFW
add_subdirectory(${GLEW_PATH}/build/cmake ${CMAKE_CURRENT_BINARY_DIR}/glew)
add_subdirectory(${GLFW_PATH} ${CMAKE_CURRENT_BINARY_DIR}/glfw)
# 添加 Cubism Native Framework.
set(FRAMEWORK_SOURCE OpenGL)
add_subdirectory(${FRAMEWORK_PATH} ${CMAKE_CURRENT_BINARY_DIR}/Framework)
target_compile_definitions(Framework PUBLIC CSM_TARGET_WIN_GL)
target_include_directories(Framework PUBLIC ${GLEW_PATH}/include)
target_link_libraries(Framework Live2DCubismCore glew_s)

# 添加头文件搜索路径
include_directories(src/model)
include_directories(src/qt)
include_directories(src/ds)

# 搜索 OpenGL QT
find_package(OpenGL REQUIRED)
find_package(QT NAMES Qt6 Qt5 REQUIRED COMPONENTS Widgets OpenGLWidgets)
find_package(Qt${QT_VERSION_MAJOR} REQUIRED COMPONENTS Widgets OpenGLWidgets)

add_executable(${APP_NAME})
add_subdirectory(src)

# 链接库
target_link_libraries(${APP_NAME}
  Framework
  glfw
  Qt${QT_VERSION_MAJOR}::Widgets
  Qt6::OpenGLWidgets
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
      copy_directory ${RES_PATH} $<TARGET_FILE_DIR:${APP_NAME}>/Resources
)

# Set project properties.
set_target_properties(${APP_NAME} PROPERTIES
  VS_DEBUGGER_WORKING_DIRECTORY
    ${CMAKE_CURRENT_BINARY_DIR}/bin/${APP_NAME}/${CMAKE_CFG_INTDIR}
)