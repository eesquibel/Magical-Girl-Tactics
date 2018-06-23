using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.DataModels
{
    [CreateAssetMenu(fileName = "New Attack", menuName = "Attack", order = 1)]
    public class AttackObject : ScriptableObject
    {
        public string objectName = "New Attack";

        public string Description = "An Awesome Attack";

        public int ActionPointCost = 2;

        public int Range = 1;

        public int Damage = 1;

        [Range(0, 1)]
        public float HitChange = .5f;
    }
}
