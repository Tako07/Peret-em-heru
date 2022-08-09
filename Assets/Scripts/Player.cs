using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movmentSpeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementVertical = Input.GetAxis("Vertical") * movmentSpeed * Time.deltaTime;
        float movementHorizontal = Input.GetAxis("Horizontal") * movmentSpeed * Time.deltaTime;
        transform.Translate(movementHorizontal, movementVertical, 0);
    }
}
