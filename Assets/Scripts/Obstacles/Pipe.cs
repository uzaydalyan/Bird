namespace Obstacles
{
    public class Pipe : Obstacle
    {
        private bool passed;

        // Update is called once per frame
        private void Update()
        {
            if (!passed && transform.position.x < characterPositionX)
            {
                IncreaseScore(1);
                passed = true;
            }

            if (transform.position.x < -10f)
            {
                passed = false;
                RemoveSelf();
            }
        }

        protected override void ObstacleOnStart()
        {
        }

        public override void SetType()
        {
            type = ObstacleType.Pipe;
        }
    }
}