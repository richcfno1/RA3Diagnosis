using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ra3.Diagnosis
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.selectGamePathButton = new System.Windows.Forms.Button();
            this.gamePath = new System.Windows.Forms.Label();
            this.gamePathText = new System.Windows.Forms.TextBox();
            this.fixRegistryButton = new System.Windows.Forms.Button();
            this.openModsFolderButton = new System.Windows.Forms.Button();
            this.openMapsFolderButton = new System.Windows.Forms.Button();
            this.openReplaysFolderButton = new System.Windows.Forms.Button();
            this.openGameRootFolderButton = new System.Windows.Forms.Button();
            this.diagnosisGameButton = new System.Windows.Forms.Button();
            this.clearRegistryButton = new System.Windows.Forms.Button();
            this.diagnosisResultText = new System.Windows.Forms.TextBox();
            this.diagnosisResult = new System.Windows.Forms.Label();
            this.openProfileFolderButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyPathButton = new System.Windows.Forms.Button();
            this.copyReportButton = new System.Windows.Forms.Button();
            this.launchGameButton = new System.Windows.Forms.Button();
            this.launchGameCenterButton = new System.Windows.Forms.Button();
            this.memoryExtensionButton = new System.Windows.Forms.Button();
            this.githubLink = new System.Windows.Forms.Label();
            this.launchGameWindowedButton = new System.Windows.Forms.Button();
            this.fixGameLanguageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectGamePathButton
            // 
            this.selectGamePathButton.Location = new System.Drawing.Point(11, 125);
            this.selectGamePathButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectGamePathButton.Name = "selectGamePathButton";
            this.selectGamePathButton.Size = new System.Drawing.Size(222, 42);
            this.selectGamePathButton.TabIndex = 0;
            this.selectGamePathButton.Text = "选择红色警戒3游戏路径";
            this.selectGamePathButton.UseVisualStyleBackColor = true;
            this.selectGamePathButton.Click += new System.EventHandler(this.SelectGamePathButton_Click);
            // 
            // gamePath
            // 
            this.gamePath.AutoSize = true;
            this.gamePath.Location = new System.Drawing.Point(11, 10);
            this.gamePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gamePath.Name = "gamePath";
            this.gamePath.Size = new System.Drawing.Size(85, 15);
            this.gamePath.TabIndex = 1;
            this.gamePath.Text = "当前游戏路径";
            // 
            // gamePathText
            // 
            this.gamePathText.Location = new System.Drawing.Point(11, 37);
            this.gamePathText.Margin = new System.Windows.Forms.Padding(2);
            this.gamePathText.Multiline = true;
            this.gamePathText.Name = "gamePathText";
            this.gamePathText.ReadOnly = true;
            this.gamePathText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gamePathText.Size = new System.Drawing.Size(676, 81);
            this.gamePathText.TabIndex = 2;
            this.gamePathText.Text = "未知";
            // 
            // fixRegistryButton
            // 
            this.fixRegistryButton.Location = new System.Drawing.Point(238, 173);
            this.fixRegistryButton.Margin = new System.Windows.Forms.Padding(2);
            this.fixRegistryButton.Name = "fixRegistryButton";
            this.fixRegistryButton.Size = new System.Drawing.Size(222, 42);
            this.fixRegistryButton.TabIndex = 3;
            this.fixRegistryButton.Text = "修复红色警戒3注册表";
            this.fixRegistryButton.UseVisualStyleBackColor = true;
            this.fixRegistryButton.Click += new System.EventHandler(this.FixRegistryButton_Click);
            // 
            // openModsFolderButton
            // 
            this.openModsFolderButton.Location = new System.Drawing.Point(238, 269);
            this.openModsFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.openModsFolderButton.Name = "openModsFolderButton";
            this.openModsFolderButton.Size = new System.Drawing.Size(222, 42);
            this.openModsFolderButton.TabIndex = 5;
            this.openModsFolderButton.Text = "打开模组文件夹";
            this.openModsFolderButton.UseVisualStyleBackColor = true;
            this.openModsFolderButton.Click += new System.EventHandler(this.OpenModsFolderButton_Click);
            // 
            // openMapsFolderButton
            // 
            this.openMapsFolderButton.Location = new System.Drawing.Point(466, 269);
            this.openMapsFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.openMapsFolderButton.Name = "openMapsFolderButton";
            this.openMapsFolderButton.Size = new System.Drawing.Size(222, 42);
            this.openMapsFolderButton.TabIndex = 6;
            this.openMapsFolderButton.Text = "打开地图文件夹";
            this.openMapsFolderButton.UseVisualStyleBackColor = true;
            this.openMapsFolderButton.Click += new System.EventHandler(this.OpenMapsFolderButton_Click);
            // 
            // openReplaysFolderButton
            // 
            this.openReplaysFolderButton.Location = new System.Drawing.Point(11, 317);
            this.openReplaysFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.openReplaysFolderButton.Name = "openReplaysFolderButton";
            this.openReplaysFolderButton.Size = new System.Drawing.Size(222, 42);
            this.openReplaysFolderButton.TabIndex = 7;
            this.openReplaysFolderButton.Text = "打开录像文件夹";
            this.openReplaysFolderButton.UseVisualStyleBackColor = true;
            this.openReplaysFolderButton.Click += new System.EventHandler(this.OpenReplaysFolderButton_Click);
            // 
            // openGameRootFolderButton
            // 
            this.openGameRootFolderButton.Location = new System.Drawing.Point(11, 269);
            this.openGameRootFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.openGameRootFolderButton.Name = "openGameRootFolderButton";
            this.openGameRootFolderButton.Size = new System.Drawing.Size(222, 42);
            this.openGameRootFolderButton.TabIndex = 8;
            this.openGameRootFolderButton.Text = "打开红色警戒3根目录";
            this.openGameRootFolderButton.UseVisualStyleBackColor = true;
            this.openGameRootFolderButton.Click += new System.EventHandler(this.OpenGameRootFolderButton_Click);
            // 
            // diagnosisGameButton
            // 
            this.diagnosisGameButton.Location = new System.Drawing.Point(238, 125);
            this.diagnosisGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.diagnosisGameButton.Name = "diagnosisGameButton";
            this.diagnosisGameButton.Size = new System.Drawing.Size(222, 42);
            this.diagnosisGameButton.TabIndex = 9;
            this.diagnosisGameButton.Text = "一键诊断修复问题";
            this.diagnosisGameButton.UseVisualStyleBackColor = true;
            this.diagnosisGameButton.Click += new System.EventHandler(this.DiagnosisGameButton_Click);
            // 
            // clearRegistryButton
            // 
            this.clearRegistryButton.Location = new System.Drawing.Point(466, 173);
            this.clearRegistryButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearRegistryButton.Name = "clearRegistryButton";
            this.clearRegistryButton.Size = new System.Drawing.Size(222, 42);
            this.clearRegistryButton.TabIndex = 10;
            this.clearRegistryButton.Text = "卸载红色警戒3注册表";
            this.clearRegistryButton.UseVisualStyleBackColor = true;
            this.clearRegistryButton.Click += new System.EventHandler(this.ClearRegistryButton_Click);
            // 
            // diagnosisResultText
            // 
            this.diagnosisResultText.Location = new System.Drawing.Point(11, 425);
            this.diagnosisResultText.Margin = new System.Windows.Forms.Padding(2);
            this.diagnosisResultText.Multiline = true;
            this.diagnosisResultText.Name = "diagnosisResultText";
            this.diagnosisResultText.ReadOnly = true;
            this.diagnosisResultText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.diagnosisResultText.Size = new System.Drawing.Size(676, 210);
            this.diagnosisResultText.TabIndex = 11;
            this.diagnosisResultText.Text = "暂无诊断";
            // 
            // diagnosisResult
            // 
            this.diagnosisResult.AutoSize = true;
            this.diagnosisResult.Location = new System.Drawing.Point(11, 387);
            this.diagnosisResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.diagnosisResult.Name = "diagnosisResult";
            this.diagnosisResult.Size = new System.Drawing.Size(85, 15);
            this.diagnosisResult.TabIndex = 12;
            this.diagnosisResult.Text = "问题诊断结果";
            // 
            // openProfileFolderButton
            // 
            this.openProfileFolderButton.Location = new System.Drawing.Point(238, 317);
            this.openProfileFolderButton.Margin = new System.Windows.Forms.Padding(2);
            this.openProfileFolderButton.Name = "openProfileFolderButton";
            this.openProfileFolderButton.Size = new System.Drawing.Size(222, 42);
            this.openProfileFolderButton.TabIndex = 13;
            this.openProfileFolderButton.Text = "打开用户文件夹";
            this.openProfileFolderButton.UseVisualStyleBackColor = true;
            this.openProfileFolderButton.Click += new System.EventHandler(this.OpenProfileFolderButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // copyPathButton
            // 
            this.copyPathButton.Location = new System.Drawing.Point(586, 4);
            this.copyPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.copyPathButton.Name = "copyPathButton";
            this.copyPathButton.Size = new System.Drawing.Size(102, 35);
            this.copyPathButton.TabIndex = 14;
            this.copyPathButton.Text = "复制";
            this.copyPathButton.UseVisualStyleBackColor = true;
            this.copyPathButton.Click += new System.EventHandler(this.CopyPathButton_Click);
            // 
            // copyReportButton
            // 
            this.copyReportButton.Location = new System.Drawing.Point(586, 382);
            this.copyReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.copyReportButton.Name = "copyReportButton";
            this.copyReportButton.Size = new System.Drawing.Size(102, 35);
            this.copyReportButton.TabIndex = 15;
            this.copyReportButton.Text = "复制";
            this.copyReportButton.UseVisualStyleBackColor = true;
            this.copyReportButton.Click += new System.EventHandler(this.CopyReportButton_Click);
            // 
            // launchGameButton
            // 
            this.launchGameButton.Location = new System.Drawing.Point(466, 125);
            this.launchGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.launchGameButton.Name = "launchGameButton";
            this.launchGameButton.Size = new System.Drawing.Size(222, 42);
            this.launchGameButton.TabIndex = 16;
            this.launchGameButton.Text = "开始游戏";
            this.launchGameButton.UseVisualStyleBackColor = true;
            this.launchGameButton.Click += new System.EventHandler(this.LaunchGameButton_Click);
            // 
            // launchGameCenterButton
            // 
            this.launchGameCenterButton.Location = new System.Drawing.Point(11, 173);
            this.launchGameCenterButton.Margin = new System.Windows.Forms.Padding(2);
            this.launchGameCenterButton.Name = "launchGameCenterButton";
            this.launchGameCenterButton.Size = new System.Drawing.Size(222, 42);
            this.launchGameCenterButton.TabIndex = 17;
            this.launchGameCenterButton.Text = "打开控制中心";
            this.launchGameCenterButton.UseVisualStyleBackColor = true;
            this.launchGameCenterButton.Click += new System.EventHandler(this.LaunchGameCenterButton_Click);
            // 
            // memoryExtensionButton
            // 
            this.memoryExtensionButton.Location = new System.Drawing.Point(11, 221);
            this.memoryExtensionButton.Margin = new System.Windows.Forms.Padding(2);
            this.memoryExtensionButton.Name = "memoryExtensionButton";
            this.memoryExtensionButton.Size = new System.Drawing.Size(222, 42);
            this.memoryExtensionButton.TabIndex = 18;
            this.memoryExtensionButton.Text = "启动内存拓展";
            this.memoryExtensionButton.UseVisualStyleBackColor = true;
            this.memoryExtensionButton.Click += new System.EventHandler(this.MemoryExtensionButton_Click);
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(328, 637);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(241, 15);
            this.githubLink.TabIndex = 19;
            this.githubLink.Text = "https://github.com/richcfno1/RA3Diagnosis";
            // 
            // launchGameWindowedButton
            // 
            this.launchGameWindowedButton.Location = new System.Drawing.Point(466, 221);
            this.launchGameWindowedButton.Margin = new System.Windows.Forms.Padding(2);
            this.launchGameWindowedButton.Name = "launchGameWindowedButton";
            this.launchGameWindowedButton.Size = new System.Drawing.Size(222, 42);
            this.launchGameWindowedButton.TabIndex = 20;
            this.launchGameWindowedButton.Text = "窗口化模式启动游戏";
            this.launchGameWindowedButton.UseVisualStyleBackColor = true;
            this.launchGameWindowedButton.Click += new System.EventHandler(this.LaunchGameWindowedButton_Click);
            // 
            // fixGameLanguageButton
            // 
            this.fixGameLanguageButton.Location = new System.Drawing.Point(238, 221);
            this.fixGameLanguageButton.Margin = new System.Windows.Forms.Padding(2);
            this.fixGameLanguageButton.Name = "fixGameLanguageButton";
            this.fixGameLanguageButton.Size = new System.Drawing.Size(222, 42);
            this.fixGameLanguageButton.TabIndex = 21;
            this.fixGameLanguageButton.Text = "修复游戏语言";
            this.fixGameLanguageButton.UseVisualStyleBackColor = true;
            this.fixGameLanguageButton.Click += new System.EventHandler(this.FixGameLanguageButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 688);
            this.Controls.Add(this.fixGameLanguageButton);
            this.Controls.Add(this.launchGameWindowedButton);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.memoryExtensionButton);
            this.Controls.Add(this.launchGameCenterButton);
            this.Controls.Add(this.launchGameButton);
            this.Controls.Add(this.copyReportButton);
            this.Controls.Add(this.copyPathButton);
            this.Controls.Add(this.openProfileFolderButton);
            this.Controls.Add(this.diagnosisResult);
            this.Controls.Add(this.diagnosisResultText);
            this.Controls.Add(this.clearRegistryButton);
            this.Controls.Add(this.diagnosisGameButton);
            this.Controls.Add(this.openGameRootFolderButton);
            this.Controls.Add(this.openReplaysFolderButton);
            this.Controls.Add(this.openMapsFolderButton);
            this.Controls.Add(this.openModsFolderButton);
            this.Controls.Add(this.fixRegistryButton);
            this.Controls.Add(this.gamePathText);
            this.Controls.Add(this.gamePath);
            this.Controls.Add(this.selectGamePathButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(720, 727);
            this.MinimumSize = new System.Drawing.Size(720, 727);
            this.Name = "MainForm";
            this.Text = "红色警戒3 诊断工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button selectGamePathButton;
        private Label gamePath;
        private TextBox gamePathText;
        private Button fixRegistryButton;
        private Button openModsFolderButton;
        private Button openMapsFolderButton;
        private Button openReplaysFolderButton;
        private Button openGameRootFolderButton;
        private Button diagnosisGameButton;
        private Button clearRegistryButton;
        private TextBox diagnosisResultText;
        private Label diagnosisResult;
        private Button openProfileFolderButton;
        private ContextMenuStrip contextMenuStrip1;
        private Button copyPathButton;
        private Button copyReportButton;
        private Button launchGameButton;
        private Button launchGameCenterButton;
        private Button memoryExtensionButton;
        private Label githubLink;
        private Button launchGameWindowedButton;
        private Button fixGameLanguageButton;
    }
}