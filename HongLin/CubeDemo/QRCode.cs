using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using com.google.zxing;
using ByteMatrix = com.google.zxing.common.ByteMatrix;

namespace CubeDemo
{
    public class QRCode
    {
        public class RQCodeClass
        {

            #region -生成二维码-
            /// <summary>
            /// 生成二维码图片
            /// </summary>
            /// <param name="strURL">传入内容需要生成的URL地址</param>
            /// <param name="intQRImgWigthAndHeight">矩形图片大小（wigth=height）</param>
            /// <param name="errorCorrect">容错值 1表示：L;2表示：M;3表示：Q;4表示：H(L--7%,M--15%,Q--25%,H--30%.) </param>
            /// <param name="multiFormatWriter">以参数的形式返回一个二维码对象</param>
            /// <returns>返回一个对象Bitmap</returns>
            private Bitmap GetCreateQRCodeImg(string strURL, int intQRImgWigthAndHeight, int errorCorrect, out MultiFormatWriter multiFormatWriter)
            {
                //生成二维码
                Hashtable hint = new Hashtable();
                hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//添加一个编码
                                                                //根据传入的容错值 来进行判断
                                                                //L--7%,M--15%,Q--25%,H--30%.
                switch (errorCorrect)
                {
                    case 1://表示 L
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.L);
                        break;
                    case 2:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.M);
                        break;
                    case 3:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.Q);
                        break;
                    case 4:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.H);
                        break;
                    default:
                        //没有该容错值
                        break;
                }

                MultiFormatWriter multiWriter = new MultiFormatWriter();
                //要在命名引用空间中 引用 using ByteMatrix=com.google.zxing.common.ByteMatrix;如不添加的话，multiWriter.encode()返回值类型，无法隐式转化。
                ByteMatrix bm = multiWriter.encode(strURL, com.google.zxing.BarcodeFormat.QR_CODE, intQRImgWigthAndHeight, intQRImgWigthAndHeight, hint);

                Bitmap img = bm.ToBitmap();//转化为二维码图；
                multiFormatWriter = multiWriter;//返回一个二维码对象；out
                return img;
            }

            /// <summary>
            /// 生成二维码图片
            /// </summary>
            /// <param name="strURL">传入内容需要生成的URL地址</param>
            /// <param name="intQRImgWigthAndHeight">矩形图片大小（wigth=height）</param>
            /// <param name="errorCorrect">容错值 1表示：L;2表示：M;3表示：Q;4表示：H(L--7%,M--15%,Q--25%,H--30%.) </param>
            /// <param name="multiFormatWriter">以参数的形式返回一个二维码对象</param>
            /// <returns>返回一个对象Bitmap</returns>
            public Bitmap GetCreateQRCodeImg(string strURL, int intQRImgWigthAndHeight, int errorCorrect)
            {
                //生成二维码
                Hashtable hint = new Hashtable();
                hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//添加一个编码
                                                                //根据传入的容错值 来进行判断
                                                                //L--7%,M--15%,Q--25%,H--30%.
                switch (errorCorrect)
                {
                    case 1://表示 L
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.L);
                        break;
                    case 2:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.M);
                        break;
                    case 3:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.Q);
                        break;
                    case 4:
                        hint.Add(EncodeHintType.ERROR_CORRECTION, com.google.zxing.qrcode.decoder.ErrorCorrectionLevel.H);
                        break;
                    default:
                        //没有该容错值
                        break;
                }

                MultiFormatWriter multiWriter = new MultiFormatWriter();
                //要在命名引用空间中 引用 using ByteMatrix=com.google.zxing.common.ByteMatrix;如不添加的话，multiWriter.encode()返回值类型，无法隐式转化。
                ByteMatrix bm = multiWriter.encode(strURL, com.google.zxing.BarcodeFormat.QR_CODE, intQRImgWigthAndHeight, intQRImgWigthAndHeight, hint);

                Bitmap img = bm.ToBitmap();//转化为二维码图；
                return img;
            }
            #endregion

            /// <summary>
            /// 生成插图的二维码
            /// </summary>
            /// <param name="strQRCodeContentURL">需要生成URL的二维码</param>
            /// <param name="strInsertSmallImgPath">需要插入小图图片的路径</param>
            /// <param name="intQRCodeWidthAndHeigth">矩正的大小</param>
            /// <param name="errorCorrection">容错：1 表示：L ;2表示：M ; 3表示：Q;4表示：H (L--7%; M--15%;Q--25%;H--30%)</param>
            /// <returns></returns>
            public Bitmap GetCreateQRCodeInsertSmallImg(string strQRCodeContentURL, string strInsertSmallImgPath, int intQRCodeWidthAndHeigth, int errorCorrection)
            {
                MultiFormatWriter multiWrtier = new MultiFormatWriter();//多元框架重写

                Bitmap bitmap = GetCreateQRCodeImg(strQRCodeContentURL, intQRCodeWidthAndHeigth, errorCorrection, out multiWrtier);//生成二维码
                Bitmap bitmapInsertImg = GetCreateInsertSmallImg(bitmap, multiWrtier, strInsertSmallImgPath, strQRCodeContentURL, intQRCodeWidthAndHeigth);//生成插图二维码
                                                                                                                                                           //资源的释放
                bitmap.Dispose();
                return bitmapInsertImg;
            }

            /// 生成插图的二维码方法
            /// </summary>
            /// <param name="bitQRImg">二维码图片对象</param>
            /// <param name="multiWriter">多元框架读取</param>
            /// <param name="strInsertImgPath">插入图片的路径</param>
            /// <param name="strURL">需要生成二维码URL的内容</param>
            /// <param name="scale">比例大小</param>
            /// <param name="savePath">生成插图的二维码</param>
            private Bitmap GetCreateInsertSmallImg(Bitmap bitQRImg, MultiFormatWriter multiWriter, string strInsertImgPath, string strURL, int scale)
            {
                //读取需要小图的物理路径
                string Path = strInsertImgPath;
                FileStream _fs = new FileStream(Path, FileMode.Open);//打开数据流
                var middleImg = System.Drawing.Image.FromStream(_fs, true);//读取

                //计算插入图片的大小和位置
                //取二维码实际尺寸(去掉二维码两边空白处的实际尺寸)
                System.Drawing.Size rederSize = multiWriter.GetEncodeSize(strURL, BarcodeFormat.QR_CODE, scale, scale);
                int middleImgW = Math.Min((int)(rederSize.Width / 3.5), middleImg.Width);
                int middleImgH = Math.Min((int)(rederSize.Height / 3.5), middleImg.Height);

                int middleImgL = (bitQRImg.Width - middleImgW) / 2;
                int middleImgT = (bitQRImg.Height - middleImgH) / 2;
                //将img 转化为bmp 格式，否则无创建Graphic
                Bitmap bitMap = new Bitmap(bitQRImg.Width, bitQRImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    //并联插图片模式
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //呈现质量
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //合成图像质量
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(bitQRImg, 0, 0);//绘图
                }
                //在二维码中插入图片
                System.Drawing.Graphics myGraphics = Graphics.FromImage(bitMap);

                //填充一个矩形
                myGraphics.FillRectangle(Brushes.White, middleImgL, middleImgT, middleImgW, middleImgH);
                myGraphics.DrawImage(middleImg, middleImgL, middleImgT, middleImgW, middleImgH);

                //资源释放
                middleImg.Dispose();
                myGraphics.Dispose();
                return bitMap;
            }
        }
    }
}