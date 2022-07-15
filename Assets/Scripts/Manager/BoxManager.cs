using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class BoxManager : MonoBehaviour
    {
        private RandomBoxFactory randBoxFactory;

        // Box Count
        public int minBox = 1;
        public int maxBox = 20;
        private int countBox;

        private ObjectPool boxPool = new ObjectPool();
        
        // using player and boxPrefab to generate from distance
        public Transform player;
        public BoxController boxPrefab;

        // Player and generate box distance
        public float distance = 1.5f;

        // Area for generating box
        public Transform[] walls;

        // Generate box 3 second after collide
        public float boxCooldown = 3.0f;
        private float timer;
        private int activeBox = 0;

        private void Start()
        {
            randBoxFactory = GetComponent<RandomBoxFactory>();
            countBox = Mathf.FloorToInt(Random.Range(minBox, maxBox));
            for (int i = 0; i < countBox; i++)
            {
                GenerateBox();
            }
        }

        private void Update()
        {
            // set timer to count 3s for generating box
            timer += Time.deltaTime;

            if (activeBox < maxBox && timer >= boxCooldown)
            {
                GenerateBox();
                timer = 0.0f;
            }
        }

        // generate method
        private void GenerateBox()
        {
            var newRandomBox = boxPool.CheckPool();
            if (newRandomBox == null) 
            {
                newRandomBox = randBoxFactory.Generate(boxPrefab.gameObject, transform);
                boxPool.AddToPool(newRandomBox);
            }

            Vector2 randomPos = GetRandomPosition();
            while(Vector2.Distance(randomPos, player.position) < distance)
            {
                randomPos = GetRandomPosition();
            }

            newRandomBox.transform.position = randomPos;
            newRandomBox.SetActive(true);

            newRandomBox.GetComponent<BoxController>().OnBoxDisabled += Respawn;
        }

        // Border for generating box
        private Vector2 GetRandomPosition()
        {
            // [left, right, down, up]
            float x = Random.Range(walls[0].position.x + 1, walls[1].position.x - 1);
            float y = Random.Range(walls[2].position.y + 1, walls[3].position.y - 1);
            return new Vector2(x, y);
        }

        private void Respawn()
        {
            activeBox -= 1;
            if (timer >= boxCooldown)
            {
                timer = 0.0f;
            }
        }
    }
}