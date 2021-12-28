using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerSpawner : MonoBehaviour
{
    //public int nbOfPlayers = 1;
    public Vector2 spawnAreaSize = new Vector2(20, 20);
    public Vector3 spawnAreaPosition = new Vector3();
    //public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //for (int x = 0; x < nbOfPlayers; x++)
        //{
        //    float newX = Random.Range(spawnAreaPosition.x - spawnAreaSize.x, spawnAreaPosition.x + spawnAreaSize.x);
        //    float newZ = Random.Range(spawnAreaPosition.z - spawnAreaSize.y, spawnAreaPosition.z + spawnAreaSize.y);
        //    Vector3 newPosition = new Vector3(newX, spawnAreaPosition.y, newZ);
        //    GameObject player = Instantiate(playerPrefab, newPosition, new Quaternion());
        //    Camera playerCamera = player.GetComponentInChildren<Camera>();
        //    Rect rect = playerCamera.rect;
        //    if (nbOfPlayers > 1)
        //    {
        //        rect.width = 0.5f;
        //        rect.x = Mathf.Floor((x % 2)) / (float)2;
        //    }
        //    if (nbOfPlayers > 2)
        //    {
        //        rect.height = 0.5f;
        //        rect.y = Mathf.Floor(x / (float)2)/2;
        //    }
        //    playerCamera.rect = rect;
        //}
    }

    public void onLocalPlayerJoined(PlayerInput input) {
        input.name = "Player " + (1 + input.playerIndex);
        float newX = Random.Range(spawnAreaPosition.x - spawnAreaSize.x, spawnAreaPosition.x + spawnAreaSize.x);
        float newZ = Random.Range(spawnAreaPosition.z - spawnAreaSize.y, spawnAreaPosition.z + spawnAreaSize.y);
        input.gameObject.transform.position = new Vector3(newX, spawnAreaPosition.y, newZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
