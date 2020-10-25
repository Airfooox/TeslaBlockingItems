namespace TeslaBlockingItems
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("If set to true, player would need to have the item in hands to disable tesla, otherwise it only needs to be in the inventory.")]
        public bool OnlyInHands { get; set; } = true;
        [Description("List of the tesla disabling items, default is security guard keycard, but could be any item.")]
        public ItemType[] DisablingItems { get; set; } = { ItemType.KeycardGuard };
    }
}
