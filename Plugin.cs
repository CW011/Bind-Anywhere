using BepInEx;
using BepInEx.Logging;
using Spt.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bind_Anywhere
{
    [BepInPlugin("com.bepinex.plugins.bindanywhere", "Bind Anywhere", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin test
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! Hi!")
        }
    }
}

// test