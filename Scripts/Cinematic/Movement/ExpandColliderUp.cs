using UnityEngine;

public class ExpandColliderUp : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private float _size;
    [SerializeField] private float _time;
    
    public void Activate(System.Action onCompleted)
    {
        StartCoroutine(Coroutine(onCompleted));
    }

    private System.Collections.IEnumerator Coroutine(System.Action onCompleted)
    {
        float time = 0;
        float normalizedTime = 0;
        Vector2 colliderSize = transform.localScale;
        Vector2 startingPosition = transform.position;
                
        while(normalizedTime < 1)
        {
            time += Time.deltaTime;
            normalizedTime = time / _time;
            transform.localScale = new Vector2(colliderSize.x,colliderSize.y + (colliderSize.y + _size)*normalizedTime);
            transform.position= startingPosition+ Vector2.up * (colliderSize.y + _size) * normalizedTime/2;
            yield return null;
        }

        onCompleted?.Invoke();
    }
}