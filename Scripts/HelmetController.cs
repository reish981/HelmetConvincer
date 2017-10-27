using UnityEngine;
using System.Collections;

/// <summary>Determines how the helmet interacts with the scene and the player.</summary>
public class HelmetController : MonoBehaviour
{
    [SerializeField]
    public Transform target;
	/// <summary>The target property represents the helmet's target for orientation.</summary>
    /// <value>The target property represents the value of the target object.</value>
	
    Animator animator;
	/// <summary>The animator property represents the player.</summary>
    /// <value>The animator property represents the player's animator.</value>
	
    public bool dead = false;
	/// <summary>The dead property determines if the player has died.</summary>
    /// <value>The dead property determines the state of the player's life</value>

//    public Camera cam1;
//    public Camera cam2;

	/// <summary>Start is a method called at the scene's start.</summary>
    void Start()
    {
        animator = target.GetComponent<Animator>();
    }

    /// <summary>Update is a method called when the scene updates.</summary>
    void Update()
    {
		// Gets values for animator
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool space = Input.GetKeyDown("space");
		
		// Actions performed when the spacebar is pressed
        if (space)
        {
            dead = true;
        }

		// Update animator
        animator.SetFloat("Speed_f", v);
        //animator.SetFloat("Strafe", h);
        animator.SetBool("Death_b", dead);
    }
	
	/// <summary>OnCollisionEnter is a method called when the helmet collides with another rigidbody.</summary>
    void OnCollisionEnter(Collision col)
    {
        dead = true;
        //Destroy(col.gameObject);
    }
}