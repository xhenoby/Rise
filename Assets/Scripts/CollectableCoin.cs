using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<Player>().GrabCoin();
        Destroy(gameObject); // TODO: some effect?
    }
}
