using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public bool isMobileDevice;

	public bool isGrounded=false;

	[HideInInspector] public Transform groundCheck;
	public LayerMask groundLayer; // Insert the layer here.

	[HideInInspector] public GameObject actor;	// the actual graphical representation of the player
	[HideInInspector] public Animator anim;	// the animation controller of the actor

	[HideInInspector] public Rigidbody2D rb;	// the player's rigidbody
	public float jumpForce = 10f;
	public float moveSpeed = 5f;

	public enum Direction : sbyte
	{
		Left = -1,
		Right = 1,
		Up = 2,
		Down = -2
	}

	public sbyte currentDirection = 1;

	// Use this for initialization
	void Start () {
		if(Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.LinuxEditor || 
			Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor ||
			Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
			isMobileDevice = false;
		else
			isMobileDevice = true;

		// Get the actor object which is a child of the player object
		actor = transform.Find("Actor").gameObject;

		// Get the actor's animation controller
		anim = actor.GetComponent<Animator>();

		// Get the groundcheck transform
		groundCheck = transform.Find("GroundCheck");

		// Get the rigidbody
		rb = GetComponent<Rigidbody2D>();

		anim.SetBool("jumped", false);
		anim.SetFloat("horizontalSpeed", 0.0f);
		anim.SetFloat("verticalSpeed", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// call the proper Control function
		if(isMobileDevice)
			ControlsMobile();
		else 
			ControlsDesktop();

		// check if the player is grounded
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);	// checks if you are within 0.1 position in the Y of the ground

		// Update the animator parameters
		Vector2 velocity = rb.velocity;

		if(velocity.x != 0f)
			anim.SetFloat("horizontalSpeed", 1f);
		else
			anim.SetFloat("horizontalSpeed", 0f);

		anim.SetFloat("verticalSpeed", velocity.y);

		if(isGrounded)
			anim.SetBool("jumped", false);
	}

	// call this to get input on desktop
	void ControlsDesktop()
	{
		// jump
		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
			if(isGrounded)
				anim.SetBool("jumped", true);
		}

		// movement
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(currentDirection != (sbyte)Direction.Right)
			{
				actor.GetComponent<SpriteRenderer>().flipX = false;
				currentDirection = (sbyte)Direction.Right;
			}

			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(currentDirection != (sbyte)Direction.Left)
			{
				actor.GetComponent<SpriteRenderer>().flipX = true;
				currentDirection = (sbyte)Direction.Left;
			}

			rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
		}

		if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
			rb.velocity = new Vector2(0, rb.velocity.y);
	}

	// call this to get input on mobile
	void ControlsMobile()
	{

	}
}
