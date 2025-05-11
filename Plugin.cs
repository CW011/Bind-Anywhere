using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using EFT.InventoryLogic;
using EFT;
using SPT.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using static Bind_Anywhere.Bind_Anywhere;

namespace Bind_Anywhere
{

    [BepInPlugin("com.bepinex.plugins.bindanywhere", "BindAnywhere", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private static EquipmentSlot[] _extendedFastAccessSlots = {

            EquipmentSlot.Backpack,
            EquipmentSlot.SecuredContainer,
            EquipmentSlot.ArmBand,
            EquipmentSlot.TacticalVest,
            EquipmentSlot.Pockets

            };

        internal void Awake()
        {
            DontDestroyOnLoad(this);

            var fastAccessSlots = AccessTools.Field(typeof(Inventory), "FastAccessSlots");
            fastAccessSlots.SetValue(fastAccessSlots, _extendedFastAccessSlots);


            new IsAtBindablePlace().Enable();
            new IsAtReachablePlace().Enable();
        }
    }
}

