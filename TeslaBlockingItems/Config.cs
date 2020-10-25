namespace TeslaBlockingItems
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("If true, all the items in the list disable the tesla (when in hand or inventory (OnlyInHands setting)). If false, disabled completely.")]
        public bool ItemsDisableTesla { get; set; } = true;
        [Description("If set to true, player would need to have the item in hands to disable tesla, otherwise it only needs to be in the inventory.")]
        public bool OnlyInHands { get; set; } = true;
        [Description("List of the tesla disabling items, default is security guard keycard, but could be any item. Don't leave it empty, set ItemsDisableTesla to false.")]
        public ItemType[] DisablingItems { get; set; } = { ItemType.KeycardGuard };

        [Description("If true, SCP 268 (the hat) disables the tesla gates when the user is using the hat.")] 
        public bool HatDisablesTesla { get; set; } = true;
    }
}
