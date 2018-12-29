using System.Collections;

using UnityEngine;

public enum AIState { NONE, WANDER, RUN, CHASE }

[RequireComponent(typeof(SnowballMover))]
public class AIController : MonoBehaviour 
{
    public static readonly float decisionDeltaTime = 0.05f;

    public float speed;
    public Transform player;

    private AIState state;
    private SnowballMover mover;
    private Vector3 decidedVelocity;
    
    private float stuckTimer = 0f;
    private Vector3 stuckPosition;

    private Vector3 movement;

    private void Awake() 
    {
        mover = GetComponent<SnowballMover>();
        state = AIState.NONE;
    }

    private void Start() 
    {
        stuckPosition = transform.position;
        InvokeRepeating("DecisionUpdate", 0f, decisionDeltaTime);
    }

    private void Update() 
    {
        // print((transform.position - stuckPosition).sqrMagnitude);
        if ((transform.position - stuckPosition).sqrMagnitude < 1f * Time.deltaTime) 
        {
            stuckTimer += Time.deltaTime;
        }
        else 
        {
            stuckTimer = 0f;
        }

        stuckPosition = transform.position;

        switch (state)
        {
            case AIState.WANDER:
                break;
            case AIState.RUN:
                var dir = player.position - transform.position;
                movement.x = -dir.x;
                movement.z = -dir.z;
                break;
            case AIState.CHASE:
                dir = player.position - transform.position;
                movement.x = dir.x;
                movement.z = dir.z;
                break;
        }   

        // rb.velocity = decidedVelocity + Physics.gravity;
        movement.Normalize();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, 4f)) 
        {
            if (hit.collider.CompareTag("Edible")) 
            {
                if (hit.collider.GetComponent<Edible>().edibleThreshold > GetComponentInChildren<SnowballGrow>().size)
                {
                    movement = Quaternion.AngleAxis(Random.Range(10, 50f), Vector3.up) * movement;
                }
            }
        }

        if (stuckTimer > 1f) {
            print(true);
            movement = Quaternion.AngleAxis(40f, Vector3.up) * movement;
            stuckTimer = 0f;
        }

        mover.UpdateVelocity(movement.x, movement.z);
    }

    private void DecisionUpdate() 
    {
        // Decision Variables
        var distSquared = (transform.position - player.position).sqrMagnitude;
        var isBigger = transform.GetComponentInChildren<SnowballGrow>().size > player.GetComponentInChildren<SnowballGrow>().size;

        if (!isBigger && distSquared < 100f) 
        {
            if (state == AIState.RUN) return;
            state = AIState.RUN;
        }
        // else if (isBigger && distSquared < 25f)
        // {
        //     if (state == AIState.CHASE) return;
        //     state = AIState.CHASE;
        // }
        else 
        {
            if (state == AIState.WANDER) return;
            state = AIState.WANDER;
            movement.x = Random.value;
            movement.z = 1 - movement.x;
        }
    }
}