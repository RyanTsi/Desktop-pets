cmake_minimum_required(VERSION 3.16)

option(
  CORE_CRL_MD
  "Use Cubism Core that is multithread-specific and DLL-specific version"
  OFF
)

# Set app name version languages
set(APP_NAME Demo)
set(APP_VERSION 1.0.0)
set(APP_LANGUAGES CXX)
# Set directory paths.
set(SDK_ROOT_PATH ${CMAKE_CURRENT_SOURCE_DIR})
set(CORE_PATH ${SDK_ROOT_PATH}/Core)
set(FRAMEWORK_PATH ${SDK_ROOT_PATH}/Framework)
set(THIRD_PARTY_PATH ${SDK_ROOT_PATH}/thirdParty)
set(STB_PATH ${THIRD_PARTY_PATH}/stb)
set(GLEW_PATH ${THIRD_PARTY_PATH}/glew)
set(GLFW_PATH ${THIRD_PARTY_PATH}/glfw)
set(RES_PATH ${SDK_ROOT_PATH}/Resources)
# set QT 资源自动编译选项
set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
# Set project.
project(${APP_NAME} VERSION ${APP_VERSION} LANGUAGES ${APP_LANGUAGES})
# set output 路径.
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/bin/${APP_NAME})
# Set configuration (Release and Debug only).
set(CMAKE_CONFIGURATION_TYPES Debug Release
  CACHE STRING "Configurations" FORCE
)
# Suppress generation of ZERO_CHECK project.
set(CMAKE_SUPPRESS_REGENERATION ON)
# Surpress GLEW and GLFW process.
set(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
set(GLFW_INSTALL OFF CACHE BOOL "" FORCE)
set(BUILD_UTILS OFF CACHE BOOL "" FORCE)
# Specify version of compiler.
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# 检测系统架构
if(CMAKE_EXE_LINKER_FLAGS STREQUAL "/machine:x64")
  set(ARCH x86_64)
elseif(CMAKE_EXE_LINKER_FLAGS STREQUAL "/machine:X86")
  set(ARCH x86)
else()
  message(FATAL_ERROR "[${APP_NAME}] Invalid linker flag ${CMAKE_EXE_LINKER_FLAGS}.")
endif()

# 检测编译器
if(MSVC_VERSION MATCHES 1800)
  # Visual Studio 2013
  set(COMPILER 120)
elseif(MSVC_VERSION MATCHES 1900)
  # Visual Studio 2015
  set(COMPILER 140)
elseif(MSVC_VERSION GREATER_EQUAL 1910 AND MSVC_VERSION LESS 1920)
  # Visual Studio 2017
  set(COMPILER 141)
elseif(MSVC_VERSION GREATER_EQUAL 1920 AND MSVC_VERSION LESS 1930)
  # Visual Studio 2019
  set(COMPILER 142)
elseif(MSVC_VERSION GREATER_EQUAL 1930 AND MSVC_VERSION LESS 1940)
  # Visual Studio 2022
  set(COMPILER 143)
elseif(MSVC)
  message(FATAL_ERROR "[${APP_NAME}] Unsupported Visual C++ compiler used.")
else()
  message(FATAL_ERROR "[${APP_NAME}] Unsupported compiler used.")
endif()

# Detect core crt.
if(CORE_CRL_MD)
  set(CRT MD)
else()
  set(CRT MT)
endif()

# Add Cubism Core.
# Import as static library.
add_library(Live2DCubismCore STATIC IMPORTED)
# Find library path.
set(CORE_LIB_SUFFIX ${CORE_PATH}/lib/windows/${ARCH}/${COMPILER})
set_target_properties(Live2DCubismCore
  PROPERTIES
    IMPORTED_LOCATION_DEBUG
      ${CORE_LIB_SUFFIX}/Live2DCubismCore_${CRT}d.lib
    IMPORTED_LOCATION_RELEASE
      ${CORE_LIB_SUFFIX}/Live2DCubismCore_${CRT}.lib
    INTERFACE_INCLUDE_DIRECTORIES ${CORE_PATH}/include
)

# Add GLEW ,GLFW.
add_subdirectory(${GLEW_PATH}/build/cmake ${CMAKE_CURRENT_BINARY_DIR}/glew)
add_subdirectory(${GLFW_PATH} ${CMAKE_CURRENT_BINARY_DIR}/glfw)

# Specify Cubism Framework rendering.
set(FRAMEWORK_SOURCE OpenGL)
# Add Cubism Native Framework.
add_subdirectory(${FRAMEWORK_PATH} ${CMAKE_CURRENT_BINARY_DIR}/Framework)
# Add rendering definition to framework.
target_compile_definitions(Framework PUBLIC CSM_TARGET_WIN_GL)
# Add include path of GLEW to framework.
target_include_directories(Framework PUBLIC ${GLEW_PATH}/include)
# Link libraries to framework.
target_link_libraries(Framework Live2DCubismCore glew_s)

# Find opengl libraries.
find_package(OpenGL REQUIRED)
# Find qt libraries.
find_package(QT NAMES Qt6 Qt5 REQUIRED COMPONENTS Widgets)
find_package(Qt${QT_VERSION_MAJOR} REQUIRED COMPONENTS Widgets)


# Make executable app.
add_executable(${APP_NAME})
# Add source files.
add_subdirectory(src)

# Link libraries to app.
target_link_libraries(${APP_NAME}
  Framework
  glfw
  Qt${QT_VERSION_MAJOR}::Widgets
  ${OPENGL_LIBRARIES}
  # Solve the MSVCRT confliction.
  debug -NODEFAULTLIB:libcmtd.lib
  optimized -NODEFAULTLIB:libcmt.lib
)

# Specify include directories.
target_include_directories(${APP_NAME} PRIVATE ${STB_PATH})
# Build in multi-process.
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