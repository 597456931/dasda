using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 读取XML文件动态绑定TreeView控件S
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadXmlToTvList();
        }
        private void InitTreeView()
        {


        }
        public void ReadXmlToTvList()
        {
            XmlDataDocument doc = new XmlDataDocument();
            doc.Load("Address.xml");
            XmlNode nodes = doc.DocumentElement;
            TreeNode tn = new TreeNode();
            tn.Text = nodes.Attributes["name"].InnerText;
            tvList.Nodes.Add(tn);
            TreeNode tns = null;
            TreeNode childs = null;
            foreach (XmlNode item in nodes.ChildNodes)
            {
                tns = new TreeNode();
                tns.Text = item.Attributes["name"].InnerText;
                tns.Tag = item;
                TreeNode child = null;
                foreach (XmlNode node in item.ChildNodes)
                {
                    child = new TreeNode();
                    child.Text = node.Attributes["name"].InnerText;
                    foreach (XmlNode items in node.ChildNodes)
                    {
                        childs = new TreeNode();
                        childs.Text = items.InnerText;
                        child.Nodes.Add(childs);
                    }
                    tns.Nodes.Add(child);
                }
                tn.Nodes.Add(tns);
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (tvList.SelectedNode.Level == 0)
            {
                txtStreet.Text = tvList.SelectedNode.Text;
            }
            if (tvList.SelectedNode.Level == 1)
            {
                txtStreet.Text = tvList.SelectedNode.Parent.Text;
                textJuweo.Text = tvList.SelectedNode.Text;
            }
            if (tvList.SelectedNode.Level == 2)
            {
                txtStreet.Text = tvList.Nodes[0].Text;
                textJuweo.Text = tvList.SelectedNode.Parent.Text;
                textBox3.Text = tvList.SelectedNode.Text;
            }
            if (tvList.SelectedNode.Level == 3)
            {
                txtStreet.Text = tvList.Nodes[0].Text;
                textJuweo.Text = tvList.SelectedNode.Parent.Parent.Text;
                textBox3.Text = tvList.SelectedNode.Parent.Text;
                textBox4.Text = tvList.SelectedNode.Text;
            }
        }
    }
}