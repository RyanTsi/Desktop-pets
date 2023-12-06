add_subdirectory(model)
add_subdirectory(qt)
add_subdirectory(ds)
target_sources(${APP_NAME}
  PRIVATE
    ${CMAKE_CURRENT_SOURCE_DIR}/main.cpp
    ${CMAKE_CURRENT_SOURCE_DIR}/test.cpp
)

