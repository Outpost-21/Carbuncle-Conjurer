using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using VFECore.Abilities;

namespace VPECC
{
    public class AbilityExtension_SummonKnownCarbuncle : AbilityExtension_AbilityMod
    {
        public List<PawnKindDef> knownCarbuncles = new List<PawnKindDef>();

        public int count = 1;

        public HediffDef hediff;

        public override void Cast(GlobalTargetInfo[] targets, VFECore.Abilities.Ability ability)
        {
            base.Cast(targets, ability);

            CompAbilities compAbilities = ability.pawn.GetComp<CompAbilities>();

            knownCarbuncles.Clear();
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleBlack)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleBlack); }
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleBlue)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleBlue); }
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleGreen)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleGreen); }
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleRed)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleRed); }
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleYellow)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleYellow); }
            if (compAbilities.HasAbility(VPECCDefOf.VPECC_SummonCarbuncleWhite)) { knownCarbuncles.Add(VPECCDefOf.VPECC_SummonedCarbuncleWhite); }

            for (int i = 0; i < count; i++)
            {
                SpawnPawn(targets.First().Cell, targets.First().Map, ability.Caster as Pawn);
            }
        }

        public void SpawnPawn(IntVec3 pos, Map map, Pawn caster)
        {
            if (!knownCarbuncles.NullOrEmpty())
            {
                PawnKindDef kindDef;
                knownCarbuncles.TryRandomElement(out kindDef);
                Pawn pawn = PawnGenerator.GeneratePawn(kindDef, caster.Faction);
                pawn.health.AddHediff(hediff);
                pawn.TryGetComp<Comp_CasterConnection>().casterPawn = caster;
                GenSpawn.Spawn(pawn, pos, map);
            }
        }
    }
}
