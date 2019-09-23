namespace Catan.GUI
{
    partial class LocaleSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.localeDropdown = new System.Windows.Forms.ComboBox();
            this.localeDropDownItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.localeSelectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.localeDropDownItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localeSelectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // localeDropdown
            // 
            this.localeDropdown.DataSource = this.localeDropDownItemBindingSource;
            this.localeDropdown.DisplayMember = "CultureName";
            this.localeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localeDropdown.FormattingEnabled = true;
            this.localeDropdown.Location = new System.Drawing.Point(12, 12);
            this.localeDropdown.Name = "localeDropdown";
            this.localeDropdown.Size = new System.Drawing.Size(403, 24);
            this.localeDropdown.TabIndex = 0;
            this.localeDropdown.ValueMember = "Culture";
            this.localeDropdown.SelectedIndexChanged += new System.EventHandler(this.SetButtonLocale);
            // 
            // localeDropDownItemBindingSource
            // 
            this.localeDropDownItemBindingSource.DataSource = typeof(Catan.GUI.LocaleDropDownItem);
            // 
            // localeSelectorBindingSource
            // 
            this.localeSelectorBindingSource.DataSource = typeof(Catan.GUI.LocaleSelector);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(409, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "TODO localizeme";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LocaleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.localeDropdown);
            this.Name = "LocaleSelector";
            this.Text = "LocaleSelector";
            ((System.ComponentModel.ISupportInitialize)(this.localeDropDownItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localeSelectorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox localeDropdown;
        private System.Windows.Forms.BindingSource localeDropDownItemBindingSource;
        private System.Windows.Forms.BindingSource localeSelectorBindingSource;
        private System.Windows.Forms.Button button1;
    }
}