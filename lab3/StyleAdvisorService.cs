using System;

namespace OPI_Lb3.Services
{
    public class StyleAdvisorService
    {
        public string AnalyzeBodyShape(double bust, double waist, double hips)
        {
            if (bust <= 0 || waist <= 0 || hips <= 0)
                throw new ArgumentException("Усі параметри мають бути більшими за нуль.");

            if (bust > 300 || waist > 300 || hips > 300)
                throw new ArgumentOutOfRangeException("Параметри перевищують фізіологічні норми.");

            double bustWaistRatio = bust / waist;
            double hipsWaistRatio = hips / waist;

            if (bustWaistRatio >= 1.25 && hipsWaistRatio >= 1.25)
                return "Пісочний годинник";
            if (hips > bust * 1.1)
                return "Груша";
            if (bust > hips * 1.1)
                return "Перевернутий трикутник";

            return "Прямокутник";
        }

        public bool ValidateUserAccess(int age, bool hasGdprConsent)
        {
            if (age < 0 || age > 120)
                throw new ArgumentOutOfRangeException(nameof(age), "Некоректний вік.");

            if (!hasGdprConsent)
                return false;

            if (age >= 16)
                return true;

            return false;
        }

        public int CalculateRemainingGenerations(bool isPremium, int[] pastGenerationsPerDay)
        {
            if (pastGenerationsPerDay == null)
                throw new ArgumentNullException(nameof(pastGenerationsPerDay));

            if (isPremium)
                return 999;

            int totalUsed = 0;
            foreach (var used in pastGenerationsPerDay)
            {
                if (used < 0) throw new ArgumentException("Кількість не може бути від'ємною.");
                totalUsed += used;
            }

            int freeLimit = 5;
            return Math.Max(0, freeLimit - totalUsed);
        }
    }
}