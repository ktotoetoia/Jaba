using UnityEngine;
using System.Collections.Generic;
using AYellowpaper;
using System.Linq;

public class StartCutSceneOnInteract : Interactable
{
    [SerializeField] private List<InterfaceReference<IBoolean>> _conditions;

    private ICutScene _cutScene;

    protected override void Start()
    {
        _cutScene = GetComponent<ICutScene>();

        base.Start();
    }

    public override void Interact(GameObject user)
    {
        _cutScene.StartCutScene();
        base.Interact(user);
    }

    public override bool IsAvailable()
    {
        return _conditions.All(x => x.Value.Boolean);
    }
}