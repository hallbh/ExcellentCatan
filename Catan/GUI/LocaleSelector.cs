using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Catan.Properties;

namespace Catan.GUI
{
    public partial class LocaleSelector : Form
    {
        public readonly List<LocaleDropDownItem> Items = new List<LocaleDropDownItem>();

        public LocaleSelector()
        {

            InitializeComponent();
            var defaultItem = new LocaleDropDownItem(CultureInfo.GetCultureInfo("en"));
            var currentCulture = CultureInfo.CurrentUICulture;
            Items.Add(defaultItem);
            foreach (var dir in Directory.GetDirectories(@".\"))
            {
                if (Directory.GetFiles(dir, "*.resources.dll").Length > 0)
                {
                    var localeStr = dir.Replace(@".\", "");
                    var info = CultureInfo.GetCultureInfo(localeStr);
                    var item = new LocaleDropDownItem(info);
                    Items.Add(item);
                    if (info.Equals(CultureInfo.CurrentUICulture))
                    {
                        defaultItem = item;
                    } else if (!defaultItem.Culture.Equals(item.Culture) && 
                               item.Culture.IsNeutralCulture && 
                               currentCulture.Parent.Equals(item.Culture))
                    {
                        defaultItem = item;
                    }
                }
            }
            
            localeDropdown.DataSource = Items;
            localeDropdown.SelectedItem = defaultItem;


        }


        public CultureInfo TargetCulture;
        
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void SetButtonLocale(object sender, EventArgs e)
        {
            TargetCulture = (CultureInfo)localeDropdown.SelectedValue;
            CultureInfo.CurrentCulture = TargetCulture;
            CultureInfo.CurrentUICulture = TargetCulture;
            CultureInfo.DefaultThreadCurrentCulture = TargetCulture;
            CultureInfo.DefaultThreadCurrentUICulture = TargetCulture;
            button1.Text = Resources.StartButton;
        }
    }
    public class LocaleDropDownItem
    {
        public LocaleDropDownItem(CultureInfo info)
        {
            Culture = info;
        }

        public CultureInfo Culture { get; }
        public string CultureName => Culture.DisplayName;

    }
}
