using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManage
{
    public class ImgManage
    {
        static string pattern = @"\.(png|jpg|jpeg|gif|bmp|tiff|webp)$";
        static string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        // 하면서 알게 되었는데, 이미지리스트는 같은 크기의 이미지만을 담을 수 있음.. 즉 (반복되는 이미지를 관리할때 사용)
        public static void ImgListMangement(string[]? images, ImageList imageList)
        {
            // Image 폴더 중 모든 이미지 파일 가져오기 (Directory.GetFiles는 정규식을 사용할 수 없음)
            // string[] imageFiles = Directory.GetFiles("./Images", @"^.*\.(png|jpg|jpeg|gif|bmp|tiff|webp");
            /*
            string[] imageFiles = Directory.GetFiles("./Images", "*.*")
                                           .Where(f => f.EndsWith(".png") || f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".gif") || f.EndsWith(".bmp") || f.EndsWith(".tiff") || f.EndsWith(".webp"))
                                           .ToArray();
            */

            // 생각해보니 이미지 파일만 주면 바로 추가가 가능 (확장자 반드시 추가)
            foreach (string img in images)
            {
                // img파일이 맞는지 체크 (하드 코딩이므로 잘못된 값이 주어질 수가 있으므로)
                int index = img.LastIndexOf(".");
                if (!Regex.IsMatch( img.Substring(index), pattern, RegexOptions.IgnoreCase) || index == -1)
                {
                    MessageBox.Show(@"이미지 파일이 지정되지 않았습니다. 잘못된 입력 : {img}", "오류");
                    return;
                } else
                {
                    // 이미지 파일 경로 설정
                    imageList.Images.Add(Image.FromFile($"{projectDirectory}/Images/{img}"));
                }
            }
        }

        /*
         * images 경로에 있는 이미지 파일을 Bitmap으로 변환하여 반환
         */
        public static Bitmap[] ImgtoBitmap(string[]? images)
        {
            Bitmap[] bitmaps = new Bitmap[images.Length];
            int i = 0;
            foreach (string img in images)
            {
                // img파일이 맞는지 체크 (하드 코딩이므로 잘못된 값이 주어질 수가 있으므로)
                int index = img.LastIndexOf(".");
                if (!Regex.IsMatch(img.Substring(index), pattern, RegexOptions.IgnoreCase) || index == -1)
                {
                    MessageBox.Show(@"이미지 파일이 지정되지 않았습니다. 잘못된 입력 : {img}", "오류");
                    return null;
                }
                else
                {
                    // bitmap
                    bitmaps[i] = new Bitmap($"{projectDirectory}/Images/{img}");
                    i++;
                }
            }
            return bitmaps;
        }
    }
}
