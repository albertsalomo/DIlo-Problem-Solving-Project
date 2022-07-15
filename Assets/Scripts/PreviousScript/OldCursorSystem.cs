using UnityEngine;

namespace Command
{
    public class OldCursorSystem : Command
    {
        private OldCircleController player;
        private Vector2 startPos;
        private Vector2 targetPos;

        public OldCursorSystem(OldCircleController circle, Vector2 targetPosition)
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