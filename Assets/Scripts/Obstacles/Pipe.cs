using System;
using DefaultNamespace;

namespace Obstacles
{
    public class Pipe : Obstacle
    {
        private Boolean passed;
        // Update is called once per frame
        void Update()
        {
            if (!passed && transform.position.x < characterPositionX)
            {
                IncreaseScore(1);
                passed = true;
            }
            if (transform.position.x < -10f)
            {
                Destroy(gameObject);
            }
        }
    
    }
}