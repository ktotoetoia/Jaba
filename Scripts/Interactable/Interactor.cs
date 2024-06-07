using UnityEngine;
using System.Linq;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _radius;

    private void Update()
    {
        InteractableLibrary.Instance.GetObjectsInRadius(transform.position, _radius).FirstOrDefault()?.OnCanInteract();
    }


    public void Interact()
    {
        InteractableLibrary.Instance
            .GetObjectsInRadius(transform.position, _radius)
            .FirstOrDefault()?.Interact(gameObject);
    }
}
