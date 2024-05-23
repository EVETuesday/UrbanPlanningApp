import com.android.build.api.dsl.BuildFeatures

plugins {
    id("com.android.application")
}

android {
    namespace = "com.example.urbanplanning"
    compileSdk = 34

    defaultConfig {
        applicationId = "com.example.urbanplanning"
        minSdk = 24
        targetSdk = 34
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(getDefaultProguardFile("proguard-android-optimize.txt"), "proguard-rules.pro")
        }
    }

    buildFeatures{
        viewBinding=true;
    }

    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }
}

dependencies {

    implementation("androidx.appcompat:appcompat:1.6.1")
    implementation("com.google.android.material:material:1.12.0")
    implementation("androidx.test:monitor:1.6.1")
    implementation("androidx.test.ext:junit:1.1.5")
    implementation("com.google.code.gson:gson:2.10")
    implementation("com.squareup.picasso:picasso:2.71828")


    configurations.implementation {
        exclude("gson")
        exclude("okhttp")
    }
    implementation("androidx.constraintlayout:constraintlayout:2.1.4")
    implementation("com.google.firebase:firebase-crashlytics-buildtools:3.0.0")
    implementation("com.google.firebase:protolite-well-known-types:18.0.0")
    testImplementation("junit:junit:4.13.2")
    androidTestImplementation("androidx.test.ext:junit:1.1.5")
    androidTestImplementation("androidx.test.espresso:espresso-core:3.5.1")
}
