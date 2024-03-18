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
    public class AbilityExtension_SummonPawn : AbilityExtension_AbilityMod
    {
        public PawnKindDef pawnKind;

        public int count = 1;

        public HediffDef hediff;

        public override void Cast(GlobalTargetInfo[] targets, VFECore.Abilities.Ability ability)
        {
            base.Cast(targets, ability);
            for (int i = 0; i < count; i++)
            {
                SpawnPawn(targets.First().Cell, targets.First().Map, ability.Caster.Faction);
            }
        }
        public void SpawnPawn(IntVec3 pos, Map map, Faction faction)
        {
            if (pawnKind != null)
            {
                PawnKindDef kindDef = pawnKind;
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
