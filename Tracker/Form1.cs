using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Tracker
{
    public partial class Form1 : Form
    {
        private List<ResellItem> items = new List<ResellItem>();
        private List<double> bumpHistory = new List<double>();
        private DataManager dataManager = new DataManager();

        private readonly string placeholderName = "Item Name";
        private readonly string placeholderBuy = "Buy Price";
        private readonly string placeholderSell = "Sell Price";
        private readonly string placeholderFees = "Fees";
        private readonly string placeholderShipping = "Shipping";
        private readonly string placeholderBumps = "Bumps";

        private readonly Color AppBg = Color.FromArgb(14, 14, 15);
        private readonly Color TopPanelBg = Color.FromArgb(24, 24, 28);
        private readonly Color Surface = Color.FromArgb(24, 24, 28);
        private readonly Color Surface2 = Color.FromArgb(30, 30, 36);
        private readonly Color Accent = Color.FromArgb(120, 80, 255);
        private readonly Color AccentHover = Color.FromArgb(145, 110, 255);
        private readonly Color Danger = Color.FromArgb(210, 70, 90);
        private readonly Color TextMain = Color.FromArgb(235, 235, 245);
        private readonly Color TextMuted = Color.FromArgb(155, 155, 175);
        private readonly Color GridLine = Color.FromArgb(60, 60, 75);
        private readonly Color Warning = Color.FromArgb(255, 140, 70);
        private readonly Color WarningHover = Color.FromArgb(255, 160, 95);

        public Form1()
        {
            InitializeComponent();

            this.Text = "Plutus";
            this.BackColor = AppBg;
            this.ForeColor = TextMain;
            this.StartPosition = FormStartPosition.CenterScreen;

            SetupPlaceholders();

            items = dataManager.Load();
            bumpHistory = dataManager.LoadBumps();

            SetupGrid();
            ApplyTheme();

            gridItems.CellEndEdit += gridItems_CellEndEdit;
            gridItems.CellParsing += gridItems_CellParsing;
            gridItems.DataError += gridItems_DataError;
            txtBumps.KeyDown += txtBumps_KeyDown;

            RefreshGrid();
            UpdateStats();
        }

        private void SetupGrid()
        {
            gridItems.AutoGenerateColumns = true;
            gridItems.AllowUserToAddRows = false;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.MultiSelect = false;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridItems.RowTemplate.Height = 32;
        }
        private void WarningButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = WarningHover;
        }

        private void WarningButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Warning;
        }
        private void StyleWarningButton(Button button)
        {
            button.BackColor = Warning;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            button.MouseEnter -= WarningButton_MouseEnter;
            button.MouseLeave -= WarningButton_MouseLeave;
            button.MouseEnter += WarningButton_MouseEnter;
            button.MouseLeave += WarningButton_MouseLeave;
        }

        private void ApplyTheme()
        {
            this.BackColor = AppBg;
            this.ForeColor = TextMain;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            StylePrimaryButton(btnAdd);
            StyleDangerButton(btnDelete);
            StyleWarningButton(btnUndoBump);
            StyleTopButton(button1);
            StyleTopButton(button2);

            StyleTextBox(txtName);
            StyleTextBox(txtBuy);
            StyleTextBox(txtSell);
            StyleTextBox(txtFees);
            StyleTextBox(txtShipping);
            StyleTextBox(txtBumps);

            lblGrossProfit.ForeColor = TextMain;
            lblGrossProfit.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);

            lblTotalBumps.ForeColor = TextMain;
            lblTotalBumps.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);

            lblNetProfit.ForeColor = TextMain;
            lblNetProfit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            gridItems.BackgroundColor = Surface;
            gridItems.BorderStyle = BorderStyle.None;
            gridItems.GridColor = GridLine;
            gridItems.EnableHeadersVisualStyles = false;
            gridItems.RowHeadersVisible = false;

            gridItems.DefaultCellStyle.BackColor = Surface;
            gridItems.DefaultCellStyle.ForeColor = TextMain;
            gridItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 45, 110);
            gridItems.DefaultCellStyle.SelectionForeColor = TextMain;
            gridItems.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            gridItems.ColumnHeadersDefaultCellStyle.BackColor = Surface2;
            gridItems.ColumnHeadersDefaultCellStyle.ForeColor = TextMain;
            gridItems.ColumnHeadersDefaultCellStyle.SelectionBackColor = Surface2;
            gridItems.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextMain;
            gridItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gridItems.ColumnHeadersHeight = 38;

            button1.BackColor = TopPanelBg;
            button2.BackColor = TopPanelBg;
            topPanel.BackColor = TopPanelBg;
            label1.ForeColor = Color.White;
        }

        private void StylePrimaryButton(Button button)
        {
            button.BackColor = Accent;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            button.MouseEnter -= PrimaryButton_MouseEnter;
            button.MouseLeave -= PrimaryButton_MouseLeave;
            button.MouseEnter += PrimaryButton_MouseEnter;
            button.MouseLeave += PrimaryButton_MouseLeave;
        }

        private void StyleDangerButton(Button button)
        {
            button.BackColor = Danger;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            button.MouseEnter -= DangerButton_MouseEnter;
            button.MouseLeave -= DangerButton_MouseLeave;
            button.MouseEnter += DangerButton_MouseEnter;
            button.MouseLeave += DangerButton_MouseLeave;
        }

        private void StyleSecondaryButton(Button button)
        {
            button.BackColor = Surface2;
            button.ForeColor = TextMain;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            button.MouseEnter -= SecondaryButton_MouseEnter;
            button.MouseLeave -= SecondaryButton_MouseLeave;
            button.MouseEnter += SecondaryButton_MouseEnter;
            button.MouseLeave += SecondaryButton_MouseLeave;
        }

        private void StyleTopButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.ForeColor = Color.White;
            button.BackColor = AppBg;
            button.Cursor = Cursors.Hand;
        }

        private void StyleTextBox(TextBox box)
        {
            box.BackColor = Surface;
            box.ForeColor = TextMain;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 10F);
        }

        private void PrimaryButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = AccentHover;
        }

        private void PrimaryButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Accent;
        }

        private void DangerButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(225, 85, 105);
        }

        private void DangerButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Danger;
        }

        private void SecondaryButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(45, 45, 55);
        }

        private void SecondaryButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Surface2;
        }

        private void RefreshGrid()
        {
            gridItems.DataSource = null;
            gridItems.DataSource = items;

            if (gridItems.Columns["Profit"] != null)
                gridItems.Columns["Profit"].ReadOnly = true;

            if (gridItems.Columns["Date"] != null)
                gridItems.Columns["Date"].ReadOnly = true;

            if (gridItems.Columns["Profit"] != null)
                gridItems.Columns["Profit"].DefaultCellStyle.Format = "0.00€";

            if (gridItems.Columns["BuyPrice"] != null)
                gridItems.Columns["BuyPrice"].DefaultCellStyle.Format = "0.00€";

            if (gridItems.Columns["SellPrice"] != null)
                gridItems.Columns["SellPrice"].DefaultCellStyle.Format = "0.00€";

            if (gridItems.Columns["Fees"] != null)
                gridItems.Columns["Fees"].DefaultCellStyle.Format = "0.00€";

            if (gridItems.Columns["Shipping"] != null)
                gridItems.Columns["Shipping"].DefaultCellStyle.Format = "0.00€";
        }

        private bool TryParseMoney(string text, out double value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(text))
                return false;

            text = text.Replace("€", "").Trim();

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                return true;

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                return true;

            string normalized = text.Replace(",", ".");
            return double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private double GetTotalBumps()
        {
            return bumpHistory.Sum();
        }

        private void UpdateStats()
        {
            double grossProfit = items.Sum(x => x.Profit);
            double bumps = GetTotalBumps();
            double netProfit = grossProfit - bumps;

            lblGrossProfit.Text = $"Gross Profit: {grossProfit:0.00}€";
            lblTotalBumps.Text = $"Bumps: {bumps:0.00}€";
            lblNetProfit.Text = $"Net Profit: {netProfit:0.00}€";

            lblNetProfit.ForeColor = netProfit < 0 ? Danger : TextMain;
            btnUndoBump.Enabled = bumpHistory.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsPlaceholderOrEmpty(txtName, placeholderName))
            {
                MessageBox.Show("Please enter the item name.");
                return;
            }

            if (!TryParseMoney(GetRealText(txtBuy, placeholderBuy), out double buyPrice))
            {
                MessageBox.Show("Please enter a valid buy price.");
                return;
            }

            double sell = ParseOptional(txtSell, placeholderSell);
            double fees = ParseOptional(txtFees, placeholderFees);
            double shipping = ParseOptional(txtShipping, placeholderShipping);

            ResellItem item = new ResellItem
            {
                Name = txtName.Text.Trim(),
                BuyPrice = buyPrice,
                SellPrice = sell,
                Fees = fees,
                Shipping = shipping,
                Date = DateTime.Now
            };

            items.Add(item);

            dataManager.Save(items);
            RefreshGrid();
            UpdateStats();
            ResetItemPlaceholders();
        }

        private double ParseOptional(TextBox box, string placeholder)
        {
            string text = GetRealText(box, placeholder);

            if (string.IsNullOrWhiteSpace(text))
                return 0;

            if (TryParseMoney(text, out double value))
                return value;

            return 0;
        }

        private void AddBumpFromTextbox()
        {
            string text = GetRealText(txtBumps, placeholderBumps);

            if (string.IsNullOrWhiteSpace(text))
                return;

            if (!TryParseMoney(text, out double bumpValue))
            {
                MessageBox.Show("Please enter a valid bump value.");
                return;
            }

            if (bumpValue <= 0)
            {
                MessageBox.Show("Bump value must be greater than 0.");
                return;
            }

            bumpHistory.Add(bumpValue);
            dataManager.SaveBumps(bumpHistory);

            UpdateStats();
            ResetBumpsPlaceholder();
        }

        private void ResetBumpsPlaceholder()
        {
            txtBumps.Text = placeholderBumps;
            txtBumps.ForeColor = TextMuted;
        }

        private void btnUndoBump_Click(object sender, EventArgs e)
        {
            if (bumpHistory.Count == 0)
                return;

            bumpHistory.RemoveAt(bumpHistory.Count - 1);
            dataManager.SaveBumps(bumpHistory);
            UpdateStats();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridItems.CurrentRow == null)
                return;

            int index = gridItems.CurrentRow.Index;

            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);

                dataManager.Save(items);
                RefreshGrid();
                UpdateStats();
            }
        }

        private void gridItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataManager.Save(items);
            UpdateStats();
        }

        private void gridItems_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.Value == null)
                return;

            string column = gridItems.Columns[e.ColumnIndex].Name;

            if (column == "BuyPrice" || column == "SellPrice" || column == "Fees" || column == "Shipping")
            {
                string text = e.Value.ToString().Trim();

                if (string.IsNullOrWhiteSpace(text))
                {
                    e.Value = 0d;
                    e.ParsingApplied = true;
                    return;
                }

                if (TryParseMoney(text, out double val))
                {
                    e.Value = val;
                    e.ParsingApplied = true;
                }
            }
        }

        private void gridItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void txtBumps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                AddBumpFromTextbox();
            }
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(txtName, placeholderName);
            SetPlaceholder(txtBuy, placeholderBuy);
            SetPlaceholder(txtSell, placeholderSell);
            SetPlaceholder(txtFees, placeholderFees);
            SetPlaceholder(txtShipping, placeholderShipping);
            SetPlaceholder(txtBumps, placeholderBumps);
        }

        private void SetPlaceholder(TextBox box, string text)
        {
            box.Text = text;
            box.ForeColor = TextMuted;

            box.Enter += (s, e) =>
            {
                if (box.Text == text)
                {
                    box.Text = "";
                    box.ForeColor = TextMain;
                }
            };

            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = text;
                    box.ForeColor = TextMuted;
                }
            };
        }

        private bool IsPlaceholderOrEmpty(TextBox box, string placeholder)
        {
            return string.IsNullOrWhiteSpace(box.Text) || box.Text == placeholder;
        }

        private string GetRealText(TextBox box, string placeholder)
        {
            if (box.Text == placeholder)
                return "";

            return box.Text.Trim();
        }

        private void ResetItemPlaceholders()
        {
            txtName.Text = placeholderName;
            txtName.ForeColor = TextMuted;

            txtBuy.Text = placeholderBuy;
            txtBuy.ForeColor = TextMuted;

            txtSell.Text = placeholderSell;
            txtSell.ForeColor = TextMuted;

            txtFees.Text = placeholderFees;
            txtFees.ForeColor = TextMuted;

            txtShipping.Text = placeholderShipping;
            txtShipping.ForeColor = TextMuted;

            txtName.Focus();
        }

        private void lblGrossProfit_Click(object sender, EventArgs e) { }
        private void lblTotalBumps_Click(object sender, EventArgs e) { }
        private void lblNetProfit_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}