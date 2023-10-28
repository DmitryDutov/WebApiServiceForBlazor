namespace WebApiServiceForBlazor.Services
{
    public class MultiplicationTableService
    {
        public MultiplicationTableService()
        {

        }

        public Task Generate()
        {
            string first = Random.Shared.Next(1, 9).ToString();
            string second = Random.Shared.Next(1, 9).ToString();

            return Task.FromResult($"{first} * {second}");
        }
    }
}
