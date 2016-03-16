using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bing壁纸;
using System.IO;

namespace bing桌面壁纸
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            int day1 = setbizhi.day;
            string mkt1 = setbizhi.mkt;
            setbizhi.setbz2(day1, mkt1);
        }

        private void btn_Jp_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "JA-JP";
            dizhi2 = setbizhi.setbz(setbizhi.day,setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);


        }

        private void btn_Ch_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "ZH-CN";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_En_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-IN";
             dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_De_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "DE-DE";
             dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Fr_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "FR-FR";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Gb_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-GB";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Br_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "PT-BR";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Ca_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-CA";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Fca_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "FR-CA";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Us_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-US";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_ww_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-WW";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Au_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            setbizhi.mkt = "EN-AU";
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            ++setbizhi.day;
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            SetBiZhi setbizhi = new SetBiZhi();
            string dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            File.Delete(dizhi2);
            --setbizhi.day;
            dizhi2 = setbizhi.setbz(setbizhi.day, setbizhi.mkt);
            this.pictureBox1.Image = Image.FromFile(dizhi2);
        }
    }
}
