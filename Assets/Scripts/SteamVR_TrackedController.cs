using System;

internal class SteamVR_TrackedController
{
    public Action<object, ClickedEventArgs> TriggerClicked { get; internal set; }
}