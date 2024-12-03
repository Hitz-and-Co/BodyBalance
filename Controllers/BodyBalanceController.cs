using Microsoft.AspNetCore.Mvc;
using BodyBalance_Backend.Models;

namespace BodyBalance_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyBalanceController : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] UserData userData)
        {
            if (userData == null)
            {
                return BadRequest("Invalid user data.");
            }

            double bmi = CalculateBMI(userData.Weight, userData.Height);
            double tdee = CalculateTDEE(userData);

            string bmiFeedback = bmi switch
            {
                < 18.5 => "Ihr BMI liegt im Bereich des Untergewichts. Es wird empfohlen, einen Arzt oder Ernährungsberater zu konsultieren, um eine gesunde Gewichtszunahme zu erreichen.",
                >= 18.5 and <= 24.9 => "Ihr BMI liegt im Normalgewichtsbereich. Gut gemacht! Halten Sie Ihre gesunde Lebensweise aufrecht.",
                >= 25 and <= 29.9 => "Ihr BMI liegt im Bereich des Übergewichts. Regelmäßige körperliche Aktivität und eine ausgewogene Ernährung können hilfreich sein, um das Gewicht zu regulieren.",
                >= 30 => "Ihr BMI liegt im Bereich der Adipositas. Es wird empfohlen, eine professionelle Beratung für Ernährung und Bewegung zu erwägen.",
                _ => "BMI-Wert nicht erkannt."
            };

            string tdeeFeedback = userData.ActivityLevel.ToLower() switch
            {
                "low" => "Ihr Aktivitätslevel wird als 'niedrig' eingestuft. Um Ihre Fitness und Gesundheit zu verbessern, könnte es hilfreich sein, regelmäßig leichte körperliche Aktivitäten durchzuführen.",
                "moderate" => "Ihr Aktivitätslevel wird als 'moderat' eingestuft. Das ist eine gute Balance. Halten Sie Ihre Aktivität aufrecht, um Ihre Gesundheit zu fördern.",
                "high" => "Ihr Aktivitätslevel wird als 'hoch' eingestuft. Sie haben eine hohe körperliche Aktivität, was sehr gut für die allgemeine Fitness ist. Achten Sie darauf, genügend Kalorien und Nährstoffe aufzunehmen, um Ihren Bedarf zu decken.",
                _ => "Aktivitätslevel nicht erkannt."
            };

            return Ok(new
            {
                BMI = bmi,
                TDEE = tdee,
                BMI_Feedback = bmiFeedback,
                TDEE_Feedback = tdeeFeedback
            });
        }

        private double CalculateBMI(double weight, double height)
        {
            return weight / Math.Pow(height / 100, 2);
        }

        private double CalculateTDEE(UserData userData)
        {
            double bmr = userData.Gender.ToLower() == "male"
                ? 88.362 + (13.397 * userData.Weight) + (4.799 * userData.Height) - (5.677 * userData.Age)
                : 447.593 + (9.247 * userData.Weight) + (3.098 * userData.Height) - (4.330 * userData.Age);

            double activityMultiplier = userData.ActivityLevel.ToLower() switch
            {
                "low" => 1.2,
                "moderate" => 1.55,
                "high" => 1.725,
                _ => 1.2
            };

            return bmr * activityMultiplier;
        }
    }
}
