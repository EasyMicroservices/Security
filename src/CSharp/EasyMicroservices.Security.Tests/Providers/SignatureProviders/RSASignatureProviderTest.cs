using EasyMicroservices.Security.Providers.SignatureProviders;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Security.Tests.Providers.SignatureProviders
{
    public class RSASignatureProviderTest : BaseSignatureProviderTest
    {
        static string privateKey = "<RSAKeyValue><Modulus>rvH+oW61xbXYQvg+GInL5B3KPamNuxYWke/UaOxQAsAeuvtJ+5AxfqKIkh1UY9SwAhb1r13wBG8PhM6ARqKNt9XueZucZTCvtGc6XNhAZlOwsNl1fKneHQKobriKJfkF3eMPKY2Dz3Ws1SEUQ5SyAF6hJrarB1WG08eMuqILGKB5Ec/VbO/sN5qZ0uREicbDEvJAr7b+9Nn/LGQ4hH8Ej4RLN/xydwK9jdeAQz9qjE5lx5yJE5oP0Czvkr10u+Yc4v/s17gJFleCw7A3uEep6X02ENYdu33mv2z8MkijyxltCfVtAUyTXhK3Q/H+v6eWkpaPxdQuXX+2vUcYG4qhNw==</Modulus><Exponent>AQAB</Exponent><P>2I4nGsQXfwfs+vQ78dKRvpc9PbafqBUGMzeI250hyb+wuaz7ihfZmRe12apHzATlsI47jInX7wntBAQzBh82o3HSJfKKuGSSB3ATrFjpy2D/2PcpYaw5+ex3Tng1Wyy9nRXSES1ju4e10TGg950yEJjL0wM6h/stCHVwGnABLG8=</P><Q>zs+XkxcmLLy60TThGEsfNFVsvcafRcyplL089Ann01ZKElFkeXD4Rs4isAd+GTycgIbzQIaelOLgyCY3x9okAcP/y7W8uZUZ7TixXFYO6V8eGErqqlnBXIPFezBiNksAgPpRnJj2ZvdB3QOvVxuZL9S2OXkDbHZfoVjZvvijS7k=</Q><DP>OeUfPT+pjHOg/qKnGAqUnmCupb4aRwR/6NdzBkunCdnutGUzxoKD0TMOkge9NCUnByGvd+4uRaDgtc8tmPhlUiMO7MhAH/X7OHPVPqFyt8XSAL5rWMqDoXZ/mwH2Oc7nToTT6XW6ERvCFxBumWR0Sw2eiGZ3kn0rV/SVqOvC1I8=</DP><DQ>HVDcAaPEa48NRF6kkdcEQ1zgnz4qkbBjUYxJuaY10IVo1pPnFDfpWdAapq1JOLaY0LdQgBMVI7HNf1G7kn7fn8hy2COY7w2tsSzaJ2ajkn1DPNpRzXgPqtebBM1k/qE/HwlczD/6nbnrAjNlhYmJ+3fBpP/8dkGJaMu5ghKowzE=</DQ><InverseQ>F5O2glKPKxY7gsHgG0Ti4/8Pm1sGYN0FIOHM6aU3UGALtj67zt5ZesxX5NNMZJVZKom8rUUFiabiSXjDKIv1rv7DMUEcZCr3mUtUlidweI5LoJ0I7QdqRbFsdPbEumVGeCPBM//lMZ1z0tnn8ZO0bV3KfiiXo+ElnmTrqp3rPxw=</InverseQ><D>P5R/YBgmQ8aE5EHn/28FBNC20ZYvhlDOvxcUcVWA9p7wDDCLgLu04Tscu02hf+6qUPgbLjLLqjDayP9rq0AklS1Q0C13t2bsVHo3wcpuDUJZMsy1YCs0KALxR9wViRtpwGxm9EkUIG+58nNlM/J0hqHdm35DxhSVPZ6GTMXbloUR3YlmghLwTVZk3FElsGZ1EZSuYVs1iWuMSdBueB3VD1yjOkLaJgLoa8fDwLcTdE2m0ToEXHesvWO0MJPpO0cIpY3SfjlDEg5fRPU4UP+7JeAT17i8SuU6oSz5EQWjjVvf5fcOstOtpcfjkMe+e5/URwGffTz1rATXLHwpL0dqoQ==</D></RSAKeyValue>";

        static string publicKey = "<RSAKeyValue><Exponent>AQAB</Exponent><Modulus>rvH+oW61xbXYQvg+GInL5B3KPamNuxYWke/UaOxQAsAeuvtJ+5AxfqKIkh1UY9SwAhb1r13wBG8PhM6ARqKNt9XueZucZTCvtGc6XNhAZlOwsNl1fKneHQKobriKJfkF3eMPKY2Dz3Ws1SEUQ5SyAF6hJrarB1WG08eMuqILGKB5Ec/VbO/sN5qZ0uREicbDEvJAr7b+9Nn/LGQ4hH8Ej4RLN/xydwK9jdeAQz9qjE5lx5yJE5oP0Czvkr10u+Yc4v/s17gJFleCw7A3uEep6X02ENYdu33mv2z8MkijyxltCfVtAUyTXhK3Q/H+v6eWkpaPxdQuXX+2vUcYG4qhNw==</Modulus></RSAKeyValue>";

        public RSASignatureProviderTest() : base(new RSASignatureProvider(publicKey, privateKey))
        {
        }
#if (NET452)
        public override void SignatureAlgorithmSignAndValidateDataFalse(string dataString)
        {
        }

        public override void SignatureAlgorithmSignAndValidateDataSuccess(string dataString)
        {
        }

        public override Task SignatureAlgorithmSignAndValidateDataSuccessStream(string dataString)
        {
            return TaskHelper.GetCompletedTask();
        }
#endif
    }
}
