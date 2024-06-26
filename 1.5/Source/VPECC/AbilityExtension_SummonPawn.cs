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
                SpawnPawn(targets.First().Cell, targets.First().Map, ability.Caster as Pawn);
            }
        }

        public void SpawnPawn(IntVec3 pos, Map map, Pawn caster)
        {
            if (pawnKind != null)
            {
                Pawn pawn = PawnGenerator.GeneratePawn(pawnKind, caster.Faction);
                pawn.health.AddHediff(hediff);
                pawn.TryGetComp<Comp_CasterConnection>().casterPawn = caster;
                GenSpawn.Spawn(pawn, pos, map);
            }
        }
    }
}
