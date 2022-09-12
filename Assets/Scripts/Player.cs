using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movmentSpeed = 10;
    private Rigidbody2D rigidBody;
    private Vector2 direction;
    public bool enableMovement;
    public bool hasTopper;
    void Start()
    {
        enableMovement = true;
        rigidBody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

    }
    private void FixedUpdate(){
        if(enableMovement)
            rigidBody.MovePosition(rigidBody.position + direction * movmentSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value){
        direction = value.Get<Vector2>();
    }
}
