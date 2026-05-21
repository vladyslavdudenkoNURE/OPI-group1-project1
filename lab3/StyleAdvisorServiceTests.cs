using NUnit.Framework;
using OPI_Lb3;
using OPI_Lb3.Services;
using System;

namespace OPI_Lb3.Tests
{
    [TestFixture]
    public class StyleAdvisorServiceTests
    {
        private StyleAdvisorService _service;

        [SetUp]
        public void Setup()
        {
            _service = new StyleAdvisorService();
        }

        [Test]
        public void ValidateUserAccess_Age16WithConsent_ReturnsTrue()
        {
            int age = 16;
            bool consent = true;
            bool result = _service.ValidateUserAccess(age, consent);

            // Сучасний синтаксис NUnit 4
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateUserAccess_Age15WithConsent_ReturnsFalse()
        {
            int age = 15;
            bool consent = true;
            bool result = _service.ValidateUserAccess(age, consent);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUserAccess_NegativeAge_ThrowsArgumentOutOfRangeException()
        {
            int age = -1;
            bool consent = true;

            Assert.Throws<ArgumentOutOfRangeException>(() => _service.ValidateUserAccess(age, consent));
        }

        [Test]
        public void AnalyzeBodyShape_ClassicHourglass_ReturnsHourglass()
        {
            double bust = 90, waist = 60, hips = 90;
            string result = _service.AnalyzeBodyShape(bust, waist, hips);

            Assert.That(result, Is.EqualTo("Пісочний годинник"));
        }

        [Test]
        public void AnalyzeBodyShape_ZeroBust_ThrowsArgumentException()
        {
            double bust = 0, waist = 60, hips = 90;

            Assert.Throws<ArgumentException>(() => _service.AnalyzeBodyShape(bust, waist, hips));
        }
        [Test]
        public void ValidateUserAccess_Age120WithConsent_ReturnsTrue()
        {
            int age = 120;
            bool result = _service.ValidateUserAccess(age, true);
            Assert.That(result, Is.True);
        }

        [Test]
        public void AnalyzeBodyShape_PearShape_ReturnsPear()
        {
            double bust = 80, waist = 60, hips = 95;
            string result = _service.AnalyzeBodyShape(bust, waist, hips);
            Assert.That(result, Is.EqualTo("Груша"));
        }

        [Test]
        public void AnalyzeBodyShape_Rectangle_ReturnsRectangle()
        {
            double bust = 85, waist = 80, hips = 85;
            string result = _service.AnalyzeBodyShape(bust, waist, hips);
            Assert.That(result, Is.EqualTo("Прямокутник"));
        }

        [Test]
        public void CalculateRemainingGenerations_PremiumUser_Returns999()
        {
            int[] past = new int[] { 5, 10 };
            int result = _service.CalculateRemainingGenerations(true, past);
            Assert.That(result, Is.EqualTo(999));
        }

        [Test]
        public void CalculateRemainingGenerations_StandardUserUsed2_Returns3()
        {
            int[] past = new int[] { 1, 1 };
            int result = _service.CalculateRemainingGenerations(false, past);
            Assert.That(result, Is.EqualTo(3));
        }
    }

}