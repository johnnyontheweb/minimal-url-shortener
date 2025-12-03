namespace minimal_url_shortener.Shared.Utils;

public class UrlExtensions
{
    public static string GetAppUrl(HttpRequest request)
    {
        var uriBuilder = new UriBuilder(request.Scheme, 
            request.Host.Host, 
            request.Host.Port ?? -1);
        if (uriBuilder.Uri.IsDefaultPort)
        {
            uriBuilder.Port = -1;
        }
        var baseUri = uriBuilder.Uri.AbsoluteUri;
        
        if (!string.IsNullOrEmpty(request.PathBase))
        {
            baseUri = baseUri.TrimEnd('/') + request.PathBase + '/';
        }
        
        return baseUri;
    }
}