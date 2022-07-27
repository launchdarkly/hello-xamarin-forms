# LaunchDarkly sample Xamarin application

We've built two simple mobile applications that demonstrate how LaunchDarkly's SDK works.

Important: these demos are for the _client-side_ .NET SDK, which is suitable for mobile or desktop applications. For server-side use, visit https://github.com/launchdarkly/hello-dotnet-server.

Below, you'll find the basic build procedures, but for more comprehensive instructions, you can visit your [Quickstart page](https://app.launchdarkly.com/quickstart#/) page or the [client-side .NET SDK reference guide](https://docs.launchdarkly.com/sdk/client-side/dotnet).

There are two versions of the demo, one for Android and one for iOS. The only differences between them are in the platform-specific application startup code. The user interface is implemented in a shared project using Xamarin Forms.

## Build instructions

The Android and iOS demos require Visual Studio to build and run. For iOS, besides Visual Studio you must also have [Xcode](https://itunes.apple.com/us/app/xcode/id497799835?ls=1&mt=12). You can run either on a real device or a simulator.

1. Open `Hello-Xamarin-Forms.sln` in Visual Studio.

2. Edit `LaunchDarklyParameters.cs` in the `Shared` directory and set the value of `MobileKey` and `FlagKey` to your LaunchDarkly mobile key. If there is an existing boolean feature flag in your LaunchDarkly project that you want to evaluate, set `FlagKey` to the flag key. If you want to test feature flag targeting for different users, you can also change `UserKey` or add more properties in `DefaultUser`.

```
public const string MobileKey = "1234567890abcdef";

public const string FlagKey = "my-boolean-flag";
```

3. Run the `XamarinAndroidApp` or `XamarinIOSApp` project in Visual Studio for Mac.

You should receive the message ”Feature flag ‘<flag key>’ is <true/false> for this user”.
