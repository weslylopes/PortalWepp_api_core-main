using System;
using System.Drawing;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SylerBackend.Service.Others
{
    public class ImageConf
    {
        public static string ResizeImageAndSave(string imagePath, int largura, int altura, string saveAs)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imagePath);
            var thumbnailImg = new Bitmap(largura, altura);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, largura, altura);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            //string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), Path.GetFileNameWithoutExtension(imagePath));
            thumbnailImg.Save(saveAs, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnailImg.Dispose();
            return saveAs;
        }

        public static string RetornaDiretorioImagemClienteG()
        {
            var diretorios = new string[] { AppDomain.CurrentDomain.BaseDirectory, "Images", "Cliente", "G" };
            return Path.Combine(diretorios);
        }

        public static string RetornaDiretorioImagemClienteP()
        {
            var diretorios = new string[] { AppDomain.CurrentDomain.BaseDirectory, "Images", "Cliente", "P" };
            return Path.Combine(diretorios);
        }

        public static string RetornaCaminhoImagemClienteG(string nomeImagem)
        {
            if (string.IsNullOrWhiteSpace(nomeImagem))
                return string.Empty;
            var config = new ConfigurationBuilder();
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json");
            var build = config.Build();
            var caminho = build.GetSection("PathImagem")["CaminhoImagemClienteG"];
            caminho += nomeImagem;
            return caminho;
        }
    }
}
