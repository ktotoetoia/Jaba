using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnActivated : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private FadeTransition transition;
    [SerializeField] private string sceneName;

    public void Activate(System.Action onCompleted)
    {
        AsyncOperation operation = transition == null ?
            SceneManager.LoadSceneAsync(sceneName) :
            SceneTransitionManager.LoadSceneAsync(sceneName, transition);
        
        operation.completed += x => onCompleted?.Invoke();
    }
}