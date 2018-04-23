using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<MyClass> list = new BindingList<MyClass>();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new MyClass(random.Next(1000), i.ToString()));
            }
            gridControl1.DataSource = list;
            gridControl1.ForceInitialize();
            gridView1.PreviewFieldName = "Description";
            gridView1.OptionsView.ShowPreview = true;
            StyleFormatCondition condition = new StyleFormatCondition(FormatConditionEnum.Greater, gridView1.Columns["Number"], null, 300, null, true);
            condition.Appearance.BackColor = Color.Green;
            gridView1.FormatConditions.Add(condition);
            gridView1.CustomDrawRowPreview += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(gridView1_CustomDrawRowPreview);
        }

        void gridView1_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Appearance.Assign((e.Info as GridDataRowInfo).Appearance);
        }
    }

    public class MyClass
    {
        public MyClass()
        {

        }

        /// <summary>
        /// Initializes a new instance of the MyClass class.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="description"></param>
        public MyClass(int number, string description)
        {
            _Number = number;
            _Description = description;
        }


        private int _Number;
        public int Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        
    }
}
