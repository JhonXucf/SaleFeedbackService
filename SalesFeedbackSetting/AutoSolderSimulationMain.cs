using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace SalesFeedbackSetting
{
    public partial class AutoSolderSimulationMain : Form
    {
        enum OperatorType
        {
            Add = 1,
            Modify = 2,
            Delete = 3,
        }
        public AutoSolderSimulationMain()
        {
            InitializeComponent();
        }

        private void 新增DW800ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mathineType = MathineType.DW800;
            string[] result = null;
            ShowAutoItem(OperatorType.Add, result, mathineType);
        }

        private void 新增ID900ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mathineType = MathineType.ID900;
            string[] result = null;
            ShowAutoItem(OperatorType.Add, result, mathineType);
        }
        int _StartX = 10, _StartY = 10, _Offset = 10;
        private void ShowAutoItem(OperatorType operatorType, string[] result, MathineType mathineType)
        {
            var item = new AutoSolderMathineItemFrm(result, mathineType);
            item.StartPosition = FormStartPosition.CenterParent;
            item.ShowDialog();
            if (item.DialogResult == DialogResult.OK && operatorType == OperatorType.Add)
            {
                var itemShow = new AutoSolderItemShowControl(item._Result, mathineType);
                itemShow.ModifyEventClicked += ItemShow_ModifyEventClicked;
                itemShow.DeleteEventClicked += ItemShow_DeleteEventClicked;
                itemShow.Location = this.panel1.SetControlLocation(_StartX, _StartY, _Offset);
                this.panel1.Controls.Add(itemShow);
            }
        }

        private void ItemShow_DeleteEventClicked(object sender, EventArgs e)
        {            
            this.panel1.Controls.Remove((AutoSolderItemShowControl)sender);
            if (this.panel1.Controls.Count > 0)
                this.panel1.UpdateControlLocation(_StartX, _StartY, _Offset);
        }

        private void ItemShow_ModifyEventClicked(object sender, EventArgs e)
        {
            var itemShow = (AutoSolderItemShowControl)sender;
            ShowAutoItem(OperatorType.Modify, itemShow._Result, itemShow._MathineType);
        }
    }
}
