namespace RentThatBike.Tests
{
    public abstract class TestsBase
    {
        public const string BaseUrl = "http://localhost:61804/";

        static TestsBase()
        {
            var appHostTest = new AppHostTest();
            appHostTest.Init();
            appHostTest.Start(BaseUrl);
        }
    }
}