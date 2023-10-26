using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShowroomService.Enums;
using ShowroomService.ExpectedResponse;
using ShowroomService.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ShowroomService.Helper.HttpClientHelper;

namespace ShowroomService.StepDefinitions
{
    [Binding]
    class CarApiStepDefs
    {
        public string requestType;
        public ApiResponse apiResponse = new ApiResponse();
        public HttpClientHelper clientHelper = new HttpClientHelper();
        public int actualStatusCode;
        public int responseTime;



        [Given(@"the ""([^""]*)"" car API is available")]
        public void GivenTheCarAPIIsAvailable(string httpVerb)
        {
            requestType = httpVerb;
        }

        [When(@"I request GET (.*)")]
        public void WhenIRequestGETSaloon(string carType)
        {
            apiResponse = clientHelper.getApiReponse(requestType, carType);
        }


        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            actualStatusCode = apiResponse.statusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode, "Expected and Actual Status Codes do not match");
        }

        [Then(@"the response should contain cars of type (.*)")]
        public void ThenTheResponseShouldContainCarsOfTypeSaloon(string carType)
        {
            string expectedJsonString = string.Empty;
            if (carType.ToLower().Equals(EnumHelper.GetEnumDescription(CarTypes.Saloon)))
            {
                expectedJsonString = File.ReadAllText(FileSystemHelper.TestDataBaseFolder+ "\\Get_Saloon_Expected.json");
            }
            else if(carType.ToLower().Equals(EnumHelper.GetEnumDescription(CarTypes.SUV)))
            {
                expectedJsonString = File.ReadAllText(FileSystemHelper.TestDataBaseFolder + "\\Get_SUV_Expected.json");
            }
            else if (carType.ToLower().Equals(EnumHelper.GetEnumDescription(CarTypes.Hatchback)))
            {
                expectedJsonString = File.ReadAllText(FileSystemHelper.TestDataBaseFolder + "\\Get_HatchBack_Expected.json");
            }

            JToken expected = JToken.Parse(@expectedJsonString);
            JToken actual = JToken.Parse(apiResponse.jsonResponse);

            actual.Should().BeEquivalentTo(expected);
        }

        [Then(@"the response should contain data for invalid (.*)")]
        public void ThenTheResponseShouldContainDataForInvalidCarType(string carType)
        {
            var result = JsonConvert.DeserializeObject<GetCarTypeInvalidResponse>(apiResponse.jsonResponse);
            if (!carType.Equals(string.Empty))
            {
                Assert.AreEqual("Not Found", result.title, "Expected title of \"Not Found\" is not found in the response");
            }
        }

        [Then(@"The Response Time should be less than (.*) milliseconds")]
        public void ThenTheResponseTimeShouldBeLessThanMilliseconds(int ResponseTimeInMilliseconds)
        {
            if (apiResponse.responseTimeInMilliseconds > ResponseTimeInMilliseconds)
                Assert.Fail($"Response time greater than {ResponseTimeInMilliseconds}");
        }



    }
}
