using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ThiefMover>())
        {
            ThiefEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMover>())
        {
            ThiefExited?.Invoke();
        }
    }
}
