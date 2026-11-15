using System;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    [SerializeField] private KitchenObjectSO plateKitchenPbjectSO;
    private float spawmPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int PlatesSpawnAmount;
    private int platesSpawnAmountMax = 4;

    private void Update()
    {
        spawmPlateTimer += Time.deltaTime;
        if (spawmPlateTimer > spawnPlateTimerMax)
        {
            spawmPlateTimer = 0f;
            if (PlatesSpawnAmount < platesSpawnAmountMax)
            {
                PlatesSpawnAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }    
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            // Player is empty handed
            if (PlatesSpawnAmount > 0)
            {
                // there is at least one plate here
                PlatesSpawnAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenPbjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
