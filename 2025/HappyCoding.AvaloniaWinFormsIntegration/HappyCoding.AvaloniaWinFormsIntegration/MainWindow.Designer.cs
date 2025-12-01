namespace HappyCoding.AvaloniaWinFormsIntegration
{
    partial class MainWindow
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
            _avaloniaHost = new Avalonia.Win32.Interoperability.WinFormsAvaloniaControlHost();
            SuspendLayout();
            // 
            // _avaloniaHost
            // 
            _avaloniaHost.Content = null;
            _avaloniaHost.Dock = DockStyle.Fill;
            _avaloniaHost.Location = new Point(0, 0);
            _avaloniaHost.Name = "_avaloniaHost";
            _avaloniaHost.Size = new Size(1251, 614);
            _avaloniaHost.TabIndex = 0;
            _avaloniaHost.Text = "winFormsAvaloniaControlHost1";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 614);
            Controls.Add(_avaloniaHost);
            Name = "MainWindow";
            Text = "MainWindow";
            ResumeLayout(false);
        }

        #endregion

        private Avalonia.Win32.Interoperability.WinFormsAvaloniaControlHost _avaloniaHost;
    }
}
