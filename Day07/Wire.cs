namespace Day07
{
    public class Wire
    {
        public string Instruction { get; set; }
        public ushort Signal { get; set; }
        public bool IsSolved = false;

        public Wire(string instruction)
        {
            Instruction = instruction;
        }

        public void SetSignal(ushort signal)
        {
            Signal = signal;
            IsSolved = true;
        }
    }
}
