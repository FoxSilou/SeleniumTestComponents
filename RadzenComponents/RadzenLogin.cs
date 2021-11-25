namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenLogin : BaseElement
    {
        protected override By DefaultSelector => By.ClassName("login");
        protected RadzenTextBox UserName => GetChild<RadzenTextBox>(By.Name("Username"));
        protected RadzenTextBox Password => GetChild<RadzenTextBox>(By.Name("Password"));
        protected RadzenButton Login => GetChild<RadzenButton>();

        public void LogIn(string userName, string password)
        {
            UserName.WriteText(userName);
            Password.WriteText(password);
            Login.Click();
        }
    }
}