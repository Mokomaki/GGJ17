using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [System.Serializable]
    public class Spawnable
    {
        public GameObject prefab;
        public float time;
        public float spawnrate = 5;
        public Transform SpawnPos;
        public bool InUse = false;
    }

    public List<Spawnable> Spawnables = new List<Spawnable>();

    void Update()
    {
        foreach(var s in Spawnables)
        {
            if (s.InUse && Time.time > s.time && s.spawnrate > 0.1f)
            {
                s.time += s.spawnrate;
                Instantiate(s.prefab,s.SpawnPos.transform.position,s.SpawnPos.transform.rotation);
            }
        }
    }
}
