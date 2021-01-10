using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    private Joystick joystick;

    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;


    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool isOnStair = false;

    [SerializeField]
    private bool isJump = false;


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public bool IsJump { get => isJump; set => isJump = value; }
    public bool IsOnStair { get => isOnStair; set => isOnStair = value; }

    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        isJump = false;
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        
        if (isGrounded) State = CharState.Idle;

        Run();

        if (isGrounded && isJump && !isOnStair) Jump();

        if (isOnStair) RunVertical();
    }

    private void Run()
    {
        if (joystick.Horizontal >= -0.2f && joystick.Horizontal <= 0.2f) return;
        Vector3 direction = transform.right * joystick.Horizontal;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }
    private void RunVertical()
    {
        if (joystick.Vertical >= -0.2f && joystick.Vertical <= 0.2f) return;
        Vector3 direction = transform.up * joystick.Vertical;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        
    }

    private void Jump()
    {

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isJump = false;
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }


}



public enum CharState
{
    Idle,
    Run,
    Jump
}