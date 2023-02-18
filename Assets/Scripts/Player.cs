using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

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
        Walk();
    }

    private void Walk()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0 , 0);
            ChangeToward(0);
            _animator.SetBool(States.Move, true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            ChangeToward(180);
            _animator.SetBool(States.Move, true);
        }
        else
        {
            _animator.SetBool(States.Move, false);

        }
    }

    private void ChangeToward(int yAxis)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = yAxis;
        transform.rotation = Quaternion.Euler(rotation);
    }
}

static class States
{
    public const string Move = nameof(Move);
}
