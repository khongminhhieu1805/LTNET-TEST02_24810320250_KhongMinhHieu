using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace bai2
{
    public partial class Form1 : Form
    {
        private BindingList<BookModel> _bookList = new BindingList<BookModel>();
        private BindingSource _bindingSource = new BindingSource();
        private int _autoIncrementId = 1;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Hệ thống Quản lý Tài liệu Sách & Báo cáo Nhà sách";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThietLapThoiGianThuc();
            ThietLapGridBangCode();
            ThietLapDataBinding2Chieu();
            NapDuLieuMau();
            LamMoiForm();
            CapNhatStatusStrip();
        }

        private void ThietLapThoiGianThuc()
        {
            timer1.Interval = 1000;
            timer1.Tick += (s, ev) =>
            {
                lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            timer1.Start();
        }

        private void ThietLapGridBangCode()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();

            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.ReadOnly = true;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookId", HeaderText = "Mã Sách", Width = 80 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Tên Sách", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Author", HeaderText = "Tác Giả", Width = 140 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PublishYear", HeaderText = "Năm XB", Width = 80 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn Giá", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL Kho", Width = 80 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Tổng Tiền", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ImagePath", HeaderText = "Đường Dẫn Ảnh", Width = 150 });
        }

        private void ThietLapDataBinding2Chieu()
        {
            _bindingSource.DataSource = _bookList;
            dgvBooks.DataSource = _bindingSource;

            txtBookId.DataBindings.Clear();
            txtBookTitle.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();
            nudPublishYear.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            nudQuantity.DataBindings.Clear();
            txtImagePath.DataBindings.Clear();

            txtBookId.DataBindings.Add("Text", _bindingSource, "BookId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBookTitle.DataBindings.Add("Text", _bindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAuthor.DataBindings.Add("Text", _bindingSource, "Author", true, DataSourceUpdateMode.OnPropertyChanged);
            nudPublishYear.DataBindings.Add("Value", _bindingSource, "PublishYear", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding priceBinding = new Binding("Text", _bindingSource, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            priceBinding.Format += (s, e) => { if (e.Value is decimal val) e.Value = val.ToString("0.#"); };
            txtPrice.DataBindings.Add(priceBinding);

            nudQuantity.DataBindings.Add("Value", _bindingSource, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            txtImagePath.DataBindings.Add("Text", _bindingSource, "ImagePath", true, DataSourceUpdateMode.OnPropertyChanged);

            _bindingSource.CurrentChanged += (s, e) =>
            {
                if (_bindingSource.Current is BookModel book)
                {
                    HienThiAnhBia(book.ImagePath);
                }
                else
                {
                    picBookCover.Image = null;
                }
            };
        }

        private void NapDuLieuMau()
        {
            _bookList.Add(new BookModel(TaoMaTuDong(), "Lập trình C# WinForms Nâng Cao", "Nguyễn Hữu Trường", 2026, 150000, 50, ""));
            _bookList.Add(new BookModel(TaoMaTuDong(), "Phân tích Bảo mật Hệ thống SCADA", "Trường Blue", 2026, 220000, 30, ""));
        }

        private string TaoMaTuDong()
        {
            return $"MS{_autoIncrementId++:D3}";
        }

        private void CapNhatStatusStrip()
        {
            int totalBooks = _bookList.Sum(b => b.Quantity);
            decimal totalValue = _bookList.Sum(b => b.TotalAmount);

            lblTotalBooks.Text = $"Tổng số đầu sách: {_bookList.Count} ({totalBooks} cuốn)";
            lblTotalValue.Text = $"Tổng giá trị kho: {totalValue:N0} VNĐ";
        }

        private void HienThiAnhBia(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(imagePath)))
                    {
                        picBookCover.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    picBookCover.Image = null;
                }
            }
            catch
            {
                picBookCover.Image = null;
            }
        }

        private bool KiemTraHopLe()
        {
            bool isValid = true;
            epInput.Clear();

            if (string.IsNullOrWhiteSpace(txtBookTitle.Text.Trim()))
            {
                epInput.SetError(txtBookTitle, "Tên sách không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text.Trim()))
            {
                epInput.SetError(txtAuthor, "Tác giả không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text.Trim()) || !decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                epInput.SetError(txtPrice, "Đơn giá phải là số nguyên dương!");
                isValid = false;
            }

            return isValid;
        }

        private void LamMoiForm()
        {
            txtBookId.Text = $"MS{_autoIncrementId:D3}";
            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            nudPublishYear.Value = 2026;
            txtPrice.Text = "";
            nudQuantity.Value = 1;
            txtImagePath.Text = "";
            picBookCover.Image = null;
            epInput.Clear();
            dgvBooks.ClearSelection();
        }
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh bìa sách";
                ofd.Filter = "Tệp ảnh (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg|Tất cả tệp (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    HienThiAnhBia(ofd.FileName);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            string idMoi = TaoMaTuDong();
            BookModel bookMoi = new BookModel(
                idMoi,
                txtBookTitle.Text.Trim(),
                txtAuthor.Text.Trim(),
                (int)nudPublishYear.Value,
                decimal.Parse(txtPrice.Text.Trim()),
                (int)nudQuantity.Value,
                txtImagePath.Text.Trim()
            );

            _bookList.Add(bookMoi);
            _bindingSource.MoveLast();
            CapNhatStatusStrip();
            MessageBox.Show($"Thêm thành công sách [{idMoi}] - {bookMoi.Title}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookModel currentBook)
            {
                if (!KiemTraHopLe()) return;

                _bindingSource.ResetCurrentItem();
                CapNhatStatusStrip();
                MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookModel currentBook)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sách [{currentBook.BookId}] - {currentBook.Title}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dr == DialogResult.Yes)
                {
                    _bookList.Remove(currentBook);
                    LamMoiForm();
                    CapNhatStatusStrip();
                    MessageBox.Show("Đã xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void mnuOpenCsv_Click(object sender, EventArgs e)
        {
            btnToolOpen_Click(sender, e);
        }

        private void btnToolOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Mở file danh sách sách";
                ofd.Filter = "CSV File (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                        if (lines.Length <= 1)
                        {
                            MessageBox.Show("File CSV không chứa dữ liệu hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _bookList.Clear();

                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i].Trim();
                            if (string.IsNullOrEmpty(line)) continue;

                            string[] parts = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                            if (parts.Length >= 7)
                            {
                                string id = parts[0].Trim('"');
                                string title = parts[1].Trim('"');
                                string author = parts[2].Trim('"');
                                int year = int.TryParse(parts[3], out int y) ? y : 2026;
                                decimal price = decimal.TryParse(parts[4], out decimal p) ? p : 0;
                                int qty = int.TryParse(parts[5], out int q) ? q : 0;
                                string img = parts[6].Trim('"');

                                _bookList.Add(new BookModel(id, title, author, year, price, qty, img));
                            }
                        }

                        _bindingSource.ResetBindings(false);
                        CapNhatStatusStrip();
                        MessageBox.Show($"Đã nạp thành công {_bookList.Count} đầu sách từ file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void mnuSaveCsv_Click(object sender, EventArgs e)
        {
            btnToolSave_Click(sender, e);
        }

        private void btnToolSave_Click(object sender, EventArgs e)
        {
            if (_bookList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu sách để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu báo cáo danh sách sách";
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"BaoCaoNhaSach_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("BookId,Title,Author,PublishYear,Price,Quantity,ImagePath");

                        foreach (var b in _bookList)
                        {
                            sb.AppendLine($"\"{b.BookId}\",\"{b.Title}\",\"{b.Author}\",{b.PublishYear},{b.Price},{b.Quantity},\"{b.ImagePath}\"");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất dữ liệu danh sách sách ra CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void btnToolAdd_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm nhanh đang mở sẵn trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public class BookModel : INotifyPropertyChanged
        {
            private string _bookId;
            private string _title;
            private string _author;
            private int _publishYear;
            private decimal _price;
            private int _quantity;
            private string _imagePath;

            public string BookId
            {
                get => _bookId;
                set { _bookId = value; OnPropertyChanged(nameof(BookId)); }
            }

            public string Title
            {
                get => _title;
                set { _title = value; OnPropertyChanged(nameof(Title)); }
            }

            public string Author
            {
                get => _author;
                set { _author = value; OnPropertyChanged(nameof(Author)); }
            }

            public int PublishYear
            {
                get => _publishYear;
                set { _publishYear = value; OnPropertyChanged(nameof(PublishYear)); }
            }

            public decimal Price
            {
                get => _price;
                set { _price = value; OnPropertyChanged(nameof(Price)); }
            }

            public int Quantity
            {
                get => _quantity;
                set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
            }

            public string ImagePath
            {
                get => _imagePath;
                set { _imagePath = value; OnPropertyChanged(nameof(ImagePath)); }
            }

            public decimal TotalAmount => Price * Quantity;

            public BookModel() { }

            public BookModel(string id, string title, string author, int year, decimal price, int quantity, string imagePath)
            {
                BookId = id;
                Title = title;
                Author = author;
                PublishYear = year;
                Price = price;
                Quantity = quantity;
                ImagePath = imagePath;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void txtBookId_TextChanged(object sender, EventArgs e) { }
        private void nudPublishYear_ValueChanged(object sender, EventArgs e) { }
        private void nudQuantity_ValueChanged(object sender, EventArgs e) { }
        private void picBookCover_Click(object sender, EventArgs e) { }
        private void txtImagePath_TextChanged(object sender, EventArgs e) { }
        private void lblTotalBooks_Click(object sender, EventArgs e) { }
        private void lblTotalValue_Click(object sender, EventArgs e) { }
        private void lblClock_Click(object sender, EventArgs e) { }
    }
}