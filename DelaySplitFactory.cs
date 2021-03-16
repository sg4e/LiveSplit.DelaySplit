using System;
using LiveSplit.Model;
using LiveSplit.UI.Components;
using LiveSplit.DelaySplit;

[assembly: ComponentFactory(typeof(DelaySplitFactory))]

namespace LiveSplit.DelaySplit
{
    public class DelaySplitFactory : IComponentFactory
    {
        public string ComponentName => "DelaySplit";

        public string Description => "Automatically splits after a set delay.";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => GetType().Assembly.GetName().Version;

        public IComponent Create(LiveSplitState state) => new DelaySplit(state);

    }
}
