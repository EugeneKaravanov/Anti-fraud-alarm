using UnityEngine;

[RequireComponent(typeof(Signaling))]
public class AlarmTrigger : MonoBehaviour
{
    private Signaling _signaling;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ThiefMover>(out ThiefMover thiefMover))
        {
            _signaling.UpSignalingVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMover>(out ThiefMover thiefMover))
        {
            _signaling.DownSignalingVolume();
        }
    }
}
