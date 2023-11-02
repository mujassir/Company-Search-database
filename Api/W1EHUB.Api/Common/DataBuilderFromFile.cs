using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace W1EHUB.Api.Common
{
    public class DataBuilderFromFile
    {
        public static List<Dictionary<string, string>> ExtractFromFile()
        {
            var productionCompanies = new Dictionary<int, string>
                {
                    { 0, "PRODUCTION COMPANY" },
                    { 2, "ROLE" },
                    { 4, "NAMES OF HEAD STAFF" },
                    { 7, "EMAILS" },
                    { 11, "WEBSITE" },
                };
            var postHouses = new Dictionary<int, string>
                {
                    { 0, "POST PRODUCTION COMPANY" },
                    { 2, "COUNTRY OF ORIGIN/ REGION" },
                    { 4, "ROLE" },
                    { 6, "NAMES OF HEAD STAFF" },
                    { 9, "EMAILS" },
                    { 13, "WEBSITE" },
                };
            var studios = productionCompanies;
            var salesAgent = new Dictionary<int, string>
                {
                    { 0, "SALES AGENTS" },
                    { 2, "ROLE" },
                    { 4, "NAMES OF HEAD STAFF" },
                    { 7, "EMAILS" },
                    { 11, "WEBSITE" },
                }; ;
            var distributers = new Dictionary<int, string>
                {
                    { 0, "DISTRIBUTORS" },
                    { 2, "COUNTRY OF ORIGIN/ REGION" },
                    { 4, "ROLE" },
                    { 6, "NAMES OF HEAD STAFF" },
                    { 9, "EMAILS" },
                    { 13, "WEBSITE" },
                };
            var publications = new Dictionary<int, string>
                {
                    { 0, "PUBLICATION" },
                    { 2, "Country of Origin" },
                    { 4, "ROLE" },
                    { 6, "NAMES OF HEAD STAFF" },
                    { 9, "EMAILS" },
                    { 13, "WEBSITE" },
                };
            var yorkshireBasedPostHouses = postHouses;
            var animationCompanies = new Dictionary<int, string>
                {
                    { 0, "ANIMATION COMPANIES" },
                    { 2, "COUNTRY OF ORIGIN/ REGION" },
                    { 4, "ROLE" },
                    { 6, "NAMES OF HEAD STAFF" },
                    { 9, "EMAILS" },
                    { 13, "WEBSITE" },
                };

            var sheetTemplates = new List<Dictionary<int, string>>()
                {
                    productionCompanies, postHouses, studios, salesAgent, distributers, publications, yorkshireBasedPostHouses, animationCompanies
                };

            var jsonData = ExcelReader.ReadExcelFile("wwwroot/Companies - W1E - Production A to Z.xlsx", sheetTemplates);

            // Loop on sheets
            var newJsonData = new List<Dictionary<string, string>>();

            var sheetNames = jsonData.Keys.ToList();
            for (int sheetIndex = 0; sheetIndex < sheetNames.Count(); sheetIndex++)
            {

                var sheetName = sheetNames[sheetIndex];
                var template = sheetTemplates[sheetIndex];

                var firstCell = template.ElementAt(0).Value;
                var secondCell = template.ElementAt(1).Value;

                var sheetData = jsonData[sheetNames[sheetIndex]] as List<Dictionary<string, string>>;

                for (int rowIndex = 0; rowIndex < sheetData.Count(); rowIndex++)
                {
                    var row = sheetData[rowIndex];
                    if (row.Count() < template.Count()) continue;
                    // Remove if first two cells are merged
                    if (string.IsNullOrEmpty(row[firstCell]) && string.IsNullOrEmpty(row[secondCell])) continue;

                    // Remove if first cell is null or 2nd cell is not null
                    if (!string.IsNullOrEmpty(row[firstCell]) && string.IsNullOrEmpty(row[secondCell])) continue;

                    // Remove duplicate header row -- if first two cell value are same with key
                    if (row[firstCell] == firstCell && row[secondCell] == secondCell) continue;

                    // Set value if first rows cells are merged but second cell is single
                    if (string.IsNullOrEmpty(row[firstCell]) && !string.IsNullOrEmpty(row[secondCell]))
                    {
                        row[firstCell] = newJsonData.LastOrDefault()[firstCell];
                    }

                    row["Category"] = sheetName;

                    // Define regular expressions for company, type, and address
                    string companyPattern = @"^(.*)(?=\n|\()";
                    string typePattern = @"\(([^)]*)\)";
                    string addressPattern = @"\)(.*)$";
                    string replacePattern = @"(|)|\n";

                    string input;
                    // Set Type and rename Column
                    switch (sheetIndex)
                    {
                        case 0:
                        case 2:
                            // Split first column into Company, Address, Type
                            input = row[firstCell];

                            // Extract the company, type, and address
                            row["COMPANY"] = Regex.Replace(Regex.Match(input, companyPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["TYPE"] = Regex.Replace(Regex.Match(input, typePattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["COUNTRY OF ORIGIN/ REGION"] = Regex.Replace(Regex.Match(input, addressPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            break;
                        case 1:
                        case 6:
                            row["PRODUCTION COMPANY"] = row["POST PRODUCTION COMPANY"];
                            row["COMPANY"] = row["POST PRODUCTION COMPANY"];
                            break;
                        case 3:
                            row["PRODUCTION COMPANY"] = row["SALES AGENTS"];
                            // Split first column into Company, Address, Type
                            input = row["SALES AGENTS"];

                            // Extract the company, type, and address
                            row["COMPANY"] = Regex.Replace(Regex.Match(input, companyPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["TYPE"] = Regex.Replace(Regex.Match(input, typePattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["COUNTRY OF ORIGIN/ REGION"] = Regex.Replace(Regex.Match(input, addressPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            break;
                        case 4:
                            row["PRODUCTION COMPANY"] = row["DISTRIBUTORS"];
                            // Split first column into Company, Address, Type
                            input = row["DISTRIBUTORS"];

                            // Extract the company, type, and address
                            row["COMPANY"] = Regex.Replace(Regex.Match(input, companyPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["TYPE"] = Regex.Replace(Regex.Match(input, typePattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            row["COUNTRY OF ORIGIN/ REGION"] = Regex.Replace(Regex.Match(input, addressPattern).Groups[1].Value.Trim(), replacePattern, string.Empty);
                            break;
                        case 5:
                            row["PRODUCTION COMPANY"] = row["PUBLICATION"];
                            row["COMPANY"] = row["PUBLICATION"];
                            row["COUNTRY OF ORIGIN/ REGION"] = row["Country of Origin"];
                            break;
                        case 7:
                            row["COMPANY"] = row["ANIMATION COMPANIES"];
                            row["PRODUCTION COMPANY"] = row["ANIMATION COMPANIES"];
                            break;
                    }

                    newJsonData.Add(row);
                }
            }
            return newJsonData;
        }

        public static List<Dictionary<string, string>> ExtractAndRemoveDuplicates(List<Dictionary<string, string>> json, string key)
        {

            // Create a HashSet to store unique categories
            HashSet<string> uniqueData = new HashSet<string>();

            // Create a list to store unique objects
            List<Dictionary<string, string>> uniqueItems = new List<Dictionary<string, string>>();

            // Iterate through the and add their Category values to the HashSet
            foreach (var item in json)
            {
                if (uniqueData.Add(item[key]))
                {
                    // Only add the unique objects to the list
                    uniqueItems.Add(item);
                }
            }

            return uniqueItems;
        }
    }
}
