using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using VFECore.Abilities;
using AbilityDef = VFECore.Abilities.AbilityDef;

namespace VPECC
{
    [DefOf]
    public static class VPECCDefOf
    {
        static VPECCDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(VPECCDefOf));
        }

        public static AbilityDef VPECC_SummonCarbuncleBlack;
        public static AbilityDef VPECC_SummonCarbuncleBlue;
        public static AbilityDef VPECC_SummonCarbuncleGreen;
        public static AbilityDef VPECC_SummonCarbuncleYellow;
        public static AbilityDef VPECC_SummonCarbuncleRed;
        public static AbilityDef VPECC_SummonCarbuncleWhite;

        public static PawnKindDef VPECC_SummonedCarbuncleBlack;
        public static PawnKindDef VPECC_SummonedCarbuncleBlue;
        public static PawnKindDef VPECC_SummonedCarbuncleGreen;
        public static PawnKindDef VPECC_SummonedCarbuncleYellow;
        public static PawnKindDef VPECC_SummonedCarbuncleRed;
        public static PawnKindDef VPECC_SummonedCarbuncleWhite;
    }
}
