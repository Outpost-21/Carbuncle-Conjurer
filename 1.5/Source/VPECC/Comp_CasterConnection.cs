using AnimalBehaviours;
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
    public class Comp_CasterConnection : ThingComp, PawnGizmoProvider
    {
        public Pawn casterPawn;

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_References.Look(ref casterPawn, "casterPawn");
        }

        public IEnumerable<Gizmo> GetGizmos()
        {
            yield return new Command_Action
            {
                defaultLabel = "VPECC.UnsummonLabel".Translate(),
                defaultDesc = "VPECC.UnsummonDesc".Translate(),
                icon = parent.def.uiIcon,
                action = delegate
                {
                    parent.Kill();
                }
            };
        }
        public override void CompTick()
        {
            base.CompTick();
            Pawn pawn = casterPawn;
            if((pawn == null || pawn.Dead || pawn.Destroyed) ? true : false)
            {
                parent.Kill();
            }
        }
    }
}
