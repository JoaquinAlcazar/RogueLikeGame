using UnityEngine;

public class Player : ACharacter
{
    protected override void Start()
    {
        base.Start();
        // Puedes inicializar cosas propias del Player aqu�
    }

    protected override void Die()
    {
        base.Die();
        // Aqu� puedes poner l�gica extra cuando el Player muere (game over, animaci�n, etc.)
        Debug.Log("Game Over!");
    }
}
