using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/Player")]
public class Player : ACharacter
{
    public Inventory inventory;
    public int gold;
    public int exp;
    public int nextLevelExp;
    public int keys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Input()
    {

    }
}
