using FirstShop.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Security
{
    public class GoogleReCaptchaServices
    {
        private readonly IConfiguration _config;

    public GoogleReCaptchaServices(IConfiguration config)
    {
        _config = config;
    }

        public async Task<bool> VerifyRecaptchaToken(string token)
        {
            var secret = _config.GetSection("googleReCaptcha:SecretKey").Value;

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(token))
                return false;

            var url = $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={token}";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                        return false;

                    var responseString = await response.Content.ReadAsStringAsync();

                    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseString);

                    bool success = result.success ?? false;

                    if (result.score != null)
                    {
                        float? score = result.score;
                        return success && score.GetValueOrDefault() >= 0.5;
                    }

                    return success;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("reCAPTCHA error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
