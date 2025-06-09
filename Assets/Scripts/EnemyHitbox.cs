using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public ACharacter owner;

    private void Awake()
    {
        if (owner == null)
            owner = GetComponentInParent<ACharacter>();
    }
}

