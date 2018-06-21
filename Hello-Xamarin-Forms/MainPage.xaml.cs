using System;
using System.Collections.Generic;
using Xamarin.Forms;
using LaunchDarkly.Xamarin;
using LaunchDarkly.Client;
using Newtonsoft.Json.Linq;

namespace Hello_Xamarin_Forms
{
    public partial class MainPage : ContentPage, IFeatureFlagListener
    {
        // enter your mobile key here
        public const string mobile_key = "";

        // change to or use the features flags your going to be testing with
        private const string featureFlagDefaultKey = "featureFlagThatDoesntExist";
        private const string int_feature_flag = "int-feature-flag";
        private const string bool_feature_flag = "boolean-feature-flag";
        private const string string_feature_flag = "string-feature-flag";
        private const string json_feature_flag = "json-feature-flag";

        // set to the user key you want to test with
        public const string user_key = "";


        IList<FeatureFlag> _flags = new List<FeatureFlag>();

        public MainPage()
        {
            InitializeComponent();
        }

        ILdMobileClient client;

        public void SetupClient()
        {
            User user = User.WithKey(user_key);
            client = LdClient.Init(mobile_key, user);
            client.RegisterFeatureFlagListener(int_feature_flag, this);
            client.RegisterFeatureFlagListener(bool_feature_flag, this);
            client.RegisterFeatureFlagListener(string_feature_flag, this);
            client.RegisterFeatureFlagListener(json_feature_flag, this);

            LoadFlags();
        }

        void LoadFlags()
        {
            var intFlagValue = client.IntVariation(int_feature_flag, 0);
            var intFlag = new FeatureFlag { FlagKey = int_feature_flag, FlagValue = intFlagValue };
            Flag1.Text = intFlag.FlagKey + " value: " + intFlag.FlagValue;

            var boolFlagValue = client.BoolVariation(bool_feature_flag, false);
            var boolFlag = new FeatureFlag { FlagKey = bool_feature_flag, FlagValue = boolFlagValue };
            Flag2.Text = boolFlag.FlagKey + " value: " + boolFlag.FlagValue;

            var stringFlagValue = client.StringVariation(string_feature_flag, String.Empty);
            var stringFlag = new FeatureFlag { FlagKey = string_feature_flag, FlagValue = stringFlagValue };
            Flag3.Text = stringFlag.FlagKey + " value: " + stringFlag.FlagValue;

            var defaultFlagValue = client.FloatVariation(featureFlagDefaultKey, 0.0f);
            var defaultFlag = new FeatureFlag { FlagKey = featureFlagDefaultKey, FlagValue = defaultFlagValue };
            Flag4.Text = defaultFlag.FlagKey + " value: " + defaultFlag.FlagValue;

            var jsonFlagValue = client.JsonVariation(json_feature_flag, null);
            var jsonFlag = new FeatureFlag { FlagKey = json_feature_flag, FlagValue = jsonFlagValue };
            Flag5.Text = jsonFlag.FlagKey + " value: " + jsonFlag.FlagValue;
        }

        public void FeatureFlagChanged(string featureFlagKey, JToken value)
        {
            string flagDescription = featureFlagKey + " value: " + value;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (featureFlagKey == int_feature_flag)
                    Flag1.Text = flagDescription;

                if (featureFlagKey == bool_feature_flag)
                    Flag2.Text = flagDescription;

                if (featureFlagKey == string_feature_flag)
                    Flag3.Text = flagDescription;

                if (featureFlagKey == featureFlagDefaultKey)
                    Flag4.Text = flagDescription;

                if (featureFlagKey == json_feature_flag)
                    Flag5.Text = flagDescription;
                    
            });
        }

        public void FeatureFlagDeleted(string featureFlagKey)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (featureFlagKey == int_feature_flag)
                    Flag1.Text = String.Empty;

                if (featureFlagKey == bool_feature_flag)
                    Flag2.Text = String.Empty;

                if (featureFlagKey == string_feature_flag)
                    Flag3.Text = String.Empty;

                if (featureFlagKey == featureFlagDefaultKey)
                    Flag4.Text = String.Empty;

                if (featureFlagKey == json_feature_flag)
                    Flag5.Text = String.Empty;
            });
        }
    }

    class FeatureFlag
    {
        public string FlagKey;
        public JToken FlagValue;
    }
}
