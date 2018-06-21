### LaunchDarkly Sample Xamarin Application
We've built a Xamarin.Forms application that demonstrates how LaunchDarkly's SDK works with both iOS and Android using the Xamarin platform.
Below, you'll find the basic build procedure, but for more comprehensive instructions, you can visit your [Quickstart page](https://app.launchdarkly.com/quickstart#/).
##### Build instructions

1. Make sure you have [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) installed along with [Xcode](https://itunes.apple.com/us/app/xcode/id497799835?ls=1&mt=12).
2. Make sure you're in this directory.
3. Open `Hello-Xamarin-Forms.sln` in Visual Studio for Mac.
4. Copy the mobile key from your account settings page and the feature flag key(s) from your LaunchDarkly dashboard into the SetupClient() method inside `MainPage.xaml.cs.`
5. Select the platform you want to run on in Visual Studio's targeted device selector and press run.
