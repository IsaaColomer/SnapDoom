using UnityEngine;

[CreateAssetMenu]
public class GameVariables : ScriptableObject
{
    public float moveDistance = 10f;
    public float turnDegrees = 90f;
    public float moveVelocity = 30f;
    public float timeToWait = 0.15f; // time to wait when moving player corroutine
}
