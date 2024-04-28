using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.AI.Group;

namespace VPECC
{
    public class DeathActionWorker_Vanish : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord lord)
        {
            corpse.Destroy();
        }
    }
}
