using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float TurnSpeed;
	public float MoveSpeed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		
		transform.Rotate(Vector3.up, moveHorizontal * TurnSpeed * Time.deltaTime);
 
		transform.Translate(0, 0, moveVertical * MoveSpeed * Time.deltaTime);
    }
}
