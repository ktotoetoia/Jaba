using System;
using UnityEngine;
using AYellowpaper;

public class CutSceneU : MonoBehaviour, ICutScene
{
    [SerializeField] protected InterfaceReference<ICanBeActivated> _toActivate;
    [SerializeField] private CutSceneMain _cutSceneMain;

    public virtual void StartCutScene()
    {
        _cutSceneMain.StartCutScene(_toActivate.Value);
    }
}