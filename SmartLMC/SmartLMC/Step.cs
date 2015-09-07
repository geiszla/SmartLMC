namespace SmartLMC.SmartLMC
{
    public class Step
    {
        public int LineNumber;

        public int[] MemoryChange;
        public int Accumulator;
        public string Output;

        public Step(int lineNumber)
        {
            LineNumber = lineNumber;
        }
    }
}
