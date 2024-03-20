using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MeteorZone : MonoBehaviour
{
    [SerializeField]
    private GameObject meteorAOE;
    [SerializeField]
    private Transform player;

    private Collider collider;
    [SerializeField]
    private float minDistance = 20f;
    [SerializeField]
    private float maxDistance = 30f;

    private List<GameObject> leftoverStrikes = new List<GameObject>();

    private Coroutine meteorCoroutine;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            meteorCoroutine = StartCoroutine(MeteorShower());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(meteorCoroutine);
            DestroyLeftoverMeteorStrikes();
        }
    }

    IEnumerator MeteorShower()
    {
        do
        {
            GameObject meteorStrike = Instantiate(meteorAOE, GetMeteorSpawnLocation(), Quaternion.identity);
            leftoverStrikes.Add(meteorStrike);
            StartCoroutine(DestroyMeteorStrike(meteorStrike));
            yield return new WaitForSeconds(1f);
        }
        while (true);
    }

    IEnumerator DestroyMeteorStrike(GameObject meteorStrike)
    {
        var particle = meteorAOE.GetComponent<ParticleSystem>();

        yield return new WaitForSeconds(4f);
        leftoverStrikes.Remove(meteorStrike);
        Destroy(meteorStrike);
    }

    private void DestroyLeftoverMeteorStrikes()
    {
        foreach(var meteorStrike in leftoverStrikes)
        {
            Destroy(meteorStrike);
        }
    }

    private Vector3 GetMeteorSpawnLocation()
    {
        float distance = Random.Range(minDistance, maxDistance);
        Vector3 foo = player.position + player.forward * distance;
        float y = -14f;

        if(collider.bounds.Contains(foo) == false)
        {
            return player.position;
        }


        return foo;
    }
}
