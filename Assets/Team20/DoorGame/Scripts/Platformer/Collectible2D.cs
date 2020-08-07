using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixJam.Team20
    {
        namespace MatrixJam.Team20
{
    public class Collectible2D : MonoBehaviour
        {
            private enum CollectibleType
            {
                Coin,
                Door1,
                Type3
            }
            [SerializeField] private CollectibleType _collectibleType;


            private void OnTriggerEnter2D(Collider2D other)
            {
                Debug.Log("touched door");
                if (other.CompareTag("Tag0"))
                {
                    PlayerComponent player = other.GetComponent<PlayerComponent>();
                    if (_collectibleType == CollectibleType.Coin && player != null)
                    {
                        player.AddCoins(1);
                        Destroy(gameObject);
                    }

                }
            }


            private void OnTriggerStay2D(Collider2D other)
            {
                PlayerComponent player = other.GetComponent<PlayerComponent>();
                if (_collectibleType == CollectibleType.Door1 && player != null)
                {
                    if (Input.GetKey(KeyCode.E) && player.DoorKeyReady() && player.PlayerStands())
                    {
                        Debug.Log("Door Collected");
                        if (player.GetDoors() == 0)
                        {
                            player.SetDoors(1);
                            player.SetDoorsY(gameObject.transform.position.y);
                            player.CollectDoor(gameObject);
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}