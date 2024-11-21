using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStrategy
{
    void Move(Transform transform, Vector3 direction, float speed);
}
