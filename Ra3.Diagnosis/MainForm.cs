using Microsoft.NodejsTools.SharedProject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace Ra3.Diagnosis
{
    public partial class MainForm : Form
    {
        private string? _selectedPath;
        public MainForm()
        {
            InitializeComponent();
            TryUpdatePath();
            UpdateView();
        }

        public bool TryUpdatePath()
        {
            if (Registry.IsGamePathValid(Path.GetFullPath(Directory.GetCurrentDirectory())))
            {
                _selectedPath = Path.GetFullPath(Directory.GetCurrentDirectory());
                return true;
            }
            else if (Registry.IsGameRegistryPathValid())
            {
                _selectedPath = Registry.GetGamePath();
                return true;
            }
            return false;
        }

        public bool TryUpdatePath(string path)
        {
            if (Registry.IsGamePathValid(path))
            {
                _selectedPath = path;
                return true;
            }
            return false;
        }

        public void UpdateView()
        {
            if (_selectedPath != null)
            {
                gamePathText.Text = _selectedPath;
                SetButtonState(true);
            }
            else
            {
                gamePathText.Text = "无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！";
                SetButtonState(false);
            }
        }

        public void SetButtonState(bool hasValidPath)
        {
            selectGamePathButton.Enabled = true;
            diagnosisGameButton.Enabled = hasValidPath;
            launchGameButton.Enabled = hasValidPath;
            launchGameCenterButton.Enabled = hasValidPath;
            fixRegistryButton.Enabled = hasValidPath;
            clearRegistryButton.Enabled = hasValidPath;
            memoryExtensionButton.Enabled = hasValidPath;
            fixGameLanguageButton.Enabled = hasValidPath;
            launchGameWindowedButton.Enabled = hasValidPath;
            openGameRootFolderButton.Enabled = hasValidPath;
            openMapsFolderButton.Enabled = hasValidPath;
            openModsFolderButton.Enabled = hasValidPath;
            openProfileFolderButton.Enabled = hasValidPath;
            openReplaysFolderButton.Enabled = hasValidPath;
        }

        private void SelectGamePathButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择游戏安装目录下的RA3.exe文件以使用本工具。");
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择游戏安装目录下的RA3.exe";
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "RA3 Game |RA3.exe";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!TryUpdatePath(openFileDialog.FileName.Substring(0, openFileDialog.FileName.Length - 8)))
                    {
                        MessageBox.Show("这不是一个正确的路径！");
                    }
                }
            }
            UpdateView();
        }

        private void CopyPathButton_Click(object sender, EventArgs e)
        {
            if (_selectedPath != null)
            {
                MessageBox.Show("已复制路径到剪贴板！");
                Clipboard.SetText(gamePathText.Text);
            }
        }

        private void CopyReportButton_Click(object sender, EventArgs e)
        {
            if (_selectedPath != null)
            {
                MessageBox.Show("已复制诊断到剪贴板！");
                Clipboard.SetText(diagnosisResultText.Text);
            }
        }

        private void OpenGameRootFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(_selectedPath))
                {
                    Process.Start("explorer.exe", _selectedPath);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！请选择红色警戒3路径后执行诊断。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试打开文件夹的时候发生错误\r\n{ex}");
            }
        }

        private void OpenReplaysFolderButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Red Alert 3"), "Replays");
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！请选择红色警戒3路径后执行诊断。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试打开文件夹的时候发生错误\r\n{ex}");
            }
        }

        private void OpenProfileFolderButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Red Alert 3"), "Profiles");
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！请选择红色警戒3路径后执行诊断。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试打开文件夹的时候发生错误\r\n{ex}");
            }
        }

        private void OpenMapsFolderButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Red Alert 3"), "Maps");
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！请选择红色警戒3路径后执行诊断。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试打开文件夹的时候发生错误\r\n{ex}");
            }
        }

        private void OpenModsFolderButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Red Alert 3"), "Mods");
            try
            {
                if (Directory.Exists(path))
                {
                    Process.Start("explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！请选择红色警戒3路径后执行诊断。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试打开文件夹的时候发生错误\r\n{ex}");
            }
        }

        private bool TryFixRegistry()
        {
            try
            {
                if (_selectedPath != null && Directory.Exists(_selectedPath))
                {
                    var key = Registry.GetKey();
                    if (ShowKeyDialog(ref key) == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(key))
                        {
                            key = Guid.NewGuid().ToString();
                        }
                        Registry.FixGameRegistry(_selectedPath, key);
                        MessageBox.Show("注册表修复成功！");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("已取消注册表修复。");
                    }
                }
                else
                {
                    MessageBox.Show("无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试修复注册表的时候发生错误\r\n{ex}");
            }
            return false;
        }

        private void FixRegistryButton_Click(object sender, EventArgs e)
        {
            TryFixRegistry();
        }

        private void ClearRegistryButton_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.ClearGameRegistry();
                MessageBox.Show("注册表卸载成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"尝试卸载注册表的时候发生错误\r\n{ex}");
            }
        }

        private static DialogResult ShowKeyDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(500, 100);
            var inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "请输入你的CDKEY";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            var noteLabel1 = new Label();
            noteLabel1.Name = "noteLabel1";
            noteLabel1.Size = new System.Drawing.Size(320, 20);
            noteLabel1.Font = new Font("Arial", 8);
            noteLabel1.Text = "不填写或填写错误的CDKEY不会影响修复";
            noteLabel1.Location = new System.Drawing.Point(0, 40);
            inputBox.Controls.Add(noteLabel1);
            var noteLabel2 = new Label();
            noteLabel2.Name = "noteLabel2";
            noteLabel2.Size = new System.Drawing.Size(320, 20);
            noteLabel2.Font = new Font("Arial", 8);
            noteLabel2.Text = "但是可能违反了EA的用户协议！";
            noteLabel2.Location = new System.Drawing.Point(0, 60);
            inputBox.Controls.Add(noteLabel2);

            var okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 30);
            okButton.Text = "&确认";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 50);
            inputBox.Controls.Add(okButton);

            var cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 30);
            cancelButton.Text = "&取消";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 50);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            var result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void CheckFolder(string folderName, string path)
        {
            if (Directory.Exists(path))
            {
                diagnosisResultText.Text += $"- 完成 - {folderName}检查成功。\r\n";
            }
            else
            {
                diagnosisResultText.Text += $"- 错误 - 找不到{folderName}。\r\n";
                if (MessageBox.Show($"是否立刻创建{folderName}？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        diagnosisResultText.Text += $"- 已解决 - 已经成功创建{folderName}。\r\n";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"尝试创建{folderName}的时候发生错误\r\n{ex}");
                        diagnosisResultText.Text += $"- 解决方案 - 请手动创建{folderName}。\r\n";
                    }
                }
                else
                {
                    diagnosisResultText.Text += $"- 解决方案 - 请手动创建{folderName}。\r\n";
                }
            }
        }

        private void DiagnosisGameButton_Click(object sender, EventArgs e)
        {
            diagnosisResultText.Text = "开始诊断...\r\n";
            if (_selectedPath == null)
            {
                diagnosisResultText.Text += "无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！\r\n";
                return;
            }

            var possibleUnofficialGamePath = Path.Combine(Path.Combine(_selectedPath, "Data"), "ra3_1.13.game");
            if (File.Exists(possibleUnofficialGamePath))
            {
                diagnosisResultText.Text += "- 警告 - 游戏版本似乎是1.13而不是1.12，这是一个非官方版本，无法进行多人游戏！\r\n";
            }

            if (_selectedPath.All(x => x < 128))
            {
                diagnosisResultText.Text += "- 完成 - 根目录路径检查成功。\r\n";
            }
            else
            {
                diagnosisResultText.Text += "- 错误 - 红色警戒3安装目录上有非ASCII字符（例如中文）。\r\n";
                diagnosisResultText.Text += "- 解决方案 - 请更改安装目录，然后修复注册表。\r\n";
            }
            var hasInvalidSkuDef = false;
            foreach (var file in Directory.GetFiles(_selectedPath))
            {
                if (Path.GetExtension(file) == ".SkuDef")
                {
                    if (!file.All(x => x < 128))
                    {
                        diagnosisResultText.Text += $"- 错误 - SkuDef文件上非ASCII字符: {Path.GetFileNameWithoutExtension(file)}。\r\n";
                        hasInvalidSkuDef = true;
                    }
                }
            }
            if (hasInvalidSkuDef)
            {
                diagnosisResultText.Text += "- 解决方案 - 请重命名SkuDef文件并保证路径上只有ASCII字符。\r\n";
            }
            else
            {
                diagnosisResultText.Text += "- 完成 - SkuDef文件路径检查成功。\r\n";
            }

            var gameFilePath = Path.Combine(Path.Combine(_selectedPath, "Data"), "ra3_1.12.game");
            if (File.Exists(gameFilePath))
            {
                if (LargeAddress.IsLargeAddressEnabled(gameFilePath))
                {
                    diagnosisResultText.Text += "- 完成 - 已启用内存拓展。\r\n";
                }
                else
                {
                    diagnosisResultText.Text += "- 警告 - 未启用内存拓展，可能会导致部分模组无法正确使用。\r\n";
                    if (MessageBox.Show("是否立刻启用内存拓展？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LargeAddress.EnableLargeAddress(gameFilePath);
                        diagnosisResultText.Text += "- 已解决 - 内存拓展已启用。\r\n";
                    }
                    else
                    {
                        diagnosisResultText.Text += "- 解决方案 - 请点击激活内存拓展。\r\n";
                    }
                }
            }
            else
            {
                diagnosisResultText.Text += "- 错误 - 无法找到.game文件。\r\n";
                MessageBox.Show("无法找到.game文件，当前正在使用的目录下的红色警戒3可能不完整！");
            }

            if (Registry.IsRegistryValid())
            {
                diagnosisResultText.Text += "- 完成 - 注册表检查成功。\r\n";
            }
            else
            {
                diagnosisResultText.Text += "- 错误 - 注册表错误或不完整。\r\n";
                if (MessageBox.Show("是否立刻修复注册表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (TryFixRegistry())
                    {
                        diagnosisResultText.Text += "- 已解决 - 已经成功解决注册表问题。\r\n";
                    }
                    else
                    {
                        diagnosisResultText.Text += "- 解决方案 - 请修复注册表。\r\n";
                    }
                }
                else
                {
                    diagnosisResultText.Text += "- 解决方案 - 请修复注册表。\r\n";
                }
            }

            diagnosisResultText.Text += "开始修复语言文件...\r\n";
            foreach (var file in GameLanguage.FindInvalidLanguageFiles())
            {
                diagnosisResultText.Text += $"- 正在删除无效的语言文件：{file.Name}。\r\n";
                file.Delete();
            }
            var validLanguages = GameLanguage.FindValidLanguages();
            if (validLanguages.Length == 0)
            {
                MessageBox.Show("没有找到任何有效的语言文件！请检查你的游戏是否完整。");
            }
            else
            {
                var candidate = validLanguages.First();
                diagnosisResultText.Text += $"- 已找到{validLanguages.Length}种有效的语言文件！\r\n";
                foreach (var language in validLanguages)
                {
                    if (language.StartsWith("chinese"))
                    {
                        candidate = language;
                    }
                    diagnosisResultText.Text += $"- {language}。\r\n";
                }
                Registry.SetLanguage(candidate);
                diagnosisResultText.Text += $"- 已选择{candidate}作为默认语言。\r\n";
            }

            // 开始检查文件夹
            var replaysPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Red Alert 3"), "Replays");
            CheckFolder("录像文件夹", replaysPath);
            var modsPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Red Alert 3"), "Mods");
            CheckFolder("模组文件夹", modsPath);
            var mapsPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Red Alert 3"), "Maps");
            CheckFolder("地图文件夹", mapsPath);
            var profilesPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Red Alert 3"), "Profiles");
            CheckFolder("用户文件夹", profilesPath);

            // 开始检查地图文件夹
            if (Directory.Exists(mapsPath))
            {
                var mapsSize = Directory.GetDirectories(mapsPath).Length;
                if (mapsSize > 200)
                {
                    diagnosisResultText.Text += $"- 错误 - 已发现{mapsSize}张地图，这个数量几乎肯定会导致错误，请点击打开地图文件夹，然后将地图数量降低到50以下。\r\n";
                }
                else if (mapsSize > 100)
                {
                    diagnosisResultText.Text += $"- 警告 - 已发现{mapsSize}张地图，这个数量有一定可能导致错误，请点击打开地图文件夹，然后将地图数量降低到50以下。\r\n";
                }
                else if (mapsSize > 50)
                {
                    diagnosisResultText.Text += $"- 警告 - 已发现{mapsSize}张地图，这个数量几乎不会导致错误，但仍建议打开地图文件夹，然后将地图数量降低到50以下。\r\n";
                }
                else
                {
                    diagnosisResultText.Text += $"- 完成 - 已发现{mapsSize}张地图，这个数量一定不会导致错误。\r\n";
                }
            }
            else
            {
                diagnosisResultText.Text += "- 跳过 - 地图文件夹不存在。\r\n";
            }

            // 开始检查options.ini
            var hasInvalidOption = false;
            foreach (var profile in Directory.GetDirectories(profilesPath))
            {
                var options = Path.Combine(profile, "Options.ini");
                if (File.Exists(options))
                {
                    var allLines = File.ReadAllLines(options);
                    var result = new List<string>();
                    foreach (var line in allLines)
                    {
                        if (!line.StartsWith("FirewallPortOverride"))
                        {
                            result.Add(line);
                        }
                        else
                        {
                            hasInvalidOption = true;
                        }
                    }
                    File.WriteAllLines(options, result.ToArray());
                }
            }
            if (hasInvalidOption)
            {
                diagnosisResultText.Text += "- 已解决 - 可能会导致多人游戏无法连接的错误设置已删除。\r\n";
            }
            else
            {
                diagnosisResultText.Text += "- 完成 - 没有发现可能会导致错误的设置。\r\n";
            }

            // 开始检查skirmish.ini 好吧 没法检查 但是可以删
            if (MessageBox.Show("是否遇到了遭遇战无法正确选择阵营或者多人游戏开房出现问题？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var profile in Directory.GetDirectories(profilesPath))
                {
                    var skirmish = Path.Combine(profile, "Skirmish.ini");
                    if (File.Exists(skirmish))
                    {
                        File.Delete(skirmish);
                    }
                }
                diagnosisResultText.Text += "- 已解决 - 遭遇战或多人游戏准备界面问题修复完成。\r\n";
            }
            else
            {
                diagnosisResultText.Text += "- 跳过 - 没有遭遇战或多人游戏准备界面问题。\r\n";
            }

            diagnosisResultText.Text += "这里列举了一些可能的，但是这个工具无法处理的情况：\r\n";
            diagnosisResultText.Text += "假如启动游戏时提示没有安装 DirectX 9.0c 等 DirectX 错误，请尝试先用「窗口化模式」启动游戏，并在游戏设置里修改分辨率\r\n";
            diagnosisResultText.Text += "如果游戏（遭遇战或者多人游戏）进入战斗的瞬间崩溃，看录像不崩溃，" +
                "很有可能是Windows Defender或者其他安全软件阻止了红色警戒3访问录像文件夹。" +
                "请关闭这些安全软件对“文档”这个目录的保护。\r\n";
            diagnosisResultText.Text += "如果遇到了多人游戏连接失败，请关闭防火墙再试一次。\r\n";

            diagnosisResultText.Text += "诊断完成\r\n";
        }

        private void MemoryExtensionButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.Combine(_selectedPath, "Data"), "ra3_1.12.game");
            if (File.Exists(path))
            {
                if (LargeAddress.IsLargeAddressEnabled(path))
                {
                    MessageBox.Show("已经激活，无需重复激活！");
                }
                else
                {
                    LargeAddress.EnableLargeAddress(path);
                    MessageBox.Show("备份文件已储存，激活成功！");
                }

            }
            else
            {
                MessageBox.Show("无法找到.game文件，当前正在使用的目录下的红色警戒3可能不完整！");
            }
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(_selectedPath, "RA3.exe");
            if (File.Exists(path))
            {
                SystemUtility.ExecuteProcessUnElevated(path, "");
            }
            else
            {
                MessageBox.Show("无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！");
            }
        }

        private void LaunchGameCenterButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(_selectedPath, "RA3.exe");
            if (File.Exists(path))
            {
                SystemUtility.ExecuteProcessUnElevated(path, "-ui");
            }
            else
            {
                MessageBox.Show("无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Try to show program version on title.
                this.Text += $" {Assembly.GetExecutingAssembly().GetName().Version}";
            }
            catch { }
        }

        private void FixGameLanguageButton_Click(object sender, EventArgs e)
        {
            diagnosisResultText.Text = "开始修复语言文件...\r\n";
            foreach (var file in GameLanguage.FindInvalidLanguageFiles())
            {
                diagnosisResultText.Text += $"- 正在删除无效的语言文件：{file.Name}。\r\n";
                file.Delete();
            }
            var validLanguages = GameLanguage.FindValidLanguages();
            if (validLanguages.Length == 0)
            {
                MessageBox.Show("没有找到任何有效的语言文件！请检查你的游戏是否完整。");
            }
            else
            {
                var candidate = validLanguages.First();
                diagnosisResultText.Text += $"- 已找到{validLanguages.Length}种有效的语言文件！\r\n";
                foreach (var language in validLanguages)
                {
                    if (language.StartsWith("chinese"))
                    {
                        candidate = language;
                    }
                    diagnosisResultText.Text += $"- {language}。\r\n";
                }
                Registry.SetLanguage(candidate);
                diagnosisResultText.Text += $"- 已选择{candidate}作为默认语言。\r\n";
            }
        }

        private void LaunchGameWindowedButton_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(_selectedPath, "RA3.exe");
            if (File.Exists(path))
            {
                SystemUtility.ExecuteProcessUnElevated(path, "-win");
            }
            else
            {
                MessageBox.Show("无法找到你的红色警戒3，请把本工具放到红色警戒3根目录或点击下面的按钮手动选择红色警戒3！");
            }
        }
    }
}