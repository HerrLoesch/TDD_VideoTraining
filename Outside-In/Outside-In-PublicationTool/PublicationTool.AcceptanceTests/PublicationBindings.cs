using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Gherkin.Ast;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Objects;
using TechTalk.SpecFlow;

namespace PublicationTool.AcceptanceTests
{
    [Binding]
    public class PublicationBindings
    {
        private ScenarioContext scenarioContext;

        public PublicationBindings(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When(@"the publication is stored")]
        public async Task WhenThePublicationIsStored()
        {
            var publication = scenarioContext.Get<Publication>();
            var serializedPublication = JsonSerializer.Serialize(publication);
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:56985/") };
            var publishedContent = new StringContent(serializedPublication, Encoding.UTF8, "application /json");

            var resultMessage = await httpClient.PostAsync("Publication", publishedContent);
            var resultContent = await resultMessage.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<Result>(resultContent);

            scenarioContext.Set(resultMessage);
            scenarioContext.Set(result);
        }

        [Given(@"is a publication with title ""(.*)"" published on ""(.*)""")]
        public void GivenIsAPublicationWithTitlePublishedOn(string title, string date)
        {
            var publication = CreatePublication(title, date);
            scenarioContext.Set(publication);
        }

        private static Publication CreatePublication(string title, string date)
        {
            var publication = new Publication();
            publication.Title = title;
            publication.Date = DateTime.Parse(date);
            return publication;
        }
    }
}
