using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _speed = 5;
    private CharacterController _controller;
    [SerializeField]private float _gravity = 1;
    [SerializeField] private float _jumpHeight = 15 ;
    private float _yVelocity;
    private bool _doubleJumpActive=true;
    private int _coins;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
      
        if (_controller.isGrounded==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _doubleJumpActive = true;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)&&_doubleJumpActive==true)
            {
                _yVelocity += _jumpHeight;
                _doubleJumpActive = false;
            }
            _yVelocity -=_gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move( velocity*Time.deltaTime);      
    }
    public void AddToScore(int points)
    {
        _coins += points;
        UIManager.Instance.UpdateCoinDisplay(_coins);
    }
}
