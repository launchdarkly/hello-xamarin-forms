using System;
using System.Collections.Generic;
using Xamarin.Forms;
using LaunchDarkly.Xamarin;
using LaunchDarkly.Client;

namespace Hello_Xamarin_Forms
{
    public partial class MainPage : ContentPage
    {
        // enter your mobile key here
        public const string mobileKey = "";

        // change to or use the features flags you're going to be testing with
        private const string featureFlagDefaultKey = "featureFlagThatDoesntExist";
        private const string intFeatureFlag = "int-feature-flag";
        private const string boolFeatureFlag = "boolean-feature-flag";
        private const string stringFeatureFlag = "string-feature-flag";
        private const string jsonFeatureFlag = "json-feature-flag";

        // set to the user key you want to test with
        public const string userKey = "user-key";

        IList<FeatureFlag> _flags = new List<FeatureFlag>();

        public MainPage()
        {
            InitializeComponent();
        }

        ILdClient client;

        public void SetupClient()
        {
            User user = User.WithKey(userKey);
            client = LdClient.Init(mobileKey, user, TimeSpan.FromSeconds(10));
            client.FlagChanged += FeatureFlagChanged;

            LoadFlags();
        }

        void LoadFlags()
        {
            var intFlagValue = client.IntVariation(intFeatureFlag, 0);
            var intFlag = new FeatureFlag { FlagKey = intFeatureFlag, FlagValue = LdValue.Of(intFlagValue), FlagLabel = Flag1 };

            var boolFlagValue = client.BoolVariation(boolFeatureFlag, false);
            var boolFlag = new FeatureFlag { FlagKey = boolFeatureFlag, FlagValue = LdValue.Of(boolFlagValue), FlagLabel = Flag2 };

            var stringFlagValue = client.StringVariation(stringFeatureFlag, String.Empty);
            var stringFlag = new FeatureFlag { FlagKey = stringFeatureFlag, FlagValue = LdValue.Of(stringFlagValue), FlagLabel = Flag3 };

            var defaultFlagValue = client.FloatVariation(featureFlagDefaultKey, 0.0f);
            var defaultFlag = new FeatureFlag { FlagKey = featureFlagDefaultKey, FlagValue = LdValue.Of(defaultFlagValue), FlagLabel = Flag4 };

            var jsonFlagValue = client.JsonVariation(jsonFeatureFlag, LdValue.Null);
            var jsonFlag = new FeatureFlag { FlagKey = jsonFeatureFlag, FlagValue = jsonFlagValue, FlagLabel = Flag5 };

            _flags = new List<FeatureFlag> { intFlag, boolFlag, stringFlag, defaultFlag, jsonFlag };
            foreach (var f in _flags)
            {
                f.FlagLabel.Text = f.Description;
            }
        }

        public void FeatureFlagChanged(object sender, FlagChangedEventArgs args)
        {
            foreach (var f in _flags)
            {
                if (f.FlagKey == args.Key)
                {
                    f.FlagValue = args.NewValue; // we could also call client.BoolVariation(), etc.
                    f.FlagLabel.Text = f.Description;
                }
            }
        }
    }

    class FeatureFlag
    {
        public string FlagKey;

        // For this demo, we'll store all of the flag values using the general-purpose LdValue type, even though
        // we can always query flag values as a more specific type.
        public LdValue FlagValue;

        public Label FlagLabel;
        public string Description => FlagKey + " value: " + FlagValue;
    }
}
