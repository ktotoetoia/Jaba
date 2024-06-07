using UnityEngine;

public class StartCutSceneOnStart : MonoBehaviour
{
    private void Start()
    {
        GetComponent<ICutScene>().StartCutScene();
    }
}