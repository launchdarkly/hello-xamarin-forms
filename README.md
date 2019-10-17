## LaunchDarkly Sample Xamarin Applications

To demonstrate basic usage of the LaunchDarkly Xamarin SDK, we've built two applications that both do the same thing: one for Android and one for iOS. The only differences between them are in the platform-specific application startup code; the user interface is implemented in a shared project using Xamarin Forms.

In both applications, there is a single boolean feature flag whose on or off state appears on the screen. The application listens for `FeatureFlagChanged` events from the SDK, so that if the flag is changed on your LaunchDarkly dashboard, it will be updated promptly on the screen.

### Build instructions

1. Make sure you have [Visual Studio](https://visualstudio.microsoft.com/downloads/) installed; the Android app can be run from either Windows or Mac, but the iOS app requires Mac. For Windows, you must use Visual Studio 2017 or later. For Mac, besides Visual Studio you must also have [Xcode](https://itunes.apple.com/us/app/xcode/id497799835?ls=1&mt=12).
2. Open `Hello-Xamarin-Forms.sln` in Visual Studio.
3. Open `LaunchDarklyParameters.cs` in the `Shared` project. Set `MobileKey` and `FlagKey` to the mobile key for your LaunchDarkly environment and the key of a boolean feature flag in your environment. If you want to test feature flag targeting for different users, you can also change `UserKey` or add more properties in `DefaultUser`.
4. Run the `XamarinAndroidApp` or `XamarinIOSApp` project in Visual Studio for Mac.
