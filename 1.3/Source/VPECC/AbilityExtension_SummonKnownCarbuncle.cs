﻿using RimWorld;
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
                SpawnPawn(targets.First().Cell, targets.First().Map, ability.Caster.Faction);
            }
        }
        public void SpawnPawn(IntVec3 pos, Map map, Faction faction)
        {
            if (!knownCarbuncles.NullOrEmpty())
            {
                PawnKindDef kindDef;
                knownCarbuncles.TryRandomElement(out kindDef);
                SpawnPawn(kindDef, pos, map, faction);
            }
        }
        public void SpawnPawn(PawnKindDef kindDef, IntVec3 pos, Map map, Faction faction)
        {
            PawnGenerationRequest request = new PawnGenerationRequest(kind: kindDef, faction: faction, newborn: true, forceGenerateNewPawn: true, canGeneratePawnRelations: false);
            Pawn newPawn = PawnGenerator.GeneratePawn(request);

            GenSpawn.Spawn(newPawn, pos, map);

            if (hediff != null)
            {
                newPawn.health.AddHediff(hediff);
            }
        }
    }
}
