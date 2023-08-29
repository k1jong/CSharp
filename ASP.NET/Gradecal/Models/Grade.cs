namespace Calculator.Models
{
    public class Grade
    {
        public GradeType Kor { get; set; }
        public GradeType Math { get; set; }
        public GradeType Eng { get; set; }
        public GradeType Sci { get; set; }
        public GradeType His { get; set; }
    }
    public enum GradeType
    {
        A=95, B=85, C=75, D=65 , A_Plus=100, B_Plus=90, C_Plus=80, D_plus=70
    }
}
