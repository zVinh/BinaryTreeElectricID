using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BinaryTreeElectricID
{
    public partial class Form1 : Form
    {
        // ================= HASH =================
        private string Hash(string input)
        {
            using SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        // ================= NODE =================
        public class Node
        {
            public string Username;
            public string Password;
            public Node? Left;
            public Node? Right;
            public int Height;
            public Node(string u, string p) 
            {
                Username = u;
                Password = p; 
                 Height = 1;
            }
        }

        private Node? root = null;
        private string filePath;

        // Highlight: tìm node và hiển thị đường đi
        private string highlightUser = "";
        private HashSet<string> highlightPath = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public Form1()
        {
            InitializeComponent();
            filePath = Path.Combine(Application.StartupPath, "users.txt");
        }

        // ================= AVL CORE =================
        private int Height(Node? n) => n == null ? 0 : n.Height;
        private int Balance(Node? n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

        private Node RotateRight(Node y)
        {
            Node x = y.Left!;
            Node? t2 = x.Right;
            x.Right = y;
            y.Left = t2;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right!; 
            Node? t2 = y.Left;
            y.Left = x; x.Right = t2;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            return y;
        }

        private Node Rebalance(Node node, string u)
        {
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int bal = Balance(node);
            // LL
            if (bal > 1 && string.Compare(u, node.Left!.Username, StringComparison.OrdinalIgnoreCase) < 0) return RotateRight(node);
            // RR
            if (bal < -1 && string.Compare(u, node.Right!.Username, StringComparison.OrdinalIgnoreCase) > 0) return RotateLeft(node);
            // LR
            if (bal > 1 && string.Compare(u, node.Left!.Username, StringComparison.OrdinalIgnoreCase) > 0) { node.Left = RotateLeft(node.Left); return RotateRight(node); }
            // RL
            if (bal < -1 && string.Compare(u, node.Right!.Username, StringComparison.OrdinalIgnoreCase) < 0) { node.Right = RotateRight(node.Right); return RotateLeft(node); }
            return node;
        }

        private Node Add(Node? node, string u, string p, out bool ok)
        {
            if (node == null) { ok = true; return new Node(u, Hash(p)); }
            int cmp = string.Compare(u, node.Username, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) { ok = false; return node; }
            else if (cmp < 0) node.Left = Add(node.Left, u, p, out ok);
            else node.Right = Add(node.Right, u, p, out ok);
            return Rebalance(node, u);
        }

        private Node MinValue(Node n) { while (n.Left != null) n = n.Left; return n; }

        private Node? Delete(Node? node, string u, out bool ok)
        {
            if (node == null) { ok = false; return null; }
            int cmp = string.Compare(u, node.Username, StringComparison.OrdinalIgnoreCase);
            if (cmp < 0) node.Left = Delete(node.Left, u, out ok);
            else if (cmp > 0) node.Right = Delete(node.Right, u, out ok);
            else
            {
                ok = true;
                if (node.Left == null || node.Right == null) return node.Left ?? node.Right;
                Node m = MinValue(node.Right);
                node.Username = m.Username; node.Password = m.Password;
                node.Right = Delete(node.Right, m.Username, out _);
            }
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int bal = Balance(node);
            if (bal > 1 && Balance(node.Left) >= 0) return RotateRight(node);
            if (bal > 1 && Balance(node.Left) < 0) { node.Left = RotateLeft(node.Left!); return RotateRight(node); }
            if (bal < -1 && Balance(node.Right) <= 0) return RotateLeft(node);
            if (bal < -1 && Balance(node.Right) > 0) { node.Right = RotateRight(node.Right!); return RotateLeft(node); }
            return node;
        }

        // ================= LOGIN =================
        private bool Login(Node? node, string u, string p)
        {
            if (node == null) return false;
            int cmp = string.Compare(u, node.Username, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) return node.Password == Hash(p);
            return cmp < 0 ? Login(node.Left, u, p) : Login(node.Right, u, p);
        }

        // ================= SEARCH =================
        private bool Search(Node? node, string u, List<string> path)
        {
            if (node == null) return false;
            path.Add(node.Username);
            int cmp = string.Compare(u, node.Username, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) return true;
            if (cmp < 0) return Search(node.Left, u, path);
            return Search(node.Right, u, path);
        }

        // ================= BUTTON HANDLERS =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim(), p = txtPass.Text.Trim();
            if (u == "" || p == "") { SetStatus("❌ Nhập đầy đủ Username và Password", Color.FromArgb(200, 50, 50)); return; }
            if (!ValidateUsername(u)) return;
            bool ok; root = Add(root, u, p, out ok);
            if (ok) { SaveAll(); SetStatus("✔ Thêm tài khoản thành công: " + u, Color.FromArgb(34, 139, 34)); }
            else { SetStatus("❌ Tài khoản đã tồn tại: " + u, Color.FromArgb(200, 50, 50)); }
            txtUser.Clear(); txtPass.Clear();
            panelTree.Invalidate();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim(), p = txtPass.Text.Trim();
            if (u == "" || p == "") { SetStatus("❌ Nhập đầy đủ thông tin", Color.FromArgb(200, 50, 50)); return; }
            if (!ValidateUsername(u)) return;
            bool ok = Login(root, u, p);
            SetStatus(ok ? "✔ Đăng nhập thành công — Chào mừng " + u : "❌ Sai tài khoản hoặc mật khẩu",
                      ok ? Color.FromArgb(34, 139, 34) : Color.FromArgb(200, 50, 50));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            if (u == "") { SetStatus("❌ Nhập username để xóa", Color.FromArgb(200, 50, 50)); return; }
            if (!ValidateUsername(u)) return;
            bool ok; root = Delete(root, u, out ok);
            if (ok) { SaveAll(); panelTree.Invalidate(); SetStatus("✔ Xóa tài khoản thành công: " + u, Color.FromArgb(34, 139, 34)); }
            else { SetStatus("❌ Không tìm thấy tài khoản: " + u, Color.FromArgb(200, 50, 50)); }
            highlightUser = ""; highlightPath.Clear(); panelTree.Invalidate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "") { SetStatus("❌ Nhập username để tìm kiếm", Color.FromArgb(200, 50, 50)); return; }
            if (!ValidateUsername(keyword)) return;

            var path = new List<string>();
            Stopwatch sw = Stopwatch.StartNew();
            bool found = Search(root, keyword, path);
            sw.Stop();

            highlightPath.Clear();
            if (found)
            {
                highlightUser = keyword;
                foreach (string s in path) highlightPath.Add(s);
                SetStatus($"✔ Tìm thấy '{keyword}' — Đường đi: {string.Join(" → ", path)} ({sw.Elapsed.TotalMilliseconds:F4} ms)",
                          Color.FromArgb(0, 100, 180));
            }
            else
            {
                highlightUser = "";
                SetStatus($"❌ Không tìm thấy '{keyword}'", Color.FromArgb(200, 50, 50));
            }
            panelTree.Invalidate();
        }

        // ================= ANALYZE ================
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            btnAnalyze.Enabled = false;
            SetStatus("⏳ Đang phân tích hiệu năng...", Color.Gray);
            Application.DoEvents();

            int n = 10000;
            int warmup = 200;
            int rounds = 1000;

            // Build isolated test tree
            Node? tree = null;
            for (int i = 0; i < n; i++) { bool ok; tree = Add(tree, "User" + i, "pass", out ok); }

            // Warm up JIT
            for (int i = 0; i < warmup; i++) Login(tree, "User" + (n / 2), "pass");

            // BEST CASE: root node (1 comparison, O(1) depth)
            string rootName = tree!.Username;
            long t0 = Stopwatch.GetTimestamp();
            for (int i = 0; i < rounds; i++) Login(tree, rootName, "pass");
            long t1 = Stopwatch.GetTimestamp();
            double bestMs = (t1 - t0) * 1000.0 / Stopwatch.Frequency / rounds;

            // WORST CASE: deepest leaf (max depth = ⌊log₂ n⌋)
            string deepest = FindDeepestNode(tree);
            long t2 = Stopwatch.GetTimestamp();
            for (int i = 0; i < rounds; i++) Login(tree, deepest, "pass");
            long t3 = Stopwatch.GetTimestamp();
            double worstMs = (t3 - t2) * 1000.0 / Stopwatch.Frequency / rounds;

            // AVERAGE CASE: random uniform sampling
            var rnd = new Random(42);
            long t4 = Stopwatch.GetTimestamp();
            for (int i = 0; i < rounds; i++) Login(tree, "User" + rnd.Next(0, n), "pass");
            long t5 = Stopwatch.GetTimestamp();
            double avgMs = (t5 - t4) * 1000.0 / Stopwatch.Frequency / rounds;

            int treeHeight = Height(tree);
            int theoreticalMaxH = (int)Math.Ceiling(1.44 * Math.Log(n + 2, 2));

            SetStatus(
                $"Best (root): {bestMs:F6} ms | Avg (random): {avgMs:F6} ms | Worst (depth {treeHeight}): {worstMs:F6} ms" +
                $"  |  n={n}, {rounds} lần đo  |  Chiều cao cây: {treeHeight} (lý thuyết ≤ {theoreticalMaxH})",
                Color.FromArgb(0, 100, 180));

            btnAnalyze.Enabled = true;
        }

        // Tìm node sâu nhất trong cây
        private string FindDeepestNode(Node? node)
        {
            string deepest = "";
            int maxDepth = -1;
            FindDeepest(node, 0, ref deepest, ref maxDepth);
            return deepest;
        }
        private void FindDeepest(Node? node, int depth, ref string deepest, ref int maxDepth)
        {
            if (node == null) return;
            if (depth > maxDepth) { maxDepth = depth; deepest = node.Username; }
            FindDeepest(node.Left, depth + 1, ref deepest, ref maxDepth);
            FindDeepest(node.Right, depth + 1, ref deepest, ref maxDepth);
        }

        // ================= DRAW TREE =================
        private static readonly Color ColorNormal   = Color.FromArgb(30, 120, 210);
        private static readonly Color ColorPath     = Color.FromArgb(30, 160, 140);  // teal: đường đi
        private static readonly Color ColorFound    = Color.FromArgb(240, 140, 0);   // cam: node tìm thấy
        private static readonly Color ColorEdgePath = Color.FromArgb(30, 160, 140);
        private static readonly Color ColorEdge     = Color.FromArgb(150, 160, 175);

        private void Draw(Graphics g, Node node, int x, int y, int offset, Node? parent, int px, int py)
        {
            const int nodeW = 54, nodeH = 34, spaceY = 75;

            // Xác định màu
            bool isFound = node.Username.Equals(highlightUser, StringComparison.OrdinalIgnoreCase);
            bool isOnPath = !isFound && highlightPath.Contains(node.Username);
            Color fill = isFound ? ColorFound : (isOnPath ? ColorPath : ColorNormal);

            // Vẽ cạnh trước (dưới node)
            if (parent != null)
            {
                bool edgeOnPath = isOnPath || isFound;
                using Pen pen = new Pen(edgeOnPath ? ColorEdgePath : ColorEdge, edgeOnPath ? 2f : 1.5f);
                g.DrawLine(pen, px + nodeW / 2, py + nodeH, x + nodeW / 2, y);
            }

            // Shadow
            using (Brush sh = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                g.FillEllipse(sh, x + 2, y + 2, nodeW, nodeH);

            // Fill
            using (Brush br = new SolidBrush(fill))
                g.FillEllipse(br, x, y, nodeW, nodeH);

            // Border
            using (Pen bp = new Pen(Color.FromArgb(isFound ? 220 : 255, Color.White), isFound ? 2.5f : 1.5f))
                g.DrawEllipse(bp, x, y, nodeW, nodeH);

            // Text — chọn font size phù hợp độ dài tên
            int nameLen = node.Username.Length;
            float fontSize = nameLen <= 5 ? 9f : nameLen <= 8 ? 8f : 7f;
            using Font f = new Font("Segoe UI", fontSize, FontStyle.Bold);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(node.Username, f, Brushes.White, new RectangleF(x, y, nodeW, nodeH), sf);

            int half = Math.Max(offset / 2, 30);
            if (node.Left != null)
                Draw(g, node.Left, x - offset, y + spaceY, half, node, x, y);
            if (node.Right != null)
                Draw(g, node.Right, x + offset, y + spaceY, half, node, x, y);
        }

        private void panelTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (root != null)
                Draw(e.Graphics, root, panelTree.Width / 2 - 27, 14, 200, null, 0, 0);

            // Legend khi có highlight
            if (highlightPath.Count > 0)
            {
                using Font lf = new Font("Segoe UI", 8.5f);
                g_DrawLegend(e.Graphics, lf);
            }
        }

        private void g_DrawLegend(Graphics g, Font f)
        {
            int lx = 12, ly = panelTree.Height - 52;
            using (Brush bg = new SolidBrush(Color.FromArgb(200, 240, 244, 250)))
                g.FillRoundedRectangle(bg, lx, ly, 240, 40, 6);
            using Pen bp = new Pen(Color.FromArgb(180, 200, 215), 1);
            g.DrawRoundedRectangle(bp, lx, ly, 240, 40, 6);

            using (Brush b = new SolidBrush(ColorPath))   g.FillEllipse(b, lx + 10, ly + 10, 14, 14);
            using (Brush b = new SolidBrush(ColorFound))  g.FillEllipse(b, lx + 10, ly + 24, 14, 14);
            g.DrawString("Đường đi tìm kiếm", f, Brushes.DimGray, lx + 28, ly + 8);
            g.DrawString("Node tìm thấy", f, Brushes.DimGray, lx + 28, ly + 22);
        }

        // ================= LOAD / SAVE =================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFromFile();
            if (root == null)
            {
                // Tên tiếng Việt đầy đủ dấu
                string[] users = { "Minh", "Giang", "Tuấn", "Dũng", "Khánh", "Phúc", "Vinh", "Bảo", "Huy", "Long", "Nguyên", "Quang", "Sơn", "Tiến", "Yến", "Ngọc" };
                int i = 1;
                foreach (var u in users) { bool ok; root = Add(root, u, "admin" + i++, out ok); }
                SaveAll();
            }
        }

        private void SaveToFile(Node? node, StreamWriter w)
        {
            if (node == null) return;
            w.WriteLine(node.Username + "|" + node.Password);
            SaveToFile(node.Left, w);
            SaveToFile(node.Right, w);
        }

        private void SaveAll()
        {
            using StreamWriter w = new StreamWriter(filePath, false, new UTF8Encoding(true));
            SaveToFile(root, w);
        }

        private Node InsertHashed(Node? node, string u, string hashed, out bool ok)
        {
            if (node == null) { ok = true; return new Node(u, hashed); }
            int cmp = string.Compare(u, node.Username, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) { ok = false; return node; }
            else if (cmp < 0) node.Left = InsertHashed(node.Left, u, hashed, out ok);
            else node.Right = InsertHashed(node.Right, u, hashed, out ok);
            return Rebalance(node, u);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;
            try
            {
                foreach (var line in File.ReadAllLines(filePath, Encoding.UTF8))
                {
                    var p = line.Split('|');
                    if (p.Length == 2) { bool ok; root = InsertHashed(root, p[0], p[1], out ok); }
                }
            }
            catch { MessageBox.Show("Lỗi đọc file!"); }
        }

        // ================= Hỗ trợ =================
        private void SetStatus(string msg, Color color)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = color;
        }

        private bool isShow = false;
        private void btnShowPass_Click(object sender, EventArgs e)
        {
            isShow = !isShow;
            txtPass.UseSystemPasswordChar = !isShow;
            btnShowPass.Text = isShow ? "Hide" : "Show";
        }

        private void lblStatus_Click(object sender, EventArgs e) { }

        // ================= VALIDATE =================
        private bool ValidateUsername(string u)
        {
            if (u.Length < 2 || u.Length > 40)
            {
                SetStatus("❌ Tên phải từ 2 đến 40 ký tự", Color.FromArgb(200, 50, 50));
                return false;
            }
            foreach (char c in u)
            {
                // Chấp nhận: chữ cái Unicode (bao gồm tiếng Việt), chữ số, khoảng trắng, gạch dưới
                if (!char.IsLetter(c) && !char.IsDigit(c) && c != '_' && c != ' ')
                {
                    SetStatus("❌ Tên chỉ được chứa chữ cái (kể cả tiếng Việt), số và dấu gạch dưới", Color.FromArgb(200, 50, 50));
                    return false;
                }
            }
            return true;
        }
    }

    // ── Extension: DrawRoundedRectangle ──────────────────────────────────
    internal static class GraphicsExt
    {
        public static void FillRoundedRectangle(this Graphics g, Brush b, int x, int y, int w, int h, int r)
        {
            using GraphicsPath p = RoundedPath(x, y, w, h, r);
            g.FillPath(b, p);
        }
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int w, int h, int r)
        {
            using GraphicsPath p = RoundedPath(x, y, w, h, r);
            g.DrawPath(pen, p);
        }
        private static GraphicsPath RoundedPath(int x, int y, int w, int h, int r)
        {
            var path = new GraphicsPath();
            path.AddArc(x, y, r * 2, r * 2, 180, 90);
            path.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
            path.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
