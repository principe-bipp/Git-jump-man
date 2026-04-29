using NUnit.Framework;
using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;
public class SpawManeger : MonoBehaviour
{
    [Header("Configuração de Spawn")]
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float repeatRate = 1.5f;

    [Header("Prefabricados Obstaculos")]
    [SerializeField] private List<GameObject> obstaclePrefab;

    [Header("Spawn Referencia")]
    [SerializeField] private Transform spawnPoint;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }
    private void Update()
    {
        if (PlayerController.instance.gameOver)
        {

            CancelInvoke(nameof(SpawnObstacle));
        }
    }
    void SpawnObstacle() 
    {
        if (obstaclePrefab.Count != 0 && spawnPoint != null)
        {
            //Aleatorio para escolher um prefabricado da lista
            int index = Random.Range(0, obstaclePrefab.Count);
            GameObject prefabEscolhido = obstaclePrefab[index];

            //Spawnar
            Instantiate(prefabEscolhido,
                spawnPoint.position, spawnPoint.rotation);


        }
        else 
        {
            Debug.Log("Não foi possivel spawnar");
        }
    }

}



