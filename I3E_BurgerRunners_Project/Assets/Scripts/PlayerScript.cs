using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using TMPro; 
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// Movement speed of the player
    /// </summary>
    public float movementSpeed = 5f; 
    
    /// <summary>
    /// Determine the player's Rigidbody
    /// </summary>
    public Rigidbody rb;
    
    /// <summary>
    /// A bool to see if the player is touching the ground
    /// </summary> 
    public bool playerGrounded = true; 

    /// <summary>
    /// jump height of the player
    /// </summary> 
    public float jumpHeight = 5f; 
 
    Vector3 horizontalInput = Vector3.zero; 
 
    Vector3 verticalInput = Vector3.zero; 

    /// <summary>
    /// mouse sensitivity
    /// </summary>
    public float mouseSensitivity = 0.2f; 

    /// <summary>
    /// Determine the player camera
    /// </summary>
    public Transform camera; 

    /// <summary>
    /// A bool to check if the player is moving
    /// </summary>
    public bool playermovement;
    
    /// <summary>
    /// Determine the image
    /// </summary>
    public GameObject Image;

    /// <summary>
    /// Determine the text
    /// </summary>
    public GameObject Text;

    /// <summary>
    /// Determine the button
    /// </summary>
    public GameObject Button;



    /// <summary>
    /// Player look function
    /// </summary>
    void OnLook(InputValue value) 
    { 
        horizontalInput.y = value.Get<Vector2>().x; 
        verticalInput.x = -value.Get<Vector2>().y; 
        verticalInput.x = Mathf.Clamp(verticalInput.x, -90f, 90f); 
    } 

    /// <summary>
    /// Player death function
    /// </summary>
    public void Death() 
    { 
        GetComponent<Animator>().SetTrigger("DangerObject"); 
    } 

    /// <summary>
    /// Player collision function
    /// </summary>
    private void OnCollisionEnter(Collision collision) 
    { 
        if(collision.gameObject.tag == "Floor")
        { 
            playerGrounded = true; 
        } 
 
        if(collision.gameObject.tag == "Red") 
        { 
            GetComponent<Animator>().enabled = true; 
            Death(); 
            playermovement = false; 
        }

        if(collision.gameObject.tag == "GameEnd")
        {
            Image.SetActive(true);
            Text.SetActive(true);
            Button.SetActive(true);
        }
    }


 
    void Update() 
    { 
        if(playermovement == true) 
        { 
            // walk 
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed; 
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed; 
 
            transform.Translate(horizontal, 0, vertical); 
             
            // jump 
            if(Input.GetButtonDown("Jump") & playerGrounded) 
            { 
                rb.AddForce(new Vector3(0,jumpHeight,0), ForceMode.Impulse); 
                playerGrounded = false; 
                Debug.Log("Player jumps."); 
            } 
 
            // player look 
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + horizontalInput * mouseSensitivity); 
            camera.rotation = Quaternion.Euler(camera.rotation.eulerAngles + new Vector3(verticalInput.x,0f,0f) * mouseSensitivity); 
        } 
    } 
 
    // Start is called before the first frame update 
    void Start() 
    {    
        //GetComponent<Animator>().enabled = false; 
        // for jump 
        rb = GetComponent<Rigidbody>(); 
        Image.SetActive(false);
        Text.SetActive(false);
        Button.SetActive(false);
    } 
 
    // Update is called once per frame 
}
