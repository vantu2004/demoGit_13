using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class ThongKe
    {
        public static void thucThi_load_BieuDoTron(Chart c, string IdCompany)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var lichPhongVanList = dbContext.JobPostings
                                                .Where(l => l.IdCompany == IdCompany)
                                                .GroupBy(l => l.Job) // Gom nhóm theo JobName
                                                .Select(g => new
                                                {
                                                    Job = g.Key,
                                                    Total = g.Count()
                                                    // Các trường dữ liệu khác có thể thêm vào ở đây nếu cần
                                                })
                                                .ToList();

                    veBieuDoHinhTron(c, lichPhongVanList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void thucThi_load_BieuDoTron_BangTin(Chart c)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var lichPhongVanList = dbContext.JobPostings
                                                .GroupBy(l => l.Job) // Gom nhóm theo JobName
                                                .Select(g => new
                                                {
                                                    Job = g.Key,
                                                    Total = g.Count()
                                                    // Các trường dữ liệu khác có thể thêm vào ở đây nếu cần
                                                })
                                                .ToList();

                    veBieuDoHinhTron(c, lichPhongVanList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void veBieuDoHinhTron(Chart c, dynamic temp)
        {
            // Tạo series mới cho biểu đồ tròn
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            // Thêm dữ liệu vào series
            foreach (var data in temp)
            {
                DataPoint point = series.Points.Add(data.Total);
                //  hiển thị tên
                point.LegendText = $"{"(" + data.Total + "): " + data.Job}";

                // Lưu trữ phần trăm vào thuộc tính CustomProperties
                point["Exploded"] = "true";
                // Tùy chỉnh cho hiệu ứng nổ
                point.CustomProperties = "Exploded=true";
                // Tạo chuỗi format để hiển thị phần trăm                                          
                point.Label = "#PERCENT{P0}";
            }

            // Xóa dữ liệu cũ trong series
            c.Series.Clear();

            // Thêm series vào biểu đồ
            c.Series.Add(series);
        }

        public static void thucThi_load_BieuDoCot(Chart c, string IdCompany)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var lichPhongVanList = dbContext.JobPostings
                        .Join(dbContext.Applications, // Bảng Applications
                            jp => jp.IdJobPostings, // Key của bảng JobPostings
                            app => app.IdJobPostings, // Key của bảng Applications
                            (jp, app) => jp) // Kết hợp các dữ liệu từ hai bảng và chọn JobPostings
                        .Where(jp => jp.IdCompany == IdCompany) // Lọc theo IdCompany
                        .GroupBy(jp => new { jp.JobName, jp.IdJobPostings }) // Gom nhóm theo JobName và IdJobPostings
                        .Select(g => new
                        {
                            JobName = g.Key.JobName,
                            IdJobPostings = g.Key.IdJobPostings,
                            Total = g.Count()
                            // Các trường dữ liệu khác có thể thêm vào ở đây nếu cần
                        })
                        .ToList();

                    // Tạo series mới cho biểu đồ spline
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Column; // Đổi loại biểu đồ thành spline

                    // Thêm dữ liệu vào series
                    foreach (var data in lichPhongVanList)
                    {
                        // Thêm điểm dữ liệu với JobName làm trục x và số lượng làm trục y
                        series.Points.AddXY(data.JobName, data.Total);
                        series.Palette = ChartColorPalette.BrightPastel;
                    }

                    // Xóa dữ liệu cũ trong series
                    c.Series.Clear();

                    // Thêm series vào biểu đồ
                    c.Series.Add(series);
                    // Ẩn cột series
                    series.IsVisibleInLegend = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void thucThi_load_BieuDoCot_BangTin(Chart c)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var lichPhongVanList = dbContext.JobPostings
                        .Join(dbContext.Applications, // Bảng Applications
                            jp => jp.IdJobPostings, // Key của bảng JobPostings
                            app => app.IdJobPostings, // Key của bảng Applications
                            (jp, app) => jp) // Kết hợp các dữ liệu từ hai bảng và chọn JobPostings
                        .GroupBy(jp => jp.Job) // Gom nhóm theo Job
                        .Select(g => new
                        {
                            Job = g.Key,
                            Total = g.Count()
                            // Các trường dữ liệu khác có thể thêm vào ở đây nếu cần
                        })
                        .ToList();


                    // Tạo series mới cho biểu đồ spline
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Column; // Đổi loại biểu đồ thành spline

                    // Thêm dữ liệu vào series
                    foreach (var data in lichPhongVanList)
                    {
                        // Thêm điểm dữ liệu với JobName làm trục x và số lượng làm trục y
                        series.Points.AddXY(data.Job, data.Total);
                        series.Palette = ChartColorPalette.BrightPastel;
                    }

                    // Xóa dữ liệu cũ trong series
                    c.Series.Clear();

                    // Thêm series vào biểu đồ
                    c.Series.Add(series);
                    // Ẩn cột series
                    series.IsVisibleInLegend = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
