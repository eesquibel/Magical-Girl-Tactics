using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.DataModels
{
    public class AttackMessage
    {
        public AttackObject Attack;
        public AttackController Source;
        public HealthController Target;

        public AttackMessage(AttackObject attack, AttackController source)
        {
            Attack = attack;
            Source = source;
        }

        public AttackMessage(AttackObject attack, HealthController target)
        {
            Attack = attack;
            Target = target;
        }
    }
}
