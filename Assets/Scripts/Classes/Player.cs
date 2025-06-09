using UnityEngine;

public class Player : ACharacter
{
    protected override void Start()
    {
        base.Start();
        // Puedes inicializar cosas propias del Player aquí
    }

    protected override void Die()
    {
        base.Die();
        // Aquí puedes poner lógica extra cuando el Player muere (game over, animación, etc.)
        Debug.Log("Game Over!");
    }
}
