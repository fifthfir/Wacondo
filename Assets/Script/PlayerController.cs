using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

	private Animator anim;
	private SpriteRenderer theSR;
	public Rigidbody2D theRB;

	// Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
		theSR = GetComponent<SpriteRenderer>();
		theRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

		if (horizontalInput < 0) {
			theSR.flipX = false;
		} else if (horizontalInput > 0) {
			theSR.flipX = true;
		}

		theRB.velocity = new Vector2(moveSpeed * horizontalInput, moveSpeed * verticalInput);

		anim.SetFloat("moveSpeed", horizontalInput * horizontalInput + verticalInput * verticalInput);

		theRB.freezeRotation = true;
    }
}
