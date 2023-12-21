using TechTalk.SpecFlow;

namespace The_IT_Depot_BDD_Tests.Hooks
{
    [Binding]
    public sealed class AfterHooks
    {
        [AfterFeature]
        public static void CleanUp()
        {
            BeforeHooks.driver?.Quit();
            
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            BeforeHooks.driver?.Navigate().GoToUrl("https://www.theitdepot.com/");
        }

        
    }
}