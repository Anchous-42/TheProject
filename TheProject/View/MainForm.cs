using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TheProject.Model;
using TheProject.Model.Geometry;
using System.Collections.Generic;
using System.Drawing;

namespace TheProject
{
    /// <summary>
    /// �������� ���� ����������.
    /// ������ ������� ����������� ������������ ����� ������� ���������.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������� ��������� ������� ����� ����������.
        /// </summary>
        public MainForm()
        {
            InitializeComponent(); // ������������� �������������� ���������� ����������,
                                   // ��������� � ������������ Windows Forms
        }
    }
}