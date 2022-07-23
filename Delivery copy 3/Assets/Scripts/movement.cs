using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{   
    public Transform cam;
    public GameEnds GameMng;
    public CharacterController controller;
    public float speed = 6f;
    public float turnedSmoothTime = 0.1f;
    float turnedSmoothVelocity;
    private bool isGameEnd;

    private void Start()
    {
        isGameEnd = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameEnd) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnedSmoothVelocity, turnedSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPCS")
        {
            isGameEnd = true;
            GameMng.HandleGameEnds(GameEnds.GAMEEND_REASON.HIT_PPL);
        }
        if (other.tag == "CARS")
        {
            isGameEnd = true;
            GameMng.HandleGameEnds(GameEnds.GAMEEND_REASON.HIT_CAR);
        }
    }
}
