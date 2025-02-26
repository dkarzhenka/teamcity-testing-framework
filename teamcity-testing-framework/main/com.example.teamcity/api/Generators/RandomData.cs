using Bogus;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Generators
{
    public sealed class RandomData
    {
        private static readonly string _testPrefix = "test_";
        private static readonly int _maxLength = 10;

        public static string GetString()
        {
            var faker = new Faker();
            return $"{_testPrefix}{faker.Random.String2(_maxLength)}";
        }

        public static string GetString(int length)
        {
            var faker = new Faker();
            return $"{_testPrefix}{faker.Random.String2(Math.Max(length - _testPrefix.Length, _maxLength))}";
        }
    }
}
