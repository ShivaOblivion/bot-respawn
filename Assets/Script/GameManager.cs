using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    [CanBeNull] public static GameManager Instance;
    public GameState State; 
    private GameObject Player;
    private Vector2 lastDeadPos;
    public float respawnTime=1.5f;
    private Vector2 PlayerSpawnPos;
    private bool CanPlayerSpawn;
    
    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
        transform.position = new Vector3(-500, -500, -500);

    }

   
  
    public IEnumerator SpawnPlayerTimer()
    {
        Player.transform.position = transform.position;
      yield return new WaitForSeconds(respawnTime);
        RespawnPlayer();
    }


    public void PlayerStarted(GameObject player , Vector2 playerSpawn)
    {
        
        Player = player;
        PlayerSpawnPos = playerSpawn;
    }
    private void RespawnPlayer()
    {
        Player.transform.position = PlayerSpawnPos; 
        var move = Player.GetComponent<PlayerMovement>();
            move.StartCoroutine(move.StartMoving());
    }

    public enum GameState
    {
        SelectLevel, 
        Victory, 
        Lose, 
        ReloadLevel,
        NewGame
    }
}
