using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ThiefMover>(out ThiefMover thiefMover))
        {
            ThiefEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMover>(out ThiefMover thiefMover))
        {
            ThiefExited?.Invoke();
        }
    }
}
