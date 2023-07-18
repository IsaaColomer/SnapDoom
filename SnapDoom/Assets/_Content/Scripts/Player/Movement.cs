using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameVariables gameVariables;
    [SerializeField] private bool debug;

    // Player Components
    private Transform cameraTransform;
    private Rigidbody rb;

    // Debug
    public GameObject moveDebugCube;

    void Awake()
    {
        cameraTransform = Camera.main.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move forward and backwards
        if(Input.GetKeyDown(KeyCode.W))
        {
            ThrowRaycastToMove(cameraTransform.position, cameraTransform.forward, 1);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            ThrowRaycastToMove(cameraTransform.position, cameraTransform.forward, -1);
        }
        else if(Input.GetKeyDown(KeyCode.A)) // Rotate
        {
            RoatatePlayer(-1f);
        }
        else if(Input.GetKeyDown(KeyCode.D)) // Rotate
        {
            RoatatePlayer(1f);
        }
    }
    public RaycastHit ThrowRaycastToMove(Vector3 origin, Vector3 direction, int fb)
    {
        RaycastHit hit;

        if(Physics.Raycast(origin, direction, out hit, gameVariables.moveDistance))
        {
            if(debug)
                Instantiate(moveDebugCube, hit.point, Quaternion.identity);
            ThrowRaycastToMove(hit.point, -hit.transform.up, 0);
        }
        else
        {
            MovePlayerToPosition(new Vector3(transform.position.x, transform.position.y, transform.position.z+gameVariables.moveDistance), fb);
        }

        return hit;
    }
    public void MovePlayerToPosition(Vector3 finalPosition, int fb)
    {
        Vector3 direction = finalPosition - transform.position;
        Vector3 normalizedDirection = direction.normalized;
        if(fb < 0)
        {
            rb.AddForce(gameVariables.moveVelocity * -transform.forward, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(gameVariables.moveVelocity * transform.forward, ForceMode.VelocityChange);
        }
        
        StartCoroutine(StopPlayer(gameVariables.timeToWait));
    }
    public IEnumerator StopPlayer(float s)
    {
        yield return new WaitForSeconds(s);
        rb.velocity = Vector3.zero;
    }

    public void RoatatePlayer(float lr)
    {
        transform.Rotate(new Vector3(0f,gameVariables.turnDegrees*lr,0f), Space.Self);
    }
}
