using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animation;
    private Player _player;
    
    void Start()
    {
        _animation = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.isPlayerOne == true)
        {
             if (Input.GetKeyDown(KeyCode.A))
            {
                _animation.SetBool("TurnLeft", true);
                _animation.SetBool("TurnRight", false);
            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                _animation.SetBool("TurnLeft", false);
                _animation.SetBool("TurnRight", false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _animation.SetBool("TurnRight", true);
                _animation.SetBool("TurnLeft", false);
            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                _animation.SetBool("TurnRight", false);
                _animation.SetBool("TurnRight", false);
            }
        }
        else
        {
             if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animation.SetBool("TurnLeft", true);
            _animation.SetBool("TurnRight", false);
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animation.SetBool("TurnLeft", false);
            _animation.SetBool("TurnRight", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _animation.SetBool("TurnRight", true);
            _animation.SetBool("TurnLeft", false);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animation.SetBool("TurnRight", false);
            _animation.SetBool("TurnRight", false);
        }
        }


       



    }
}
