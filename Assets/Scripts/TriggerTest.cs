using UnityEngine;

public class TestTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger activated by: {other.gameObject.name} with tag {other.tag}");
    }
}
