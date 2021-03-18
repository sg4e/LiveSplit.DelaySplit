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
            state.OnReset += OnReset;
            state.OnPause += OnPause;
            state.OnResume += OnSplit;
            state.OnSkipSplit += OnSplit;
            state.OnUndoSplit += OnSplit;
            state.OnStart += OnSplit;
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
            CancelAndDisposeLastToken();
            LastCancellationToken = new CancellationTokenSource();
            CancellationToken token = LastCancellationToken.Token;
            string splitName = State.CurrentSplit.Name.ToLowerInvariant();
            string triggerSplitName = Settings.SplitName.ToLowerInvariant();
            TimeSpan delay = Settings.GetDelayAsTimespan();
            bool smartSplit = Settings.EnableSmart;
            bool scheduleSplit = false;
            if(smartSplit)
            {
                TimeSpan? ts = ParseSmartSplit(splitName);
                if(ts != null)
                {
                    delay = (TimeSpan) ts;
                    scheduleSplit = true;
                }
            }
            if(splitName.Equals(triggerSplitName))
            {
                scheduleSplit = true;
            }
            if (scheduleSplit)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(delay, token);
                    if (!token.IsCancellationRequested)
                    {
                        Form.BeginInvoke(new Action(() => OnSplitImpl()));
                    }
                });
            }
        }

        private void OnSplitImpl()
        {
            Model.Split();
        }

        private void OnReset(object sender, TimerPhase e) => CancelAndDisposeLastToken();

        private void OnPause(object sender, EventArgs e) => CancelAndDisposeLastToken();

        private void CancelAndDisposeLastToken()
        {
            try
            {
                LastCancellationToken.Cancel();
                LastCancellationToken.Dispose();
            }
            catch(ObjectDisposedException)
            {

            }
        }

        private TimeSpan? ParseSmartSplit(string splitName)
        {
            splitName = splitName.Trim();
            string[] words = splitName.Split(' ');
            if(words.Length != 2)
                return null;
            double quantity;
            try
            {
                quantity = Convert.ToDouble(words[0]);
            }
            catch
            {
                return null;
            }
            string unitString = words[1];
            // change any singular forms to plural before comparison
            if(!unitString.EndsWith("s"))
            {
                unitString += "s";
            }
            foreach(TimeUnit unit in TimeUnit.enumerate())
            {
                if(unit.Name.Equals(unitString))
                {
                    return unit.CreateTimespan(quantity);
                }
            }
            return null;
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
