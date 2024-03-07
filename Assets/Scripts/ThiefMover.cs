using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);

    private Animator _animator;
    private float _speed = 3;
    private float _direction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw(Horizontal);
        transform.Translate(new Vector2(_speed * _direction, 0) * Time.deltaTime);
        _animator.SetFloat(Speed, Math.Abs(_direction));
    }
}
