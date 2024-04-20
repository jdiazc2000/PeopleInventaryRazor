namespace PersonalWeb.Services
{
    public interface ILoaderServices
    {
        Task<string> GetLoaderComponent(string text);
    }

    public class LoaderServices : ILoaderServices
    {

        public Task<string> GetLoaderComponent(string text)
        {
            string html = @"<div class=""overlay"">
                            <div class=""overlay__wrapper"">
                                <div class=""overlay__spinner"">
                                    <div class=""loading"">
                                        <div class=""spinner-border text-light"" role=""status"">
                                            <span class=""sr-only""></span>
                                        </div>
                                        <p style=""color: white;"">" + text + @"</p>
                                    </div>
                                </div>
                            </div>
                        </div>";

            return Task.FromResult(html);
        }
    }
}
