using System.Collections;
using System.Reflection;
using teamcity_testing_framework.main.com.example.teamcity.api.Attributes;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using RandomAttribute = teamcity_testing_framework.main.com.example.teamcity.api.Attributes.RandomAttribute;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Generators
{
    public class TestDataGenerator
    {
        private TestDataGenerator() { }

        public static T Generate<T>(List<BaseModel> generatedModels, params object[] parameters) where T : BaseModel, new()
        {
            try
            {
                T instance = new T();
                var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (var property in properties)
                {
                    // Check if the field is marked as Optional
                    if (!property.IsDefined(typeof(OptionalAttribute), false))
                    {
                        var generatedClass = generatedModels.FirstOrDefault(m => m.GetType() == property.PropertyType);

                        // If the field is marked as Parameterizable and parameters are provided
                        if (property.IsDefined(typeof(ParameterizableAttribute), false) && parameters.Length > 0)
                        {
                            property.SetValue(instance, parameters[0]);
                            parameters = parameters.Skip(1).ToArray();
                        }
                        // If the field is marked as Random and it's a string
                        else if (property.IsDefined(typeof(RandomAttribute), false) && property.PropertyType == typeof(string))
                        {
                            property.SetValue(instance, RandomData.GetString());
                        }
                        // If the field is a subclass of BaseModel
                        else if (typeof(BaseModel).IsAssignableFrom(property.PropertyType))
                        {
                            object[] finalParameters = parameters;
                            property.SetValue(instance, generatedClass ?? Generate(property.PropertyType, new List<BaseModel>(), finalParameters));
                        }
                        // If the field is a List<BaseModel>
                        else if (typeof(IList).IsAssignableFrom(property.PropertyType))
                        {
                            var listType = property.PropertyType.GetGenericArguments()[0];
                            if (typeof(BaseModel).IsAssignableFrom(listType))
                            {
                                object[] finalParameters = parameters;

                                // workaround to create list with certain type inherited from BaseModel
                                var issue = Generate(listType, new List<BaseModel>(), finalParameters);
                                Type listTypeG = typeof(List<>).MakeGenericType(issue.GetType());
                                IList listInstance = (IList)Activator.CreateInstance(listTypeG);
                                listInstance.Add(issue);

                                property.SetValue(instance, generatedClass != null ? new List<BaseModel> { generatedClass } : listInstance);
                            }
                        }
                    }
                }
                return instance;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Cannot generate test data", e);
            }
        }

        // Generate method to generate one entity (with empty generatedModels parameter)
        public static T Generate<T>(params object[] parameters) where T : BaseModel, new()
        {
            return Generate<T>(new List<BaseModel>(), parameters);
        }

        // Helper method to generate BaseModel object (for recursive calls)
        private static BaseModel Generate(Type modelType, List<BaseModel> generatedModels, object[] parameters)
        {
            var method = typeof(TestDataGenerator).GetMethod(nameof(Generate), BindingFlags.Static | BindingFlags.Public,
                null,
                new[] { typeof(List<BaseModel>), typeof(object[]) },
                null);
            var generic = method.MakeGenericMethod(modelType);
            return (BaseModel)generic.Invoke(null, new object[] { generatedModels, parameters });
        }
    }
}
