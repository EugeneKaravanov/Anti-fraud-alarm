using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefMover : MonoBehaviour
{
    private float _speed = 3;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(_speed, 0) * Time.deltaTime);
            _animator.SetFloat("Speed", _speed);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(new Vector2(-_speed, 0) * Time.deltaTime);
            _animator.SetFloat("Speed", _speed);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}
