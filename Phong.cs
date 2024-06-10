using System;

namespace HotelManagement
{
    public class Phong
    {
        public int SoPhong { get; }
        public bool LaPhongDoi { get; }
        public DateTime? GioVao { get; private set; }
        public decimal TienNuoc { get; private set; }

        public Phong(int soPhong, bool laPhongDoi)
        {
            SoPhong = soPhong;
            LaPhongDoi = laPhongDoi;
            GioVao = null;
            TienNuoc = 0;
        }

        public void KhachVao(decimal tienNuoc)
        {
            GioVao = DateTime.Now;
            TienNuoc = tienNuoc;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Khach vao phong {SoPhong} luc {GioVao}");
            Console.ResetColor();



        }

        public void KhachRa()
        {
            if (GioVao == null)
            {
                throw new InvalidOperationException("Phong chua co khach.");
            }

            DateTime gioRa = DateTime.Now;
            DateTime gioVao = GioVao.Value; // Sử dụng thuộc tính Value để truy cập giá trị của kiểu Nullable
            int tongSoGio = TinhGio(gioVao, gioRa);
            decimal tienPhong = TinhTien(tongSoGio);
            decimal tongTien = tienPhong * 1000 + TienNuoc * 1000;

            Console.WriteLine($"Gio vao: {gioVao}");
            Console.WriteLine($"Gio ra: {gioRa}");
            Console.WriteLine($"Tong so gio o: {tongSoGio}");
            Console.WriteLine($"Tien phong: {tienPhong}");
            Console.WriteLine($"Tien nuoc: {TienNuoc}");

            // Bôi xanh và in tổng tiền
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tong tien: {tongTien}");
            Console.ResetColor();

            // Log to file
            Logger.Log($"Khach Tra phong {SoPhong}, Gio vao:{gioVao}  Tong so gio o: {tongSoGio}h, Tien phong: {tienPhong}, Tien nuoc: {TienNuoc}, Tong tien: {tongTien}");

            // Đặt lại trạng thái phòng sau khi khách ra
            GioVao = null;
            TienNuoc = 0;

            // Cách một dòng trống sau khi tính toán xong
            Console.WriteLine();
        }

        private int TinhGio(DateTime gioVao, DateTime gioRa)
        {
            TimeSpan thoiGianO = gioRa - gioVao;
            double tongSoPhut = thoiGianO.TotalMinutes;
            int tongSoGio = (int)(tongSoPhut / 60);
            double soPhutConLai = tongSoPhut % 60;

            if (soPhutConLai >= 15)
            {
                tongSoGio += 1;
            }

            return tongSoGio;
        }

        private decimal TinhTien(int tongSoGio)
        {
            const decimal giaGioDauPhongDon = 60m;
            const decimal giaGioDauPhongDoi = 70m;
            const decimal giaGioThuHai = 20m;
            const decimal giaGioThem = 10m;

            decimal giaGioDau = LaPhongDoi ? giaGioDauPhongDoi : giaGioDauPhongDon;

            if (tongSoGio == 1)
            {
                return giaGioDau;
            }
            else if (tongSoGio == 2)
            {
                return giaGioDau + giaGioThuHai;
            }
            else
            {
                return giaGioDau + giaGioThuHai + (tongSoGio - 2) * giaGioThem;
            }
        }
    }
}