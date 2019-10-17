using LaunchDarkly.Xamarin;
using Xamarin.Forms;

namespace LaunchDarkly.Xamarin.Example
{
    public partial class MainPage : ContentPage
    {
        private ILdClient client;

        public MainPage()
        {
            InitializeComponent();
        }

        public void SetupClient()
        {
            if (string.IsNullOrEmpty(LaunchDarklyParameters.MobileKey))
            {
                SetMessage(ExampleMessages.MobileKeyNotSet);
            }
            else
            {
                client = LdClient.Init(
                    // These values are set in the Shared project
                    LaunchDarklyParameters.MobileKey,
                    LaunchDarklyParameters.DefaultUser,
                    LaunchDarklyParameters.SDKTimeout
                );
                if (client.Initialized)
                {
                    UpdateFlagValue();
                    client.FlagChanged += FeatureFlagChanged;
                }
                else
                {
                    SetMessage(ExampleMessages.InitializationFailed);
                }
            }
        }

        void SetMessage(string s)
        {
            Message.Text = s;
        }

        void UpdateFlagValue()
        {
            var flagValue = client.BoolVariation(LaunchDarklyParameters.FlagKey, false);
            SetMessage(string.Format(ExampleMessages.FlagValueIs, flagValue));
        }

        void FeatureFlagChanged(object sender, FlagChangedEventArgs args)
        {
            if (args.Key == LaunchDarklyParameters.FlagKey)
            {
                UpdateFlagValue();
            }
        }
    }
}
