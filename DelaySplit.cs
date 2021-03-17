using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.DelaySplit
{
    public class DelaySplit : IComponent
    {
        private LiveSplitState State;
        private TimerModel Model;
        private CancellationTokenSource LastCancellationToken;
        private Form Form;
        private Settings Settings;

        public DelaySplit(LiveSplitState state)
        {
            Settings = new Settings();
            ContextMenuControls = new Dictionary<string, Action>();
            this.State = state;
            Model = new TimerModel();
            Model.CurrentState = state;
            Form = state.Form;
            LastCancellationToken = new CancellationTokenSource();
            state.OnSplit += OnSplit;
        }

        public string ComponentName => "DelaySplit";

        public float HorizontalWidth => 0;

        public float MinimumHeight => 0;

        public float VerticalHeight => 0;

        public float MinimumWidth => 0;

        public float PaddingTop => 0;

        public float PaddingBottom => 0;

        public float PaddingLeft => 0;

        public float PaddingRight => 0;

        public IDictionary<string, Action> ContextMenuControls { get; protected set; }

        private void OnSplit(object sender, EventArgs e)
        {
            LastCancellationToken.Cancel();
            LastCancellationToken.Dispose();
            LastCancellationToken = new CancellationTokenSource();
            CancellationToken token = LastCancellationToken.Token;
            String splitName = State.CurrentSplit.Name;
            Task.Run(async () => {
                if (splitName.Equals("auto"))
                {
                    await Task.Delay(5000, token);
                    if (!token.IsCancellationRequested)
                    {
                        Form.BeginInvoke(new Action(() => OnSplitImpl()));
                    }
                }
            });
        }

        private void OnSplitImpl()
        {
            Model.Split();
        }

    public void Dispose()
        {
            LastCancellationToken.Cancel();
            LastCancellationToken.Dispose();
        }

        public void DrawHorizontal(System.Drawing.Graphics g, LiveSplitState state, float height, System.Drawing.Region clipRegion)
        {

        }

        public void DrawVertical(System.Drawing.Graphics g, LiveSplitState state, float width, System.Drawing.Region clipRegion)
        {

        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public int GetSettingsHashCode()
        {
            return Settings.GetSettingsHashCode();
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {

        }
    }
}
