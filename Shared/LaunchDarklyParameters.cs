using System;
using LaunchDarkly.Client;

namespace LaunchDarkly.Xamarin.Example
{
    // These values are used by both the Android and the iOS versions of the demo.
    public class LaunchDarklyParameters
    {
        // Set MobileKey to your LaunchDarkly mobile key.
        public const string MobileKey = "";

        // Set FlagKey to the feature flag key you want to evaluate.
        public const string FlagKey = "my-boolean-flag";

        // Set up the user properties. This user should appear on your LaunchDarkly users dashboard soon after you run the demo.
        public const string UserKey = "exmaple-user-key";

        // You may add any other desired user properties here
        public static readonly User DefaultUser = User.Builder(UserKey)
            .Name("Sandy")
            .Build();

        // How long the application will wait for the SDK to connect to LaunchDarkly
        public static TimeSpan SDKTimeout = TimeSpan.FromSeconds(10);
    }
}
