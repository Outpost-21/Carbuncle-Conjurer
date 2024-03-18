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
    public class AbilityExtension_SummonRandomPawn : AbilityExtension_AbilityMod
    {
        public List<PawnKindDef> pawnKinds;

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
            if (!pawnKinds.NullOrEmpty())
            {
                PawnKindDef kindDef = pawnKinds.RandomElement();
                SpawnUtil.SpawnPawn(kindDef, pos, map, faction, hediff);
            }
        }
    }
}
