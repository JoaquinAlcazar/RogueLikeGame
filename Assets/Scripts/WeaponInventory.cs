using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class WeaponInventory : MonoBehaviour
{
    [Header("Cheat Options")]
    public bool unlockAllWeapons = false;


    [Header("Available Weapon Prefabs")]
    public GameObject swordPrefab;
    public GameObject sniperPrefab;
    public GameObject grenadeLauncherPrefab;
    public GameObject flamethrowerPrefab;

    [Header("Weapon Holder")]
    public Transform weaponHolder;

    public float desiredWeaponScale = 1f; // Scale for the weapon instances
    private List<GameObject> ownedWeapons = new List<GameObject>();
    private int currentWeaponIndex = 0;

    private void Start()
    {
        if (unlockAllWeapons)
        {
            // Add all weapons
            AddWeapon(swordPrefab);
            AddWeapon(sniperPrefab);
            AddWeapon(grenadeLauncherPrefab);
            AddWeapon(flamethrowerPrefab);
        }
        else
        {
            // Start with sword only
            AddWeapon(swordPrefab);
        }

        EquipWeapon(0);
    }


    private void Update()
    {
        HandleWeaponSwitchInput();
    }

    public void AddWeapon(GameObject weaponPrefab)
    {
        // Check if already owned
        if (ownedWeapons.Exists(w => w.name.StartsWith(weaponPrefab.name)))
            return;

        // Instantiate weapon and parent it to the weapon holder
        GameObject weaponInstance = Instantiate(weaponPrefab, weaponHolder);
        weaponInstance.SetActive(false); // Deactivate until selected
        weaponInstance.transform.localScale = Vector3.one * desiredWeaponScale;

        ownedWeapons.Add(weaponInstance);
    }

    private void EquipWeapon(int index)
    {
        // Deactivate all weapons
        for (int i = 0; i < ownedWeapons.Count; i++)
        {
            ownedWeapons[i].SetActive(i == index);
        }

        currentWeaponIndex = index;
    }

    private void HandleWeaponSwitchInput()
    {
        float scrollValue = Mouse.current.scroll.ReadValue().y;

        if (scrollValue > 0f)
        {
            // Scroll up
            currentWeaponIndex++;
            if (currentWeaponIndex >= ownedWeapons.Count)
                currentWeaponIndex = 0;

            EquipWeapon(currentWeaponIndex);
        }
        else if (scrollValue < 0f)
        {
            // Scroll down
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
                currentWeaponIndex = ownedWeapons.Count - 1;

            EquipWeapon(currentWeaponIndex);
        }
    }
}
