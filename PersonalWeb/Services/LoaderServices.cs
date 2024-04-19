namespace PersonalWeb.Services
{
    public interface ILoaderServices
    {
        int GetNumber();
    }

    public class LoaderServices : ILoaderServices
    {
        public int GetNumber() { return 1; }
    }
}
