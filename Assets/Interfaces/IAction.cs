using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction {

    int ActionPointCost { get; }

    bool CanDoAction();

    bool TryDoAction();
}
