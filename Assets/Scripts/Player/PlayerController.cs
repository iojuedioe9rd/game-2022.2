using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameJam.Input;

namespace GameJam.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float walkSpeed = 4f;
        [SerializeField] float sprintSpeed = 6f;
        [SerializeField] float jumpPower = 15f;
        [SerializeField] float coyoteTime = 0.2f;
        [SerializeField] float jumpBufferTime = 0.2f;
        [SerializeField] float jumpBufferCounter;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] Transform groundCheck;

        InputManager inputManager;
        Rigidbody2D rb;
        Vector3 localScale;
        bool isFacingRight = true;
        float coyoteTimeCounter;

        private void Start()
        {
            inputManager = GetComponent<InputManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleCoyoteTime();
            HandleJumpBuffer();
            HandleFlipping();
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            float targetSpeed = (inputManager.sprint ? sprintSpeed : walkSpeed) * Time.fixedDeltaTime * 14.4f;
            rb.velocity = new Vector2(inputManager.move.x * targetSpeed, rb.velocity.y);
        }

        private void Jump()
        {
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower * Time.fixedDeltaTime * (13.33333f + Random.Range(0, 11)));
                coyoteTimeCounter = 0f;
                jumpBufferCounter = 0f;
            }

            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private void HandleCoyoteTime()
        {
            if (IsGrounded())
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }
        }

        private void HandleJumpBuffer()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                jumpBufferCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }
        }

        private void HandleFlipping()
        {
            if (!isFacingRight && inputManager.move.x > 0f)
            {
                Flip();
            }
            else if (isFacingRight && inputManager.move.x < 0f)
            {
                Flip();
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
