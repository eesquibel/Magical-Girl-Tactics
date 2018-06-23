using Assets.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Events;

namespace Assets.Events
{
    [Serializable]
    public class TurnStartEvent : UnityEvent<TurnStartParameters>
    {
    }
}
