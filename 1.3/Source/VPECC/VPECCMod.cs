using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace VPECC
{
    public class VPECCMod : Mod
    {
        public static VPECCMod mod;

        internal static string VersionDir => Path.Combine(ModLister.GetActiveModWithIdentifier("Neronix17.VPE.CarbuncleConjurer").RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public VPECCMod(ModContentPack content) : base(content)
        {
            mod = this;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            File.WriteAllText(VersionDir, CurrentVersion);

            Harmony ModHarmony = new Harmony("Neronix17.VPECC.RimWorld");
            ModHarmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
