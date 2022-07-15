using UnityEngine;

namespace Command
{
    public class CursorSystem : Command
    {
        private CircleController player;
        private Vector2 startPos;
        private Vector2 targetPos;

        public CursorSystem(CircleController circle, Vector2 targetPosition)
        {
            player = circle;
            targetPos = targetPosition;
        }

        public override void Init()
        {
            startPos = player.transform.position;
            player.CursorMove(targetPos);
        }
    }
}