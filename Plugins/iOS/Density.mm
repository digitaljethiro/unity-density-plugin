#import <UIKit/UIKit.h>

extern "C" {
    float IOSDensity_();
}

float IOSDensity_() {
    return [UIScreen mainScreen].scale;
}