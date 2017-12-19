using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Toyo.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ToImportExcelForPTIC
{
    public partial class ImportForTownshipAndTown : Form
    {
        int insertedTownCount = 0;
        int insertedTownshipCount = 0;
        public ImportForTownshipAndTown()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                txtFileName.Text = FileName;
            }
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == "") { MessageBox.Show("Choose Excel file!"); return; }

            readDataFormExcel();
        }

        private void readDataFormExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            // For "Employee Info data","Education & Working Experience","Work History & Bank Account","Parents & Sibling","Spouse & Family" WorkSheets

            Excel.Worksheet xlWSTown;//sheet 6
            Excel.Worksheet xlWSTownship;//sheet 7

            Excel.Range rangeTown, rangeTownship;

            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(txtFileName.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            #region get sheet and define range

            xlWSTown = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(6);
            xlWSTownship = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(7);


            rangeTown = xlWSTown.UsedRange;
            rangeTownship = xlWSTownship.UsedRange;
            #endregion

            #region For Town
            for (rCnt = 1; rCnt <= rangeTown.Rows.Count; rCnt++)
            {
                if ((rangeTown.Cells[rCnt + 3, 3] as Excel.Range).Value != null)
                {
                    #region Sheet to Array
                   
                    string[] Town = new string[rangeTown.Columns.Count];
                    //In Town[], cell number 0 and 4.
                    for (cCnt = 0; cCnt <= rangeTown.Columns.Count; cCnt++)
                    {
                        int i = cCnt + 1;
                        if ((rangeTown.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            Town[i - 1] = (rangeTown.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }
                    #endregion

                    if (Town.Count() != 0)
                    {
                        #region sheet 6

                        try
                        {
                            #region for inserting Town information
                            if (Town[0] != null && Town[4] != null)
                            {
                                TownVO vo = new TownVO();
                                string stateDivisionName = Town[0].ToString();
                                string townName = Town[4].ToString();
                                System.Data.DataTable dt = new StateDivisionDAO().SelectByDivisionName(stateDivisionName);
                                foreach (DataRow row in dt.Rows)
                                {
                                    object value = row["ID"];
                                    if (value == DBNull.Value)
                                    {
                                        MessageBox.Show("Can't Find State Division!");
                                    }
                                    else
                                    {
                                        //Geting DivisionID, not inserting town one time
                                        var Id = dt.Rows[0][0];
                                        string ID = Id.ToString();
                                        int stateDivisionID = Convert.ToInt32(ID);
                                        vo.StateDivisionID = stateDivisionID;
                                        vo.Town = townName;
                                        vo.DateAdded = DateTime.Now;
                                        vo.LastModified = DateTime.Now;
                                        vo.IsDeleted = false;

                                        //check town if it is duplicate
                                        TownVO tvo = new TownDAO().GetIDByName(townName);
                                        if (tvo.Id == 0)
                                        {
                                            TownDAO dao = new TownDAO();
                                            dao.Insert(vo);
                                            insertedTownCount++;
                                            //MessageBox.Show("Inserting Town Information is Success");
                                        }
                                        else
                                        {
                                            //MessageBox.Show("This Town Data has already in Database");
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Insert Error:" + ex.ToString());
                        }
                        #endregion
                    }
                }
            }
            #endregion

            #region for Township
            for (rCnt = 1; rCnt <= rangeTownship.Rows.Count; rCnt++)
            {
                if ((rangeTownship.Cells[rCnt + 3, 3] as Excel.Range).Value != null)
                {
                    #region Sheet to Array

                    string[] Township = new string[rangeTownship.Columns.Count];
                    for (cCnt = 0; cCnt <= rangeTownship.Columns.Count; cCnt++)
                    {
                        int i = cCnt + 1;
                        if ((rangeTownship.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            Township[i - 1] = (rangeTownship.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }
                    #endregion

                    if (Township.Count() != 0)
                    {
                        #region sheet 7
                        try
                        {
                            #region for inserting Township information
                            if (Township[2] != null & Township[5] != null)
                            {
                                TownshipInfoVO vo = new TownshipInfoVO();
                                int TownId = 0;
                                string townName = Township[2];
                                string townshipName = Township[5];
                                TownVO tvo = new TownDAO().GetIDByName(townName);
                                if (vo.Id == 0)
                                {
                                    vo.Id = 1;
                                }
                                else
                                {
                                    TownId = vo.Id;
                                }
                                vo.TownID = TownId;
                                vo.Township = townshipName;
                                vo.DateAdded = DateTime.Now;
                                vo.LastModified = DateTime.Now;
                                vo.IsDeleted = false;
                                TownshipInfoVO tvo1 = new TownshipInfoDAO().GetIDByName(townName);
                                if (vo.Id == 0)
                                {
                                    TownshipInfoDAO dao = new TownshipInfoDAO();
                                    dao.Insert(vo);
                                    //MessageBox.Show("Inserting Township Information is Success");
                                    insertedTownshipCount++;
                                }
                                else
                                {
                                    //MessageBox.Show("This Township Data is already in Database.");
                                }
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Insert Error:" + ex.ToString());
                        }

                        #endregion
                    }
                }
            }
            #endregion
            MessageBox.Show("Importing Town and Township Information is finished.");
            Debug.WriteLine(insertedTownCount);
            Debug.WriteLine(insertedTownshipCount);
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {

        }

        private void lblHeaderPCat_Click(object sender, EventArgs e)
        {

        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnimport_Click_1(object sender, EventArgs e)
        {
            if (txtFileName.Text == "") { MessageBox.Show("Choose Excel file!"); return; }

            readDataFormExcel();
        }
    }
}