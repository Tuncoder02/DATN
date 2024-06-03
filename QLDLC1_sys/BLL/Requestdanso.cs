using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class Requestdanso
    {

        private static readonly Dictionary<char, char> VietnameseCharMap = new Dictionary<char, char>
    {
        {'À', 'A'}, {'Á', 'A'}, {'Â', 'A'}, {'Ã', 'A'}, {'È', 'E'}, {'É', 'E'}, {'Ê', 'E'},
        {'Ì', 'I'}, {'Í', 'I'}, {'Ò', 'O'}, {'Ó', 'O'}, {'Ô', 'O'}, {'Õ', 'O'}, {'Ù', 'U'},
        {'Ú', 'U'}, {'Ý', 'Y'}, {'à', 'a'}, {'á', 'a'}, {'â', 'a'}, {'ã', 'a'}, {'è', 'e'},
        {'é', 'e'}, {'ê', 'e'}, {'ì', 'i'}, {'í', 'i'}, {'ò', 'o'}, {'ó', 'o'}, {'ô', 'o'},
        {'õ', 'o'}, {'ù', 'u'}, {'ú', 'u'}, {'ý', 'y'}, {'Ă', 'A'}, {'ă', 'a'}, {'Đ', 'D'},
        {'đ', 'd'}, {'Ĩ', 'I'}, {'ĩ', 'i'}, {'Ũ', 'U'}, {'ũ', 'u'}, {'Ơ', 'O'}, {'ơ', 'o'},
        {'Ư', 'U'}, {'ư', 'u'}, {'Ạ', 'A'}, {'ạ', 'a'}, {'Ả', 'A'}, {'ả', 'a'}, {'Ấ', 'A'},
        {'ấ', 'a'}, {'Ầ', 'A'}, {'ầ', 'a'}, {'Ẩ', 'A'}, {'ẩ', 'a'}, {'Ẫ', 'A'}, {'ẫ', 'a'},
        {'Ậ', 'A'}, {'ậ', 'a'}, {'Ắ', 'A'}, {'ắ', 'a'}, {'Ằ', 'A'}, {'ằ', 'a'}, {'Ẳ', 'A'},
        {'ẳ', 'a'}, {'Ẵ', 'A'}, {'ẵ', 'a'}, {'Ặ', 'A'}, {'ặ', 'a'}, {'Ẹ', 'E'}, {'ẹ', 'e'},
        {'Ẻ', 'E'}, {'ẻ', 'e'}, {'Ẽ', 'E'}, {'ẽ', 'e'}, {'Ế', 'E'}, {'ế', 'e'}, {'Ề', 'E'},
        {'ề', 'e'}, {'Ể', 'E'}, {'ể', 'e'}, {'Ễ', 'E'}, {'ễ', 'e'}, {'Ệ', 'E'}, {'ệ', 'e'},
        {'Ỉ', 'I'}, {'ỉ', 'i'}, {'Ị', 'I'}, {'ị', 'i'}, {'Ọ', 'O'}, {'ọ', 'o'}, {'Ỏ', 'O'},
        {'ỏ', 'o'}, {'Ố', 'O'}, {'ố', 'o'}, {'Ồ', 'O'}, {'ồ', 'o'}, {'Ổ', 'O'}, {'ổ', 'o'},
        {'Ỗ', 'O'}, {'ỗ', 'o'}, {'Ộ', 'O'}, {'ộ', 'o'}, {'Ớ', 'O'}, {'ớ', 'o'}, {'Ờ', 'O'},
        {'ờ', 'o'}, {'Ở', 'O'}, {'ở', 'o'}, {'Ỡ', 'O'}, {'ỡ', 'o'}, {'Ợ', 'O'}, {'ợ', 'o'},
        {'Ụ', 'U'}, {'ụ', 'u'}, {'Ủ', 'U'}, {'ủ', 'u'}, {'Ứ', 'U'}, {'ứ', 'u'}, {'Ừ', 'U'},
        {'ừ', 'u'}, {'Ử', 'U'}, {'ử', 'u'}, {'Ữ', 'U'}, {'ữ', 'u'}, {'Ự', 'U'}, {'ự', 'u'}
    };

        public static string ConvertToUpperNoDiacritics(string input)
        {
            // Bước 1: Chuẩn hóa chuỗi để tách các ký tự dấu ra
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            // Bước 2: Loại bỏ các ký tự dấu và thay thế bằng ký tự không dấu
            foreach (char c in normalized)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (VietnameseCharMap.ContainsKey(c))
                    {
                        stringBuilder.Append(VietnameseCharMap[c]);
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }
                }
            }

            // Bước 3: Chuẩn hóa lại chuỗi, chuyển sang chữ in hoa, và thay thế khoảng trắng bằng dấu gạch dưới
            string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
            result = result.ToUpperInvariant();
            result = Regex.Replace(result, @"\s+", "_");

            // Bước 4: Loại bỏ các ký tự đặc biệt không phải là chữ cái hoặc chữ số, ngoại trừ dấu gạch dưới
            result = Regex.Replace(result, @"[^A-Z0-9_]", "");

            return result;
        }

        public static float[] TrichXuatDuLieu(string duLieuPhanHoi)
        {
            // Tìm vị trí bắt đầu và kết thúc của phần DATA
            int batDau = duLieuPhanHoi.IndexOf("DATA=") + 5;
            int ketThuc = duLieuPhanHoi.IndexOf(";", batDau);

            if ((batDau >= 0) && (ketThuc >= 0))
            {
                // Trích xuất phần dữ liệu như một chuỗi
                string phanData = duLieuPhanHoi.Substring(batDau, ketThuc - batDau);

                // Tách phần dữ liệu thành các giá trị riêng lẻ
                string[] giaTriDuLieuStr = phanData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                float[] giaTriDuLieu = new float[3]; 
                giaTriDuLieu[0]=  float.Parse(giaTriDuLieuStr[0]);
                giaTriDuLieu[1] = float.Parse(giaTriDuLieuStr[1]);
                giaTriDuLieu[2] = float.Parse(giaTriDuLieuStr[2]);



                return giaTriDuLieu;
            }
            else
            {
                throw new Exception("Không tìm thấy phần DATA trong phản hồi");
            }
        }

        public static async Task PostRequestAsync(string diaPhuongValue, TextBox text1, TextBox text2, TextBox text3)
        {

            string url = "https://pxweb.gso.gov.vn:443/api/v1/vi/Dân số và lao động/V02.01.px";

            // Example value for "Địa phương"

            // Define the JSON payload
            string jsonPayload = $@"
        {{
          ""query"": [
            {{
              ""code"": ""Địa phương"",
              ""selection"": {{
                ""filter"": ""item"",
                ""values"": [
                  ""{diaPhuongValue}""
                ]
              }}
            }},
            {{
              ""code"": ""Năm"",
              ""selection"": {{
                ""filter"": ""item"",
                ""values"": [
                  ""11""
                ]
              }}
            }}
          ],
          ""response"": {{
            ""format"": ""px""
          }}
        }}";
            using (HttpClient client = new HttpClient())
            {
                // Set the content of the request
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseData = await response.Content.ReadAsStringAsync();
                    var giaTriDuLieu = TrichXuatDuLieu(responseData);
                    text1.Text = giaTriDuLieu[0].ToString();
                    text2.Text = giaTriDuLieu[1].ToString();
                    text3.Text = giaTriDuLieu[2].ToString();

                }
                else
                {
                    MessageBox.Show("Lỗi request dân số");
                }
            }
        }

        
    }

}
