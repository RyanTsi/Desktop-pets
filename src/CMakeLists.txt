add_subdirectory(gl)
add_subdirectory(ds)
# add_subdirectory(hook)
add_subdirectory(views)
target_sources(${APP_NAME}
  PRIVATE
    ${CMAKE_CURRENT_SOURCE_DIR}/main.cpp
)

