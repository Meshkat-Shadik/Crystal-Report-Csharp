using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crrow
{
    public partial class frmprint : Form
    {
        string  bb, cc, dd, eee,ff,gg,l,ab;
        int aa,sal;
        string dt1, dt2;
        DateTime one, two;
        public frmprint(string a, string b, string c, string d, string e,string f,string g,string late,string abs,int salary,string x, string y)
        {
            InitializeComponent();
            aa = Convert.ToInt16(a);
            bb = b;
            cc = c;
            dd = d;
            eee = e;
            ff = f;
            gg = g;
            l = late;
            ab = abs;
            sal = salary;
           
            one = DateTime.Parse(x);
            two = DateTime.Parse(y);
            dt1 = one.ToString("dd-MMM,yyyy");
            dt2 = two.ToString("dd-MMM,yyyy");
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmprint_Load(object sender, EventArgs e)
        {
            string pAfine = ((sal*0.2)/100).ToString();
            string pLFine = ((sal * 0.08) / 100).ToString();
            string total = (sal - ((((sal * 0.2) / 100) * Convert.ToInt32(ab)) + (((sal * 0.08) / 100) * Convert.ToInt32(l)))).ToString();
            crystalReport11.SetParameterValue("pID",aa);
            crystalReport11.SetParameterValue("pName", bb);
            crystalReport11.SetParameterValue("pRank", cc);
            crystalReport11.SetParameterValue("pEmail", dd);
            crystalReport11.SetParameterValue("pMob", eee);
            crystalReport11.SetParameterValue("pUrl",ff);
            crystalReport11.SetParameterValue("pActive",gg);
            crystalReport11.SetParameterValue("pAbsent", ab);
            crystalReport11.SetParameterValue("pLate", l);
            crystalReport11.SetParameterValue("Salary", sal.ToString());
            crystalReport11.SetParameterValue("pAfine", pAfine);
            crystalReport11.SetParameterValue("pLFine", pLFine);
            crystalReport11.SetParameterValue("Total", total);
            crystalReport11.SetParameterValue("pDate1", dt1);
            crystalReport11.SetParameterValue("pDate2", dt2);
            crystalReportViewer1.ReportSource = crystalReport11;
         
            crystalReportViewer1.Refresh();
        }
    }
}
