using System.Collections.Generic;
using UnityEngine;

public class CutSceneMain : MonoBehaviour
{
    [SerializeField] protected List<MonoBehaviour> _turnOffDuringCutScene;

    public virtual void StartCutScene(ICanBeActivated toActivate)
    {
        _turnOffDuringCutScene.ForEach(x =>
        {
            x.enabled = false;
        });

        toActivate.Activate(() => _turnOffDuringCutScene.ForEach(x => x.enabled = true));
    }
}