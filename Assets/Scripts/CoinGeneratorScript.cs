using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorScript : MonoBehaviour
{

    public GameObject coinReference;
    public Transform player;
    public int numberOfCoinsToCreate = 10;

    int currentPosition = 0;
    public int offsetX = 2;

    // Start is called before the first frame update
    void Start()
    {
        CreateCoinsAutomatically();
    }

    void CreateCoinsAutomatically()
    {
        for(int i=0; i<numberOfCoinsToCreate; i++)
        {
            currentPosition += offsetX;
            int yOffset = 0;
            if(currentPosition%4 == 0)
            {
                yOffset = offsetX;
            }
            Instantiate(coinReference, new Vector3(player.position.x + currentPosition, player.position.y + yOffset, player.position.z), Quaternion.identity);
        }
    }

}
