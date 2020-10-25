using CustomPlayerEffects;
using Exiled.API.Features;

namespace TeslaBlockingItems.Handlers
{
    using Exiled.Events.EventArgs;
    using System.Linq;

    class Player
    {
        public void OnTriggeringTesla(TriggeringTeslaEventArgs eventArgs)
        {
            if (TeslaKeycardBlocker.Instance.Config.ItemsDisableTesla)
            {
                // Get all disabling items listed in config
                ItemType[] disablingItemTypes = TeslaKeycardBlocker.Instance.Config.DisablingItems;

                // Check wether item needs to be in hand or is only required in inventory
                if (TeslaKeycardBlocker.Instance.Config.OnlyInHands)
                {
                    if (disablingItemTypes.Contains<ItemType>(eventArgs.Player.Inventory.curItem))
                    {
                        // Disable tesla gate trigger
                        eventArgs.IsTriggerable = false;
                    }
                }
                else
                {
                    // Search inventory of the player for any of the disabling items
                    if (eventArgs.Player.Inventory.items.Any<Inventory.SyncItemInfo>(item =>
                        disablingItemTypes.Contains(item.id)))
                    {
                        // Disable tesla gate trigger
                        eventArgs.IsTriggerable = false;
                    }
                }
            }

            // If SCP 268 is active, disable tesla trigger
            if (TeslaKeycardBlocker.Instance.Config.HatDisablesTesla && eventArgs.Player.ReferenceHub.playerEffectsController.GetEffect<Scp268>().Enabled)
            {
                eventArgs.IsTriggerable = false;
            }

            // CASSIE Announcment -> alle x Minuten Statusmeldung über aktuelle Anzahl von Leuten in der Facility nach Klassen sortiert (Facility Scan)
        }
    }
}
