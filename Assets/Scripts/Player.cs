// using System.Collections;
// using System.Collections.Generic;
// using DG.Tweening;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     [SerializeField] private Animator _animator;
//     [SerializeField] private Transform _cameraTransform;
//     [SerializeField] private CharacterController _controller;
//     [SerializeField] private float moveSpeed = 5.0f;
    
//     private const float LEFT_BOUNDRY = -10.0f;
//     private const float RIGHT_BOUNDRY = 10.0f;
//     private const float JUMP_COOLDOWN = 2.5f;
//     private const float SLIDE_COOLDOWN = 1.0f;
//     private const float CAMERA_OFFSET = 4.2f;
//     private const float LEFT_LANE = -6.0f;
//     private const float CENTER_LANE = 0.0f;
//     private const float RIGHT_LANE = 6.0f;

//     private float lateralSpeed = 6.0f;
//     private float moveDuration = 0.25f;
//     private float moveDurationX2 = 0.5f;
//     private float currXPos = 0.0f;
//     private float currYPos = 0.0f;
//     private float currZPos = 0.0f;

//     private float jumpCooldown = JUMP_COOLDOWN;
//     private float slideCooldown = SLIDE_COOLDOWN;
    
//     private bool isSliding = false;
//     private bool isJumping = false;
//     private bool isMoving = false;
//     private bool isRunning = false;
//     private bool isFirstTime = true;
    
//     private Transform _transform;

    
//     // Start is called before the first frame update
//     void Start()
//     {
//         _transform = transform;
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         UpdateState();
//         if (isFirstTime) {
//             isFirstTime = false;
//             _transform.DOMoveX(0.0f, moveDuration);
//             _transform.DOMoveY(0.0f, moveDuration);
//         }
//         if (isRunning) DefaultMove();
//         else CustomMove();

//     }

//     void FixedUpdate() {
        
//         if (_transform.position.y > 0.0f) 
//             _transform.DOMoveY(0.0f, 0.5f);

//     }

//     void UpdateState() {

//         currXPos = _transform.position.x;
//         currYPos = _transform.position.y;
//         currZPos = _transform.position.z;
//         jumpCooldown += Time.deltaTime;
//         slideCooldown += Time.deltaTime;

//         isMoving  = !(currXPos == LEFT_LANE || currXPos == CENTER_LANE || currXPos == RIGHT_LANE);
//         isJumping = !(jumpCooldown >= JUMP_COOLDOWN);
//         isSliding = !(slideCooldown >= SLIDE_COOLDOWN);

//         _animator.SetBool("isMoving", false);
//         _animator.SetBool("isDancing", false);
//         isRunning = _animator.GetBool("isRunning");

//     }

//     void DefaultMove() {

//         // Move the player object forward for running
//         // _controller.Move(forwardSpeed * Time.deltaTime * _transform.forward);
//          // Move the character forward by moveSpeed units per second
//         _transform.DOMoveZ(moveSpeed + currZPos, moveDurationX2).SetEase(Ease.Linear);

//         _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y, currZPos - CAMERA_OFFSET);

//         // Move the player object left and right
//         if (Input.GetKey(KeyCode.A) && !isMoving) {
//             if (currXPos - lateralSpeed > LEFT_BOUNDRY) {
//                 // _controller.Move(_transform.right * -1 * moveSpeed * Time.deltaTime);
//                 _transform.DOMoveX(-lateralSpeed + currXPos, moveDuration).SetEase(Ease.InOutSine);
//             }
            
//         }
//         else if (Input.GetKey(KeyCode.D) && !isMoving) {
//             if (currXPos + lateralSpeed < RIGHT_BOUNDRY) {
//                 // _controller.Move(_transform.right * 1 * moveSpeed * Time.deltaTime);
//                 _transform.DOMoveX(lateralSpeed + currXPos, moveDuration).SetEase(Ease.InOutSine);
//             }
//         }

//         if (Input.GetKeyDown(KeyCode.S) && !isSliding && !isJumping) {
//             _animator.SetTrigger("Slide");
//             slideCooldown = 0.0f;
//         }
//         else if (Input.GetKeyDown(KeyCode.W) && !isJumping && !isSliding) {
//             _animator.SetTrigger("Jump");
//             jumpCooldown = 0.0f;
//         }
//         else if (Input.GetKeyDown(KeyCode.Space) && !isSliding && !isJumping) {
//             _animator.SetTrigger("Leap");
//             slideCooldown = 0.0f;
//         }




//     }

//     void CustomMove() {

//         // Move the player object left and right
//         if (Input.GetKey(KeyCode.A)) {
//             _transform.Rotate(Vector3.up, -90.0f * Time.deltaTime);
//             // _transform.Rotate(new Vector3(0, -90.0f * Time.deltaTime, 0), Space.World);
//             _animator.SetBool("isMoving", true);

//         }
//         else if (Input.GetKey(KeyCode.D)) {
//             _transform.Rotate(Vector3.up, 90.0f * Time.deltaTime);
//             // _transform.Rotate(new Vector3(0, 90.0f * Time.deltaTime, 0), Space.World);
//             _animator.SetBool("isMoving", true);
//         }

//         // Move the player object forwards and backwards
//         if (Input.GetKey(KeyCode.S)) {
//             _transform.Rotate(Vector3.up, 180.0f * Time.deltaTime);
//             // _transform.Rotate(new Vector3(0, 180.0f * Time.deltaTime, 0), Space.World);
//             _animator.SetBool("isMoving", true);
//         }
//         else if (Input.GetKey(KeyCode.W)) {
//             // _transform.Translate(moveSpeed * Time.deltaTime * _transform.forward, Space.World);
//             _controller.Move(moveSpeed * Time.deltaTime * _transform.forward);
//             _animator.SetBool("isMoving", true);
//         }
        
//         if (Input.GetKeyDown(KeyCode.Space)) {
//             _animator.SetBool("isDancing", true);
//         }

//         // move = _transform.right * x + _transform.forward * z;
//         // _controller.Move(move * moveSpeed * .5f * Time.deltaTime);

//     }

// }
