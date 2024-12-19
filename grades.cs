namespace Gradebook_project
{
    public class GradeRange
    {
        private int minValue;
        private int maxValue;
        public GradeRange(Grade LetterGrade, int min, int max)
        {
            grade = LetterGrade;
            MinValue = min;
            MaxValue = max;
        }

        public Grade grade { get; set; }
        public int MinValue { get; set; }
        public int MaxValue {  get; set; }

        public bool IsInRange(int value)
        {
            return value >= MinValue && value <= MaxValue;
        }
    }
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
}
