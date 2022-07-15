using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class OldBoxManager : MonoBehaviour
    {
        private OldRandomBoxFactory randBoxFactory;

        // Box Count
        public int minBoxes = 1;
        public int maxBoxes = 20;
        public int countBoxes;

        // using player and boxPrefab to generate from distance
        public Transform player;
        public GameObject boxPrefab;

        public bool interact = true;

        // dipake biar nanti pas generate box ga kena player
        public float distance = 1.5f;

        // Area for generating box
        public Transform[] walls;

        private void Start()
        {
            randBoxFactory = GetComponent<OldRandomBoxFactory>();
            countBoxes = Mathf.FloorToInt(Random.Range(minBoxes, maxBoxes));
            for (int i = 0; i < countBoxes; i++)
            {
                GenerateBox();
            }
        }

        // generate method
        private void GenerateBox()
        {
            Vector2 randomPos = GetRandomPosition();
            while (Vector2.Distance(randomPos, player.position) < distance)
            {
                randomPos = GetRandomPosition();
            }

            randBoxFactory.Generate(boxPrefab, randomPos, transform);
        }

        // pembates
        private Vector2 GetRandomPosition()
        {
            // [left, right, down, up]
            float x = Random.Range(walls[0].position.x + 1, walls[1].position.x - 1);
            float y = Random.Range(walls[2].position.y + 1, walls[3].position.y - 1);
            return new Vector2(x, y);
        }
    }
}
