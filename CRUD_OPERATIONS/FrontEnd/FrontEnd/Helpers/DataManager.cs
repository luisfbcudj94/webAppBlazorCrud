using System.Text.RegularExpressions;

namespace FrontEnd.Helpers
{
    public static class DataManager
    {
        public static string BuildErrorMessageHtml(List<string> missingFields)
        {
            var errorMessageHtml = "<p>You must fill out the following fields:</p><div>";

            foreach (var field in missingFields)
            {
                errorMessageHtml += $"<p><b style='color: red;'>{field}</b></p>";
            }

            errorMessageHtml += "</div>";

            return errorMessageHtml;
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            var isEmail = Regex.IsMatch(email, emailPattern);
            return isEmail;
        }
    }
}
