namespace SmartLMC.SmartLMC
{
    public class Line
    {
        public string Text;
        public string Name;
        public int Instruction;
        public MemoryAllocation Target;
        public int Value;

        public Line(string source)
        {
            this.Text = source;
        }
    }
}
