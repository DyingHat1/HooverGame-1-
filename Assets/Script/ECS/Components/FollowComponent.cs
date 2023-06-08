using System;
using UnityEngine;

[Serializable]
public struct FollowComponent
{
    public Transform Target;
    public Vector3 DistanceToTarget;
}
