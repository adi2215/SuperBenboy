using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerMovement movement;
    private Animator anim;

    private enum MovementState {idle, running, jumping, falling }

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        anim.SetTrigger("Die");
    }

    private void FixedUpdate()
    {
        MovementState state;

        if (movement.running)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (movement.vel.y > 1.5f)
        {
            state = MovementState.jumping;
        }

        else if (movement.vel.y < -1.5f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("states", (int)state);
    }
}
