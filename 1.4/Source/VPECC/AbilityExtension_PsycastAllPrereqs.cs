using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using VanillaPsycastsExpanded;
using VFECore.Abilities;

namespace VPECC
{
    public class AbilityExtension_PsycastAllPrereqs : AbilityExtension_Psycast
    {
        public new bool PrereqsCompleted(CompAbilities compAbilities)
        {
            return prerequisites.NullOrEmpty() || prerequisites.All(pr => compAbilities.LearnedAbilities.Any(ab => ab.def == pr));
        }
    }
}
