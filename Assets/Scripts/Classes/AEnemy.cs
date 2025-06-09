using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEnemy : ACharacter
{
    public int goldDrop;
    public int expDrop;

    // M�todo protegido virtual -> las subclases pueden sobrescribirlo o llamarlo tal cual.
    protected virtual void Drop()
    {
        Debug.Log($"Dropped {goldDrop} gold and {expDrop} experience.");

        // TODO: Aqu� puedes implementar:
        // - A�adir oro al jugador.
        // - A�adir experiencia al jugador.
        // - Spawnear objetos de oro o experiencia en el mundo.
    }
}
