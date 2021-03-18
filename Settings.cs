using System;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;

namespace LiveSplit.DelaySplit
{
    public partial class Settings : UserControl
    {
        public double Delay { get; set; }
        public TimeUnit SelectedTimeUnit { get; set; }
        public string SplitName { get; set; }
        public bool EnableSmart { get; set; }

        public Settings()
        {
            InitializeComponent();
            DelayUnitBox.Items.AddRange(TimeUnit.enumerate());
            // defaults
            Delay = 45;
            SelectedTimeUnit = TimeUnit.Seconds;
            SplitName = "Swap Game";
            EnableSmart = false;

            // set defaults to UI
            DelayNumericUpDown.Value = (int) Delay;
            DelayUnitBox.SelectedItem = SelectedTimeUnit;
            SplitNameTextBox.Text = SplitName;
            SmartSplitDelayCheckbox.Checked = EnableSmart;

            // bind to UI
            DelayNumericUpDown.DataBindings.Add("Value", this, "Delay");
            DelayUnitBox.DataBindings.Add("SelectedItem", this, "SelectedTimeUnit");
            SplitNameTextBox.DataBindings.Add("Text", this, "SplitName");
            SmartSplitDelayCheckbox.DataBindings.Add("Checked", this, "EnableSmart");
        }

        public TimeSpan GetDelayAsTimespan()
        {
            return SelectedTimeUnit.CreateTimespan(Delay);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");

            SettingsHelper.CreateSetting(document, parent, "Delay", Delay);
            SettingsHelper.CreateSetting(document, parent, "TimeUnit", SelectedTimeUnit.ToString());
            SettingsHelper.CreateSetting(document, parent, "SplitName", SplitName);
            SettingsHelper.CreateSetting(document, parent, "EnableSmart", EnableSmart);

            return parent;
        }

        public void SetSettings(XmlNode settings)
        {
            var element = (XmlElement) settings;
            Delay = SettingsHelper.ParseDouble(element["Delay"]);
            SelectedTimeUnit = TimeUnit.FromString(SettingsHelper.ParseString(element["TimeUnit"]));
            SplitName = SettingsHelper.ParseString(element["SplitName"]);
            EnableSmart = SettingsHelper.ParseBool(element["EnableSmart"]);
        }

        public int GetSettingsHashCode()
        {
            unchecked {
                int res = Delay.GetHashCode();
                res = (res * 397) ^ SelectedTimeUnit.GetHashCode();
                res = (res * 397) ^ SplitName.GetHashCode();
                res += EnableSmart ? 1 : 0;
                return res;
            }
        }
    }
}
