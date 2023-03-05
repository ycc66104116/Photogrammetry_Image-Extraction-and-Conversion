using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageProcessing;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        LOCImage OImage = null;
        LOCImage ProcessedImage = null;
        String Filename ;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button newBtn = (Button)sender;
            


            switch (newBtn.Name)
            {
                case "open":
                    OpenFileDialog OFD = new OpenFileDialog();
                    OFD.ShowDialog();
                    Filename = OFD.FileName;
                    Original.Source = new BitmapImage(new Uri(Filename));
                    OImage = new LOCImage(Filename, Int32Rect.Empty);
                   /* LOCImage ProcessImage = new LOCImage(960, 960, 96, 96, PixelFormats.Bgr24, null);

                    AffineTransform Affine = new AffineTransform(3);
                    Affine.Coeffs = new float[6];
                    Affine.Coeffs[0] = 0.8660254041f;
                    Affine.Coeffs[1] = 0.5f;
                    Affine.Coeffs[2] = 0;
                    Affine.Coeffs[3] = -0.5f;
                    Affine.Coeffs[4] = 0.8660254041f;
                    Affine.Coeffs[5] = 0;

                    for (int i = 0; i < OImage.Width; i++)
                    {
                        int Index = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            Index = (j * OImage.Height + i) * 3;
                            Affine.Transform(i - 960 / 2, -j + 960 / 2);
                            for (int k = 0; k < ProcessImage.NumberOfBands; k++)
                            {
                                ProcessImage.ByteData[Index + k] = (byte)Interpolation.Bilinear(OImage.ByteData, OImage.Width, OImage.Height, 3, 1, Affine.TransformPt[0] + 960 / 2, -Affine.TransformPt[1] + 960 / 2, k);
                            }
                        }


                    }
                    string ProcessedFile = "C:\\0319test\\Papa_Processed.tif";
                    ProcessImage.Save(ProcessedFile, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }*/
                    break;
                case "R_band":
                     ProcessedImage = new LOCImage(OImage.Width, OImage.Height, 96, 96, PixelFormats.Gray8, null);                  
                    for (int i = 0; i < OImage.Width; i++)
                    {
                        int Index = 0;
                        int OIndex = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            Index = (j * OImage.Width + i) ;
                            OIndex= (j * OImage.Width + i) * 3;

                            ProcessedImage.ByteData[Index ] = (byte)OImage.ByteData[(int)OIndex + 2];
                            
                        }


                    }
                    string ProcessedFile = "D:\\四下\\近景攝影測量\\0319test\\parrot_r.jpg";
                    ProcessedImage.Save(ProcessedFile, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    break;
                case "G_band":
                     ProcessedImage = new LOCImage(OImage.Width, OImage.Height, 96, 96, PixelFormats.Gray8, null);
                    for (int i = 0; i < OImage.Width; i++)
                    {
                        int Index = 0;
                        int OIndex = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            Index = (j * OImage.Width + i);
                            OIndex = (j * OImage.Width + i) * 3;

                            ProcessedImage.ByteData[Index] = (byte)OImage.ByteData[(int)OIndex + 1];
                        }
                    }
                    string ProcessedFile2 = "D:\\四下\\近景攝影測量\\0319test\\parrot_g.jpg";
                    ProcessedImage.Save(ProcessedFile2, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile2, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    break;
                case "B_band":
                    ProcessedImage = new LOCImage(OImage.Width, OImage.Height, 96, 96, PixelFormats.Gray8, null);
                    for (int i = 0; i < OImage.Width; i++)
                    {
                        int Index = 0;
                        int OIndex = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            Index = (j * OImage.Width + i);
                            OIndex = (j * OImage.Width + i) * 3;
                            ProcessedImage.ByteData[Index] = (byte)OImage.ByteData[(int)OIndex + 0];
                        }
                    }
                    string ProcessedFile3 = "D:\\四下\\近景攝影測量\\0319test\\parrot_b.jpg";
                    ProcessedImage.Save(ProcessedFile3, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile3, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    break;
                case "negative":
                    ProcessedImage = new LOCImage(OImage.Width, OImage.Height, 96, 96, PixelFormats.Bgr24, null);
                    for (int i = 0; i < OImage.Width; i++)
                    {                        
                        int OIndex = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            
                            OIndex = (j * OImage.Width + i) * 3;
                            for (int k = 0; k < ProcessedImage.NumberOfBands; k++)
                            {
                                ProcessedImage.ByteData[OIndex+k] = (byte)(255-(OImage.ByteData[OIndex + k]));
                            }
                        }
                    }
                    string ProcessedFile4 = "D:\\四下\\近景攝影測量\\0319test\\parrot_negative.jpg";
                    ProcessedImage.Save(ProcessedFile4, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile4, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    break;
                case "gray":
                    ProcessedImage = new LOCImage(OImage.Width, OImage.Height, 96, 96, PixelFormats.Gray8, null);
                    for (int i = 0; i < OImage.Width; i++)
                    {
                        int Index = 0;
                        int OIndex = 0;
                        for (int j = 0; j < OImage.Height; j++)
                        {
                            Index = (j * OImage.Width + i);
                            OIndex = (j * OImage.Width + i) * 3;
                            ProcessedImage.ByteData[Index] = (byte)(((OImage.ByteData[OIndex + 0])+ (OImage.ByteData[OIndex + 1])+ (OImage.ByteData[OIndex + 2]))/3);
                            
                        }
                    }
                    string ProcessedFile5 = "D:\\四下\\近景攝影測量\\0319test\\parrot_gray.jpg";
                    ProcessedImage.Save(ProcessedFile5, ImageFormat.Tiff);
                    using (var stream = new FileStream(ProcessedFile5, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        Process.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    break;
            }
            
        }

       
    }
}
