using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 direction;

    SpriteRenderer spriteRenderer;
    
    [SerializeField] float movementSpeed = 10;
    
    public Rigidbody2D rigidBody;
    
    public ContactFilter2D movementFilter;

    public float collisionOffset = 0.05f;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
   
    Animator animator;

    public bool enableMovement;
    public bool hasTopper;
    FMODUnity.StudioEventEmitter emisorpasos;
    void Start()
    {
        enableMovement = true;
        rigidBody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void FixedUpdate() {
    // If input is pressed, Calls TryMove.
        if(enableMovement){
            if(direction != Vector2.zero){
                bool success = TryMove(direction);

                if(!success){
                    success = TryMove(new Vector2(direction.x, 0));
                
                    if(!success){
                        success = TryMove(new Vector2(0, direction.y));
                    }
                }
            // Start walking animation
            animator.SetBool("isWalking", success);
            } else {
                //Stop walking animation
                animator.SetBool("isWalking", false);
            } 
            //Turn character to left or right 
            if(direction.x < 0){
                spriteRenderer.flipX = true;
            } else if (direction.x > 0) {
                spriteRenderer.flipX = false;
            }
        }else {
            animator.SetBool("isWalking", false);
        }

    }
    /*Check if wheter character must move in three cases: 
    */
    private bool TryMove(Vector2 direction){
        // If collided stop tring to move. 
        if(direction != Vector2.zero)  {

            int count = rigidBody.Cast(
                direction,
                movementFilter,
                castCollisions,
                movementSpeed * Time.fixedDeltaTime + collisionOffset);
                
            //If input is pressed, move 
            if(count == 0){
                rigidBody.MovePosition(rigidBody.position + direction * movementSpeed * Time.fixedDeltaTime);
                return true;
            } //If input is not pressed, stop
            else {
                return false;
            }

        } else {
            return false;
        }
    }


    void OnMove(InputValue value){
        direction = value.Get<Vector2>();
        emisorpasos = GameObject.Find("spasos").GetComponent<FMODUnity.StudioEventEmitter>();
        //sonido pasos

        if (direction != Vector2.zero)
        {
          if (!emisorpasos.IsPlaying()) emisorpasos.Play();
        }
        else
        {
            emisorpasos.Stop();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "pasosagua")
        {
            emisorpasos.EventInstance.setParameterByName("pasos", 1);
        }
    }
}
