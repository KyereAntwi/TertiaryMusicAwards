using System.Net;
using TertiaryMusicAwardsMobile.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TertiaryMusicAwardsMobile.Droid.AndroidServices.IPAdressManager))]
namespace TertiaryMusicAwardsMobile.Droid.AndroidServices
{
    public class IPAdressManager : IIPAddressManager
    {
        public string GetIPAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }

        }
    }
}