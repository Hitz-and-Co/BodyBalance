namespace BodyBalance_Backend.Models
{
    public class UserData
    {
        public double Height { get; set; } // in cm
        public double Weight { get; set; } // in kg
        public int Age { get; set; }
        public string Gender { get; set; } // "male" or "female"
        public string ActivityLevel { get; set; } // "low", "moderate", "high"
    }
}
