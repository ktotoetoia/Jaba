using System;
using UnityEngine;
using System.Collections.Generic;
using AYellowpaper;

public class ActivateAll : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private List<InterfaceReference<ICanBeActivated>> _toActivate;

    public void Activate(Action onCompleted)
    {
        int completedActionsCount = 0;
     
        Action onEachCompleted = () =>
        {
            completedActionsCount++;

            if (completedActionsCount == _toActivate.Count)
            {
                onCompleted?.Invoke();
            }
        };

        _toActivate.ForEach(x => x.Value.Activate(onEachCompleted));
    }
}