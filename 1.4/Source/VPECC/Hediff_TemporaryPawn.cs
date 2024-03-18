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
    public class Hediff_TemporaryPawn : HediffWithComps
    {
        public override void Tick()
        {
            base.Tick();
            if(Severity >= def.maxSeverity)
            {
                pawn.Destroy();
            }
        }
    }
}
