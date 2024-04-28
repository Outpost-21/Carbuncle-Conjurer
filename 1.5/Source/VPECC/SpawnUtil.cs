using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace VPECC
{
    public static class SpawnUtil
    {
        public static void SpawnPawn(PawnKindDef kindDef, IntVec3 pos, Map map, Faction faction, HediffDef hediff)
        {
            PawnGenerationRequest request = new PawnGenerationRequest(kind: kindDef, faction: faction, fixedBiologicalAge: 0, forceGenerateNewPawn: true, canGeneratePawnRelations: false);
            Pawn newPawn = PawnGenerator.GeneratePawn(request);

            GenSpawn.Spawn(newPawn, pos, map);

            if (hediff != null)
            {
                newPawn.health.AddHediff(hediff);
            }
        }
    }
}
