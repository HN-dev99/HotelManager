
using System;
using System.Collections.Generic;

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> phongDon = new List<int> { 101, 102, 103, 104, 204, 205, 206, 304, 305, 306 };
            List<int> phongDoi = new List<int> { 201, 202, 203, 301, 302, 303, 401, 402 };

            Dictionary<int, Phong> dsPhong = new Dictionary<int, Phong>();

            foreach (var soPhong in phongDon)
            {
                dsPhong[soPhong] = new Phong(soPhong, false);
            }

            foreach (var soPhong in phongDoi)
            {
                dsPhong[soPhong] = new Phong(soPhong, true);
            }

            while (true)
            {
                Console.WriteLine("1. Khach vao phong");
                Console.WriteLine("2. Khach ra phong");
                Console.WriteLine("3. Thoat");
                Console.Write("Chon mot tuy chon: ");
                string luaChon = Console.ReadLine();

                if (luaChon == "1")
                {
                    Console.WriteLine("Nhap so phong (cach nhau boi dau phay):");
                    string soPhongNhap = Console.ReadLine();
                    string[] soPhongs = soPhongNhap.Split(',');

                    foreach (string soPhongStr in soPhongs)
                    {
                        int soPhong;
                        if (int.TryParse(soPhongStr.Trim(), out soPhong) && dsPhong.ContainsKey(soPhong))
                        {
                            Phong phongChon = dsPhong[soPhong];
                            if (phongChon.GioVao == null)
                            {
                                Console.WriteLine($"Nhap tien nuoc cho phong {soPhong}:");
                                string tienNuocStr = Console.ReadLine() ?? "0"; // Cung cấp giá trị mặc định nếu null
                                decimal tienNuocNhap;
                                if (decimal.TryParse(tienNuocStr, out tienNuocNhap))
                                {
                                    phongChon.KhachVao(tienNuocNhap);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Gia tri tien nuoc khong hop le.");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Phong {soPhong} da co khach.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Phong {soPhongStr} khong ton tai.");
                            Console.ResetColor();
                        }
                    }
                }
                else if (luaChon == "2")
                {
                    Console.WriteLine("Nhap so phong (cach nhau boi dau phay):");
                    string soPhongNhap = Console.ReadLine();
                    string[] soPhongs = soPhongNhap.Split(',');

                    foreach (string soPhongStr in soPhongs)
                    {
                        int soPhong;
                        if (int.TryParse(soPhongStr.Trim(), out soPhong) && dsPhong.ContainsKey(soPhong))
                        {
                            Phong phongChon = dsPhong[soPhong];

                            if (phongChon.GioVao != null)
                            {
                                phongChon.KhachRa();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Phong {soPhong} chua co khach.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Phong {soPhongStr} khong ton tai.");
                            Console.ResetColor();
                        }
                    }
                }
                else if (luaChon == "3")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Lua chon khong hop le.");
                    Console.ResetColor();

                }
            }
        }
    }
}



