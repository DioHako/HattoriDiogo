using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Collectables> collectablePrefab;

    private int randomItem;

    private void OnEnable()
    {
        randomItem = Random.Range(0, collectablePrefab.Count);

        Collectables instance = Instantiate(collectablePrefab[randomItem], transform.position, transform.rotation);
    }
}
