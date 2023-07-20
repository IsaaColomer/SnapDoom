using UnityEngine;

[CreateAssetMenu]
public class GunsVariables : ScriptableObject
{
    public float bulletAmmount = 9f;
    public float cadence = 0.15f;
    public GameObject bulletPrefab;
    public float bulletVelocity;
}
