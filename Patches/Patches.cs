using EFT.InventoryLogic;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bind_Anywhere
{
    public class Bind_Anywhere
    {
        private static PropertyInfo _inventoryProperty = AccessTools.Property(typeof(InventoryController), "Inventory");

        private static HashSet<string> items = new HashSet<string> {
                    "62178c4d4ecf221597654e3d", // Red flare
                    "624c0b3340357b5f566e8766", // Yellow flare
                    "6217726288ed9f0845317459", // Green flare
                    "62178be9d0050232da3485d9" // White flare
        };

        public class IsAtBindablePlace : ModulePatch
        {
            protected override MethodBase GetTargetMethod()
            {
                _inventoryProperty = AccessTools.Property(typeof(InventoryController), "Inventory");

                return AccessTools.Method(typeof(InventoryController), nameof(InventoryController.IsAtBindablePlace));
            }

            [PatchPostfix]
            private static void Postfix(InventoryController __instance, ref bool __result, ref Item item)
            {

                var inventory = (Inventory)_inventoryProperty.GetValue(__instance);

                if (item is Weapon || item is ThrowWeapItemClass || item is MedsItemClass
                    || item is FoodItemClass || item is CompassItemClass || item is PortableRangeFinderItemClass
                    || item is RadioTransmitterItemClass || item.GetItemComponent<KnifeComponent>() != null
                    || items.Contains(item.TemplateId))
                {
                    __result = inventory.Equipment.Contains(item);
                }
            }
        }

        public class IsAtReachablePlace : ModulePatch
        {
            protected override MethodBase GetTargetMethod()
            {
                return AccessTools.Method(typeof(InventoryController), nameof(InventoryController.IsAtReachablePlace));
            }

            [PatchPostfix]
            private static void Postfix(InventoryController __instance, ref bool __result, ref Item item)
            {
                var inventory = (Inventory)_inventoryProperty.GetValue(__instance);

                __result = inventory.Equipment.Contains(item);
            }
        }
    }

}
