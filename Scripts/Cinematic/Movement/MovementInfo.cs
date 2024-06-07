using System;
using UnityEngine;

[Serializable]
public class MovementInfo
{
    [field: SerializeField] public AnimationCurve SpeedCurve { get; set; }
    [field: SerializeField] public AnimationCurve CameraCurve { get; set; }
    [field: SerializeField] public Vector3 Position { get; set; }
    [field: SerializeField] public bool ChangeCameraSize { get; set; }
    [field: SerializeField] public float CameraSize { get; set; }
    [field: SerializeField] public int WaitTimeBeforeMove { get; set; }
    [field: SerializeField] public int MovingTime { get; set; }
}