namespace Day14
{
    public class Reindeer
    {

        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int FlyDuration { get; private set; }
        public int FlyingSecondsRemaining { get; private set; }
        public int DistanceTravelled { get; private set; }
        public int RestDuration { get; private set; }
        public int RestingSecondsRemaining { get; private set; }
        public bool IsResting => RestingSecondsRemaining > 0;
        public bool IsFlying => FlyingSecondsRemaining > 0;
        public int Points { get; set; }

        public Reindeer(string name, int speed, int flyDuration, int restDuration)
        {
            Name = name;
            Speed = speed;
            FlyDuration = flyDuration;
            RestDuration = restDuration;
            FlyingSecondsRemaining = flyDuration;
        }

        public void Tick()
        {
            if (IsResting)
            {
                RestingSecondsRemaining--;

                if (RestingSecondsRemaining == 0) FlyingSecondsRemaining = FlyDuration;

                return;
            }

            if (IsFlying)
            {
                FlyingSecondsRemaining--;
                DistanceTravelled += Speed;

                if (FlyingSecondsRemaining == 0) RestingSecondsRemaining = RestDuration;
            }
        }
    }
}
