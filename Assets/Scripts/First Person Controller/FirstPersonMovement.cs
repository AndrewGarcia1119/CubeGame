using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class FirstPersonMovement : MonoBehaviour
    {
        [SerializeField]
        float speed = 5;

        Animator footstepAnimator;
        GroundCheck groundCheck;
        Vector2 velocity;
        Vector2 rawInput;

        private void Awake()
        {
            footstepAnimator = GetComponent<Animator>();
            groundCheck = GetComponentInChildren<GroundCheck>();
        }

        void FixedUpdate()
        {
            MoveCharacter();
        }

        void MoveCharacter()
        {
            velocity.x = rawInput.x * speed * Time.deltaTime;
            velocity.y = rawInput.y * speed * Time.deltaTime;
            transform.Translate(velocity.x, 0, velocity.y);
            footstepAnimator.SetBool("IsMoving", rawInput.sqrMagnitude > 0 & groundCheck.isGrounded);
        }

        void OnMove(InputValue value)
        {
            rawInput = value.Get<Vector2>();
        }


        public void ToggleMovement(bool shouldMove)
        {
            enabled = shouldMove;
        }

        private void OnDisable()
        {
            footstepAnimator.SetBool("IsMoving", false);
        }
    }

}