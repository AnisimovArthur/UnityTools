﻿using UnityEngine;

namespace UnityTools
{
    [System.Serializable]
    public struct PreloadedPrefab
    {
        public GameObject Prefab { get => prefab; }
        public int Count { get => count; }

#pragma warning disable 0649
        [SerializeField] private GameObject prefab;
        [SerializeField] private int count;
#pragma warning restore 0649

        public PreloadedPrefab(GameObject prefab, int count)
        {
            this.prefab = prefab;
            this.count = count;
        }
    }
}
