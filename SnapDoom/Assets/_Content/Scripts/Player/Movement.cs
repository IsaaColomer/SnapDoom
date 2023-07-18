using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameVariables gameVariables;
    [SerializeField] private bool debug;

    // Player Components
    private Transform cameraTransform;

    // Debug
    public GameObject moveDebugCube;

    void Awake()
    {
        cameraTransform = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ThrowRaycastToMove(cameraTransform.position, cameraTransform.forward);
        }
    }
    public RaycastHit ThrowRaycastToMove(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;

        if(Physics.Raycast(origin, direction, out hit, gameVariables.moveDistance))
        {
            // if code is here means that the raycast has touched smthing and must raycast to ground to move
            if(debug)
                Instantiate(moveDebugCube, hit.point, Quaternion.identity);
            
            // throw raycast to ground to move
            ThrowRaycastToMove(hit.point, Vector3.down);
        }
        else
        {
            Debug.Log("No Surface detected");
        }

        return hit;
    }
}
