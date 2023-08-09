using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Ball")) {
            onTriggerEnter.Invoke();
        }
    }
}
