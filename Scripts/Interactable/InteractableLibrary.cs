using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableLibrary
{
    private static InteractableLibrary _instance;
    private List<Interactable> _objects = new List<Interactable>();

    public static InteractableLibrary Instance
    { 
        get
        {
            return _instance ??= new InteractableLibrary();
        }
    }

    public void Add(Interactable obj)
    {
        _objects.Add(obj);
    }

    public void Remove(Interactable obj)
    {
        _objects.Remove(obj);
    }

    public List<Interactable> GetObjectsInRadius(Vector2 position, float radius)
    {
        return _objects
            .Where(x => x.IsAvailable() && Vector2.Distance(position,x.transform.position) <= radius)
            .OrderBy(x =>Vector2.Distance(position, x.transform.position))
            .ToList();
    }
}