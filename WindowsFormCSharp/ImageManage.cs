using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageManage
{
    public static class ImageManage
    {
        public static ImageList ImgListMangement(string[]? images, ListView listView)
        {
            // ImageList 생성
            ImageList imageList = new ImageList();

            // Image 폴더 중 모든 이미지 파일 가져오기 (Directory.GetFiles는 정규식을 사용할 수 없음)
            // string[] imageFiles = Directory.GetFiles("./Images", @"^.*\.(png|jpg|jpeg|gif|bmp|tiff|webp");
            /*
            string[] imageFiles = Directory.GetFiles("./Images", "*.*")
                                           .Where(f => f.EndsWith(".png") || f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".gif") || f.EndsWith(".bmp") || f.EndsWith(".tiff") || f.EndsWith(".webp"))
                                           .ToArray();
            */

            string pattern = @"\.(png|jpg|jpeg|gif|bmp|tiff|webp)$";

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
                    imageList.Images.Add(Image.FromFile(img));
                }
            }

            return imageList;
        }
    }
}
