using Microsoft.JSInterop;

namespace BlazorApplication1.Client.Services
{
    public class AntiforgeryService
    {
        private readonly IJSRuntime JSRuntime;

        public AntiforgeryService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }

        public string Token
        {
            get
            {
                return (JSRuntime as IJSInProcessRuntime).Invoke<string>("eval", "(decodeURIComponent(document.cookie).split(';').filter(s=>s.trim().startsWith('XSRF-TOKEN='))[0]||'').split('=')[1]||''");
            }
        }
    }
}
