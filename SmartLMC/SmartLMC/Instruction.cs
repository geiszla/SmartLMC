namespace SmartLMC.SmartLMC
{
    public class Instruction
    {
        public static int[] Codes = new int[11] { 101, 201, 301, 501, 601, 701, 801, 901, 902, 0, 0 };
        public static string[] Instructions = new string[11] { "ADD", "SUB", "STA", "LDA", "BRA", "BRZ", "BRP", "INP", "OUT", "HLT", "DAT" };
        public static bool[] TargetRequirements = new bool[11] { true, true, true, true, true, true, true, false, false, false, false };
        public static bool[] AccumulatorChange = new bool[11] { true, true, false, true, false, false, false, true, false, false, false };
    }
}
