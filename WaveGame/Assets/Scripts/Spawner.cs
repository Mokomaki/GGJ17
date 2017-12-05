using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [System.Serializable]
    public class Spawnable
    {
        public GameObject prefab;
        [HideInInspector]
        public float time;
        public float FirstRhythm;
        public float Strike;
        [Range(0.125f,8f)]
        public float RepeatMultiplier = 1;
        public bool InUse = false;
    }

    public Transform SpawnPos;

    public float RhythmLength = 4;

    public bool overWriteFirstRhythm = false;

    public List<Spawnable> Spawnables = new List<Spawnable>();


    void Start()
    {
        transform.position = SpawnPos.position;
        float time = Time.time;
        foreach (var s in Spawnables)
        {
            s.time = time + (overWriteFirstRhythm?0: s.FirstRhythm * RhythmLength) + RhythmLength * s.Strike / 4f;
        }
    }

    void Update()
    {
        foreach(var s in Spawnables)
        {
            if (s.InUse && Time.time > s.time && RhythmLength > 0.1f)
            {
                s.time += RhythmLength/s.RepeatMultiplier;
                var go = Instantiate(s.prefab);

                go.transform.parent = transform;
                go.transform.localPosition = s.prefab.transform.localPosition;
                go.transform.localRotation = s.prefab.transform.localRotation;

            }
        }
    }
}
