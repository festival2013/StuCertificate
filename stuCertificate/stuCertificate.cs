using System;
using System.Collections.Generic;
using System.Text;
using FelicaLib;

namespace FelicaLib
{
    public class stuCertificate{

        public static void Main(){

            // よく落ちるから例外処理しておく(適当)
            try{
                using (Felica f = new Felica()){

                    readNanaco(f);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void readNanaco(Felica f)
        {

            string gakuNum = null;
            f.Polling(0xfe00);

            // 情報を取得
            byte[] data = f.ReadWithoutEncryption(0x1A8B, 0x0001);
            /*
             * (0x1A8B, 0x0001):学籍番号
             * (0x1A8B, 0x0002):氏名
             * (0x1A8B, 0x0003):アカウント有効開始日
             * (0x1A8B, 0x0004):アカウント失効日
             */
            if (data == null)
            {
                throw new Exception("読み込みに失敗しました");
            }
            Console.Write("学籍番号:");
            for (int i = 0; i < 16; i++)
            {
                Console.Write(data[i].ToString("X2"));
            }
            Console.Write("\n");

        }

    }

}