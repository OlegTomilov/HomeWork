using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0 , 0);
            ChangeToward(0);
            _animator.SetBool("Move", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            ChangeToward(180);
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);

        }
    }

    private void ChangeToward(int yAxis)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = yAxis;
        transform.rotation = Quaternion.Euler(rotation);
    }

    
}
