#include "LAppDelegate.hpp"

int main() {
    // create the application instance
    if (LAppDelegate::GetInstance()->Initialize() == GL_FALSE) {
        return 1;
    }

    LAppDelegate::GetInstance()->Run();
    return 0;
}