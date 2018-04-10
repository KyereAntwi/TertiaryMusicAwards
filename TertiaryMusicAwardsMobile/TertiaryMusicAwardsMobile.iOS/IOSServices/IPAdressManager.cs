using System.Net.NetworkInformation;
using System.Net.Sockets;
using TertiaryMusicAwardsMobile.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TertiaryMusicAwardsMobile.iOS.IOSServices.IPAdressManager))]
namespace TertiaryMusicAwardsMobile.iOS.IOSServices
{
    public class IPAdressManager : IIPAddressManager
    {
        public string GetIPAddress()
        {
            string ipAddress = "";

            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress = addrInfo.Address.ToString();

                        }
                    }
                }
            }

            return ipAddress;

        }
    }
}