using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCurveMovement : MonoBehaviour, ICanBeActivated
{
    [SerializeField] private Transform _objectToMove;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private List<MovementInfo> MovementPositions;

    public void Activate(Action OnCompleted)
    {
        StartCoroutine(AnimationCoroutine(OnCompleted));
    }

    private IEnumerator AnimationCoroutine(Action onCompleted)
    {
        foreach (MovementInfo info in MovementPositions)
        {
            yield return MovementCoroutine(info);
        }

        onCompleted?.Invoke();
    }

    private IEnumerator MovementCoroutine(MovementInfo info)
    {
        float currentTime = 0;
        float normalizedTime = 0;
        float cameraSize = Camera.main.orthographicSize;
        Vector2 startPosition = _objectToMove.position;

        yield return new WaitForSeconds(info.WaitTimeBeforeMove);

        while (normalizedTime < 1)
        {
            if (info.ChangeCameraSize)
            {
                Camera.main.orthographicSize = cameraSize + info.CameraSize * info.CameraCurve.Evaluate(normalizedTime);
            }

            Vector3 positionToMove = Vector3.Lerp(startPosition, info.Position, info.SpeedCurve.Evaluate(normalizedTime)) + _offset;

            _objectToMove.position = positionToMove;
            currentTime += Time.deltaTime;
            normalizedTime = currentTime / info.MovingTime;

            yield return 0;
        }

        Camera.main.orthographicSize = cameraSize + info.CameraSize;
    }
}