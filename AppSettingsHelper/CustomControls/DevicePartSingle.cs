﻿using SalesFeedBackInfrasturcture.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using SalesFeedBackInfrasturcture.Infrastructure;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public partial class DevicePartSingle : UserControl
    {
        DevicePart _devicePart;
        public DevicePart _DevicePart
        {
            get
            {
                return _devicePart;
            }
            set
            {
                _devicePart = value;
            }
        }
        public Int32 MaintainCount
        {
            set
            {
                this.lbl_Count.Text = value.ToString();
            }
        }
        public DevicePartSingle(DevicePart devicePart, DeviceOperatorStyle deviceOperatorStyle)
        {
            InitializeComponent();
            _devicePart = devicePart;
            this.lbl_partID.Text = devicePart.ID;
            this.lbl_partName.Text = devicePart.PartName;
            this.lbl_MaintainCount.Text = deviceOperatorStyle == DeviceOperatorStyle.Maintain ? "保养次数" : "维修次数";
            this.lbl_Count.Text = deviceOperatorStyle == DeviceOperatorStyle.Maintain ? devicePart.MaintainDetails.Count.ToString() : devicePart.RepairDetails.Count.ToString();
            this.Click += Item_Click;
            this.DoubleClick += Double_Click;
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            var toolStripMenuItemAdd = new ToolStripMenuItem
            {
                Name = "toolStripMenuAdd",
                Text = deviceOperatorStyle == DeviceOperatorStyle.Maintain ? "保养维护" : "维修维护",
                Image = deviceOperatorStyle == DeviceOperatorStyle.Maintain ? "fa-steam-square".GetBitmap() : "fa-legal".GetBitmap()
            };
            toolStripMenuItemAdd.Click += ToolStripMenuItemAdd_Click;
            contextMenuStrip.Items.Add(toolStripMenuItemAdd);
            var toolStripMenuItem = new ToolStripMenuItem
            {
                Name = "toolStripMenuModify",
                Text = "部件修改",
                Image = "fa-pencil-square-o".GetBitmap(),
            };
            toolStripMenuItem.Click += ToolStripMenuItemModify_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            var toolStripMenuItem1 = new ToolStripMenuItem
            {
                Name = "toolStripMenuDelete",
                Text = "部件删除",
                Image = "fa-times".GetBitmap(),
            };
            toolStripMenuItem1.Click += ToolStripMenuItemDelete_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem1);
            this.ContextMenuStrip = contextMenuStrip;
            foreach (Control item in this.Controls)
            {
                item.ContextMenuStrip = contextMenuStrip;
                item.Click += Item_Click;
                item.DoubleClick += Double_Click;
                foreach (Control item1 in item.Controls)
                {
                    item1.Click += Item_Click;
                    item1.DoubleClick += Double_Click;
                    item1.ContextMenuStrip = contextMenuStrip;
                }
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddHandle?.Invoke(this, e);
        }

        private void ToolStripMenuItemModify_Click(object sender, EventArgs e)
        {
            var dEdit = new DevicePartEdit(SalesFeedBackMain.OperatorType.Modify);
            dEdit.StartPosition = FormStartPosition.CenterParent;
            dEdit._DevicePart = this._devicePart;
            if (dEdit.ShowDialog() == DialogResult.OK)
            {
                this._devicePart = dEdit._DevicePart;
                ModifiedHandle?.Invoke(this, e);
            }
        }
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除[" + this._devicePart.PartName + "]部件吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DeletedHandle?.Invoke(this, e);
            }
        }

        private Boolean _isSelected = false;
        public Boolean IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (value)
                {
                    this.BackColor = Color.AliceBlue;
                }
                else
                {
                    this.BackColor = Color.White;
                }
            }
        }

        public String DevicePartId => this.lbl_partID.Text;
        private void Item_Click(object sender, EventArgs e)
        {
            if (_isSelected)
            {
                _isSelected = false;
                this.BackColor = Color.White;
            }
            else
            {
                _isSelected = true;
                this.BackColor = Color.AliceBlue;
            }
        }
        private void Double_Click(object sender, EventArgs e)
        {  
            //这个操作还原之前的状态
            if (_isSelected)
            {
                _isSelected = false;
                this.BackColor = Color.White;
            }
            else
            {
                _isSelected = true;
                this.BackColor = Color.AliceBlue;
            }
            AddHandle?.Invoke(this, null);
        }
        public event EventHandler AddHandle;
        public event EventHandler ModifiedHandle;
        public event EventHandler DeletedHandle;
    }
}
