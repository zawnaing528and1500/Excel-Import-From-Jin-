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

namespace Toyo
{
    public partial class Frm_ExcelImportForEmp : Form
    {
        public Frm_ExcelImportForEmp()
        {
            InitializeComponent();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(HR.TrainingPage));
            this.Close();
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
            Excel.Worksheet xlWSInfo;
            Excel.Worksheet xlWSEduWorkExp;
            Excel.Worksheet xlWSWorkHisBank;
            Excel.Worksheet xlWSParSib;
            Excel.Worksheet xlWSSpouFam;

            Excel.Range range,rangeEdu,rangeWHis,rangeParent,rangeSpouse;

            int rCnt = 0;
            int cCnt = 0;
            bool Success = false;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(txtFileName.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            xlWSInfo = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWSEduWorkExp = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            xlWSWorkHisBank = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
            xlWSParSib = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4);
            xlWSSpouFam = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(5);

            range = xlWSInfo.UsedRange;
            rangeEdu = xlWSEduWorkExp.UsedRange;
            rangeWHis = xlWSWorkHisBank.UsedRange;
            rangeParent = xlWSParSib.UsedRange;
            rangeSpouse = xlWSSpouFam.UsedRange;
           
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                if ((range.Cells[rCnt + 3, 3] as Excel.Range).Value != null)
                {
                    #region Insert data into String Array

                    // For Info
                    string[] Info = new string[range.Columns.Count - 1];
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        int i = cCnt;
                        if ((range.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            Info[i - 1] = (range.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }

                    // For Education and Working Experience
                    string[] EduWEx = new string[rangeEdu.Columns.Count - 1];
                    for (cCnt = 1; cCnt <= rangeEdu.Columns.Count; cCnt++)
                    {
                        int i = cCnt;
                        if ((rangeEdu.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            EduWEx[i - 1] = (rangeEdu.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }

                    // For Working History and Bank Information
                    string[] WorkHisBank = new string[rangeWHis.Columns.Count - 1];
                    for (cCnt = 1; cCnt <= rangeWHis.Columns.Count; cCnt++)
                    {
                        int i = cCnt;
                        if ((rangeWHis.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            WorkHisBank[i - 1] = (rangeWHis.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }

                    // For Parent and Sibling
                    string[] ParSib = new string[rangeParent.Columns.Count - 1];
                    for (cCnt = 1; cCnt <= rangeParent.Columns.Count; cCnt++)
                    {
                        int i = cCnt;
                        if ((rangeParent.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            ParSib[i - 1] = (rangeParent.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }

                    // For Spouse and Family
                    string[] SpoFam = new string[rangeSpouse.Columns.Count - 1];
                    for (cCnt = 1; cCnt <= rangeSpouse.Columns.Count; cCnt++)
                    {
                        int i = cCnt;
                        if ((rangeSpouse.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value != null)
                            SpoFam[i - 1] = (rangeSpouse.Cells[rCnt + 3, cCnt + 1] as Excel.Range).Value.ToString();
                    }

                    #endregion

                    // To Save Data into database
                    if (Info.Count() != 0)
                    {
                        #region For Entity
                        Entity_Framework.Employee emp = new Entity_Framework.Employee();
                        Entity_Framework.Employee_Address empAdd = new Entity_Framework.Employee_Address();
                        Entity_Framework.Employee_Address empAddCon = new Entity_Framework.Employee_Address();
                        Entity_Framework.Employee_Qualification empQua = new Entity_Framework.Employee_Qualification();
                        Entity_Framework.Employee_WorkingExperience empWExp = new Entity_Framework.Employee_WorkingExperience();
                        Entity_Framework.Employee_Bank_Info empBank1 = new Entity_Framework.Employee_Bank_Info();
                        Entity_Framework.Employee_Bank_Info empBank2 = new Entity_Framework.Employee_Bank_Info();
                        Entity_Framework.Employee_Relative empParent = new Entity_Framework.Employee_Relative();
                        Entity_Framework.Employee_Relative empSibling = new Entity_Framework.Employee_Relative();
                        Entity_Framework.Employee_Relative empSpouse = new Entity_Framework.Employee_Relative();
                        Entity_Framework.Employee_Relative empChildren = new Entity_Framework.Employee_Relative();
                        #endregion

                        try
                        {
                            #region Employee Info

                            //if (Info[0] != null)
                            //    emp.EmployDate = DateTime.Parse(Info[0].ToString());
                            if (Info[1] != null)
                                emp.EmpName = Info[1].ToString();
                            if (Info[2] != null)
                            {
                                string postName = Info[2].ToString();
                                JobPositionVO vo = new JobPositionDAO().GetIDByName(postName);
                                if (vo.Id == 0)
                                {
                                    MessageBox.Show("Invalid Position Name!");
                                    return;
                                }
                                emp.PostID = vo.Id;
                            }
                            if (Info[3] != null)
                            {
                                string SubsidiaryName = Info[3].ToString();
                                int index = SubsidiaryName.IndexOf("'");
                                if (index != -1)
                                {
                                    SubsidiaryName = SubsidiaryName.Insert(index, "'+CHAR(39)+");
                                }
                                string str = "select * From Branch where Branch='" + SubsidiaryName + "'";
                                DataTable dt = new EmployeeDAO().SelectByQuery(str);
                                if (dt.Rows.Count != 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                        emp.SubsidiaryID = int.Parse(dr["ID"].ToString());
                                }
                                //Entity_Framework.Branch sub = (from A in PTIC_Logger.em.Branches where A.Branch1 == SubsidiaryName select A).FirstOrDefault();
                                //if (sub != null)
                                //    emp.SubsidiaryID = sub.ID;
                            }
                            if (Info[4] != null)
                            {
                                string BranchName = Info[4].ToString();
                                Entity_Framework.Branch branch = (from A in PTIC_Logger.em.Branches where A.Branch1 == BranchName select A).FirstOrDefault();
                                if (branch != null)
                                    emp.BranchID = branch.ID;
                            }
                            if (Info[5] != null)
                            {
                                string deptName = Info[5].ToString();
                                DepartmentVO vo = new DepartmentDAO().GetIDByName(deptName);
                                if (vo.Id == 0)
                                {
                                    MessageBox.Show("Invalid Department Name!");
                                    return;
                                }
                                emp.DeptID = vo.Id;
                            }
                            if (Info[6] != null)
                                emp.StaffID = Info[6].ToString();
                            if (Info[7] != null)
                            {
                                emp.FingerID = int.Parse(Info[7].ToString());
                            }
                            else
                                emp.FingerID = 0;
                            if (Info[8] != null)
                                emp.DOB = DateTime.Parse(Info[8].ToString());
                            if (Info[9] != null)
                                emp.NRCNo = Info[9].ToString();
                            if (Info[10] != null)
                                emp.EmployDate = DateTime.Parse(Info[10].ToString());
                            if (Info[11] != null)
                            {
                                emp.ApprovalDate = DateTime.Parse(Info[11].ToString());
                                emp.isPermanent = true;
                            }
                            else
                            {
                                emp.isPermanent = false;
                            }
                            if (Info[12] != null)
                                emp.FatherName = Info[12].ToString();
                            if (Info[13] != null)
                                emp.Race = Info[13].ToString();
                            //if (Info[13] != null)
                            //    emp.Religion = Info[13].ToString();
                            if (Info[15] != null)
                            {
                                if (Info[15].ToString() == "F")
                                    emp.Gender = false;
                                else if (Info[15].ToString() == "M")
                                    emp.Gender = true;
                            }
                            if (Info[16] != null)
                            {
                                if (Info[16].ToString() == "Y")
                                    emp.MaritalStatus = 1;
                                else if (Info[16].ToString() == "N")
                                    emp.MaritalStatus = 0;
                            }
                            if (Info[17] != null)
                                emp.PassportNo = Info[17].ToString();
                            if (Info[18] != null)
                                emp.SSCode = Info[18].ToString();

                            // For SSB Office
                            if (Info[38] != null)
                                emp.SSBOffice = Info[38].ToString();

                            if (Info[19] != null)
                                emp.DriverLicence = Info[19].ToString();
                            //if (Info[19] != null)
                            //    emp.emp = Info[19].ToString();
                            if (Info[21] != null)
                            {
                                if (Info[21].ToString() == "Y")
                                    emp.Criminal = true;
                                else if (Info[21].ToString() == "N")
                                    emp.Criminal = false;
                            }
                            if (Info[22] != null)
                                emp.PersonalEmail = Info[22].ToString();
                            if (Info[23] != null)
                                emp.FacebookAccount = Info[23].ToString();

                            emp.isDeleted = false;
                            emp.IsActive = true;

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Info!");
                            return;
                        }

                        try
                        {
                            #region Employee Permanent Address

                            if (Info[24] != null || Info[25] != null || Info[26] != null)
                            {
                                if (Info[24] != null)
                                    empAdd.HomeNo = Info[24].ToString();
                                if (Info[25] != null)
                                    empAdd.Street = Info[25].ToString();
                                if (Info[26] != null)
                                    empAdd.Quarter = Info[26].ToString();
                                if (Info[27] != null)
                                {
                                    string TSName = Info[27].ToString();
                                    TownshipInfoVO TSvo = new TownshipInfoDAO().GetByName(TSName);
                                    empAdd.TownshipID = TSvo.Id;
                                }
                                if (Info[28] != null)
                                {
                                    string TName = Info[28].ToString();
                                    TownVO Tvo = new TownDAO().GetByName(TName);
                                    empAdd.TownId = Tvo.Id;
                                }
                                if (Info[29] != null)
                                {
                                    string SDName = Info[29].ToString();
                                    StateDivisionVO SDvo = new StateDivisionDAO().GetByName(SDName);
                                    empAdd.StateDivisionID = SDvo.Id;
                                }
                                if (Info[30] != null)
                                    empAdd.Phone = Info[30].ToString();

                                empAdd.isPermanent = true;
                                emp.Employee_Address.Add(empAdd);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Permanent Address!");
                            return;
                        }

                        try
                        {
                            #region Employee Contact Address

                            if (Info[31] != null)
                            {
                                empAddCon.HomeNo = Info[31].ToString();
                                if (Info[32] != null)
                                    empAddCon.Street = Info[32].ToString();
                                if (Info[33] != null)
                                    empAddCon.Quarter = Info[33].ToString();
                                if (Info[34] != null)
                                {
                                    string TSName = Info[34].ToString();
                                    TownshipInfoVO TSvo = new TownshipInfoDAO().GetByName(TSName);
                                    empAddCon.TownshipID = TSvo.Id;
                                }
                                if (Info[35] != null)
                                {
                                    string TName = Info[35].ToString();
                                    TownVO Tvo = new TownDAO().GetByName(TName);
                                    empAddCon.TownId = Tvo.Id;
                                }
                                if (Info[36] != null)
                                {
                                    string SDName = Info[36].ToString();
                                    StateDivisionVO SDvo = new StateDivisionDAO().GetByName(SDName);
                                    empAddCon.StateDivisionID = SDvo.Id;
                                }
                                if (Info[37] != null)
                                    empAddCon.Phone = Info[37].ToString();

                                empAddCon.isPermanent = false;

                                emp.Employee_Address.Add(empAddCon);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Contact Address!");
                            return;
                        }

                        try
                        {
                            #region Employee Qualification

                            // For Qualification 1
                            if (EduWEx[4] != null)
                            {
                                empQua.Degree = EduWEx[4].ToString();
                                if (EduWEx[5] != null)
                                    empQua.University = EduWEx[5].ToString();
                                if (EduWEx[6] != null)
                                    empQua.QYear = EduWEx[6].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            // For Qualification 2
                            if (EduWEx[7] != null)
                            {
                                empQua = new Entity_Framework.Employee_Qualification();
                                empQua.Degree = EduWEx[7].ToString();
                                if (EduWEx[8] != null)
                                    empQua.University = EduWEx[8].ToString();
                                if (EduWEx[9] != null)
                                    empQua.QYear = EduWEx[9].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            // For Qualification 3
                            if (EduWEx[10] != null)
                            {
                                empQua = new Entity_Framework.Employee_Qualification();
                                empQua.Degree = EduWEx[10].ToString();
                                if (EduWEx[11] != null)
                                    empQua.University = EduWEx[11].ToString();
                                if (EduWEx[12] != null)
                                    empQua.QYear = EduWEx[12].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            // For Qualification 4
                            if (EduWEx[13] != null)
                            {
                                empQua = new Entity_Framework.Employee_Qualification();
                                empQua.Degree = EduWEx[13].ToString();
                                if (EduWEx[14] != null)
                                    empQua.University = EduWEx[14].ToString();
                                if (EduWEx[15] != null)
                                    empQua.QYear = EduWEx[15].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            // For Qualification 5
                            if (EduWEx[16] != null)
                            {
                                empQua = new Entity_Framework.Employee_Qualification();
                                empQua.Degree = EduWEx[16].ToString();
                                if (EduWEx[17] != null)
                                    empQua.University = EduWEx[17].ToString();
                                if (EduWEx[18] != null)
                                    empQua.QYear = EduWEx[18].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            // For Qualification 6
                            if (EduWEx[19] != null)
                            {
                                empQua = new Entity_Framework.Employee_Qualification();
                                empQua.Degree = EduWEx[19].ToString();
                                if (EduWEx[20] != null)
                                    empQua.University = EduWEx[20].ToString();
                                if (EduWEx[21] != null)
                                    empQua.QYear = EduWEx[21].ToString();
                                empQua.IsDeleted = false;

                                emp.Employee_Qualification.Add(empQua);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Qualification!");
                            return;
                        }

                        try
                        {
                            #region Employee Working Experience

                            // For Employee Working Experience1 
                            if (EduWEx[22] != null)
                                empWExp.Period = EduWEx[22].ToString();
                            if (EduWEx[23] != null)
                                empWExp.Company = EduWEx[23].ToString();
                            if (EduWEx[24] != null)
                                empWExp.Position = EduWEx[24].ToString();
                            if (EduWEx[25] != null)
                                empWExp.Address = EduWEx[25].ToString();
                            if (EduWEx[26] != null)
                                empWExp.Phone = EduWEx[26].ToString();
                            if (EduWEx[27] != null)
                                empWExp.RefName = EduWEx[27].ToString();
                            empWExp.IsDeleted = false;

                            if (empWExp.Period != null && empWExp.Company != null && empWExp.Position != null)
                                emp.Employee_WorkingExperience.Add(empWExp);

                            // For Employee Working Experience2 
                            empWExp = new Entity_Framework.Employee_WorkingExperience();
                            if (EduWEx[28] != null)
                                empWExp.Period = EduWEx[28].ToString();
                            if (EduWEx[29] != null)
                                empWExp.Company = EduWEx[29].ToString();
                            if (EduWEx[30] != null)
                                empWExp.Position = EduWEx[30].ToString();
                            if (EduWEx[31] != null)
                                empWExp.Address = EduWEx[31].ToString();
                            if (EduWEx[32] != null)
                                empWExp.Phone = EduWEx[32].ToString();
                            if (EduWEx[33] != null)
                                empWExp.RefName = EduWEx[33].ToString();
                            empWExp.IsDeleted = false;

                            if (empWExp.Period != null && empWExp.Company != null && empWExp.Position != null)
                                emp.Employee_WorkingExperience.Add(empWExp);

                            // For Employee Working Experience3 
                            empWExp = new Entity_Framework.Employee_WorkingExperience();
                            if (EduWEx[34] != null)
                                empWExp.Period = EduWEx[34].ToString();
                            if (EduWEx[35] != null)
                                empWExp.Company = EduWEx[35].ToString();
                            if (EduWEx[36] != null)
                                empWExp.Position = EduWEx[36].ToString();
                            if (EduWEx[37] != null)
                                empWExp.Address = EduWEx[37].ToString();
                            if (EduWEx[38] != null)
                                empWExp.Phone = EduWEx[38].ToString();
                            if (EduWEx[39] != null)
                                empWExp.RefName = EduWEx[39].ToString();
                            empWExp.IsDeleted = false;

                            if (empWExp.Period != null && empWExp.Company != null && empWExp.Position != null)
                                emp.Employee_WorkingExperience.Add(empWExp);

                            // For Employee Working Experience4
                            empWExp = new Entity_Framework.Employee_WorkingExperience();
                            if (EduWEx[40] != null)
                                empWExp.Period = EduWEx[40].ToString();
                            if (EduWEx[41] != null)
                                empWExp.Company = EduWEx[41].ToString();
                            if (EduWEx[42] != null)
                                empWExp.Position = EduWEx[42].ToString();
                            if (EduWEx[43] != null)
                                empWExp.Address = EduWEx[43].ToString();
                            if (EduWEx[44] != null)
                                empWExp.Phone = EduWEx[44].ToString();
                            if (EduWEx[45] != null)
                                empWExp.RefName = EduWEx[45].ToString();
                            empWExp.IsDeleted = false;

                            if (empWExp.Period != null && empWExp.Company != null && empWExp.Position != null)
                                emp.Employee_WorkingExperience.Add(empWExp);

                            // For Employee Working Experience5
                            empWExp = new Entity_Framework.Employee_WorkingExperience();
                            if (EduWEx[46] != null)
                                empWExp.Period = EduWEx[46].ToString();
                            if (EduWEx[47] != null)
                                empWExp.Company = EduWEx[47].ToString();
                            if (EduWEx[48] != null)
                                empWExp.Position = EduWEx[48].ToString();
                            if (EduWEx[49] != null)
                                empWExp.Address = EduWEx[49].ToString();
                            if (EduWEx[50] != null)
                                empWExp.Phone = EduWEx[50].ToString();
                            if (EduWEx[51] != null)
                                empWExp.RefName = EduWEx[51].ToString();
                            empWExp.IsDeleted = false;

                            if (empWExp.Period != null && empWExp.Company != null && empWExp.Position != null)
                                emp.Employee_WorkingExperience.Add(empWExp);

                            if (EduWEx[52] != null)
                                emp.ReferencesName1 = EduWEx[52].ToString();
                            if (EduWEx[53] != null)
                                emp.ReferencesPh1 = EduWEx[53].ToString();
                            if (EduWEx[54] != null)
                                emp.ReferencesName2 = EduWEx[54].ToString();
                            if (EduWEx[55] != null)
                                emp.ReferencesPh2 = EduWEx[55].ToString();

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Experience!");
                            return;
                        }

                        try
                        {
                            #region Employee Bank Information

                            // For Bank Info 1
                            if (WorkHisBank[4] != null)
                            {
                                string BankName = WorkHisBank[4].ToString();
                                BankVO vo = new BankDAO().GetByName(BankName);
                                empBank1.BankID = vo.Id;

                                if (WorkHisBank[5] != null)
                                    empBank1.AccountNumber = WorkHisBank[5].ToString();
                                if (WorkHisBank[6] != null)
                                    empBank1.AccountType = WorkHisBank[6].ToString();
                                if (WorkHisBank[7] != null)
                                {
                                    if (WorkHisBank[7].ToString() == "Y")
                                        empBank1.IsUseForPay = true;
                                    else if (WorkHisBank[7].ToString() == "N")
                                        empBank1.IsUseForPay = false;
                                }
                                empBank1.IsDeleted = false;

                                if (empBank1.BankID != 0)
                                    emp.Employee_Bank_Info.Add(empBank1);
                            }

                            // For Bank Info 2
                            if (WorkHisBank[8] != null)
                            {
                                string BankName = WorkHisBank[8].ToString();
                                BankVO vo = new BankDAO().GetByName(BankName);
                                empBank2.BankID = vo.Id;

                                if (WorkHisBank[9] != null)
                                    empBank2.AccountNumber = WorkHisBank[9].ToString();
                                if (WorkHisBank[10] != null)
                                    empBank2.AccountType = WorkHisBank[10].ToString();
                                if (WorkHisBank[11] != null)
                                {
                                    if (WorkHisBank[11].ToString() == "Y")
                                        empBank2.IsUseForPay = true;
                                    else if (WorkHisBank[11].ToString() == "N")
                                        empBank2.IsUseForPay = false;
                                }
                                empBank2.IsDeleted = false;

                                if (empBank2.BankID != 0)
                                    emp.Employee_Bank_Info.Add(empBank2);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Bank Info!");
                            return;
                        }

                        try
                        {
                            #region Parents And Siblings

                            
                            if (ParSib[4] != null)
                            {
                                empParent.RelativeName = ParSib[4].ToString();
                                empParent.Relation = 1; // For Father
                                if (ParSib[6] != null)
                                {
                                    if (ParSib[6].ToString() == "Y")
                                        empParent.IsAlive = true;
                                    else if (ParSib[6].ToString() == "N")
                                        empParent.IsAlive = false;
                                }
                                if (ParSib[7] != null)
                                    empParent.Occupation = ParSib[7].ToString();
                                if (ParSib[8] != null)
                                    empParent.nameOfCompany = ParSib[8].ToString();
                                if (ParSib[9] != null)
                                    empParent.Address = ParSib[9].ToString();
                                if (ParSib[10] != null)
                                    empParent.Phone = ParSib[10].ToString();
                                if (ParSib[11] != null)
                                {
                                    string IsTax = ParSib[11].ToString();
                                    if (IsTax == "Y")
                                        empParent.IsTax = true;
                                    else if (IsTax == "N")
                                        empParent.IsTax = false;
                                }
                                empParent.IsDeleted = false;
                                emp.Employee_Relative.Add(empParent);
                            }
                            /////////////////////////////////////////////////////////////////////////////////
                            empParent = new Entity_Framework.Employee_Relative();
                            if (ParSib[12] != null)
                            {
                                empParent.RelativeName = ParSib[12].ToString();
                                empParent.Relation = 1; // For Mother
                                if (ParSib[14] != null)
                                {
                                    if (ParSib[14].ToString() == "Y")
                                        empParent.IsAlive = true;
                                    else if (ParSib[14].ToString() == "N")
                                        empParent.IsAlive = false;
                                }
                                if (ParSib[15] != null)
                                    empParent.Occupation = ParSib[15].ToString();
                                if (ParSib[16] != null)
                                    empParent.nameOfCompany = ParSib[16].ToString();
                                if (ParSib[17] != null)
                                    empParent.Address = ParSib[17].ToString();
                                if (ParSib[18] != null)
                                    empParent.Phone = ParSib[18].ToString();
                                if (ParSib[19] != null)
                                {
                                    string IsTax = ParSib[19].ToString();
                                    if (IsTax == "Y")
                                        empParent.IsTax = true;
                                    else if (IsTax == "N")
                                        empParent.IsTax = false;
                                }
                                empParent.IsDeleted = false;
                                emp.Employee_Relative.Add(empParent);
                            }
                            ///////////////////////////////////////////////////////////////////////////////
                            if (ParSib[20] != null)
                            {
                                empSibling.RelativeName = ParSib[20].ToString();
                                empSibling.Relation = 4; // For Sibling1
                                if (ParSib[22] != null)
                                {
                                    if (ParSib[22].ToString() == "Y")
                                        empSibling.IsAlive = true;
                                    else if (ParSib[22].ToString() == "N")
                                        empSibling.IsAlive = false;
                                }
                                if (ParSib[23] != null)
                                    empSibling.Occupation = ParSib[23].ToString();
                                if (ParSib[24] != null)
                                    empSibling.nameOfCompany = ParSib[24].ToString();
                                if (ParSib[25] != null)
                                    empSibling.Address = ParSib[25].ToString();
                                if (ParSib[26] != null)
                                    empSibling.Phone = ParSib[26].ToString();
                                if (ParSib[27] != null)
                                {
                                    string IsTax = ParSib[27].ToString();
                                    if (IsTax == "Y")
                                        empSibling.IsTax = true;
                                    else if (IsTax == "N")
                                        empSibling.IsTax = false;
                                }
                                empSibling.IsDeleted = false;
                                emp.Employee_Relative.Add(empSibling);
                            }
                            //////////////////////////////////////////////////////////////////////
                            empSibling = new Entity_Framework.Employee_Relative();
                            if (ParSib[28] != null)
                            {
                                empSibling.RelativeName = ParSib[28].ToString();
                                empSibling.Relation = 4; // For Sibling2
                                if (ParSib[30] != null)
                                {
                                    if (ParSib[30].ToString() == "Y")
                                        empSibling.IsAlive = true;
                                    else if (ParSib[30].ToString() == "N")
                                        empSibling.IsAlive = false;
                                }
                                if (ParSib[31] != null)
                                    empSibling.Occupation = ParSib[31].ToString();
                                if (ParSib[32] != null)
                                    empSibling.nameOfCompany = ParSib[32].ToString();
                                if (ParSib[33] != null)
                                    empSibling.Address = ParSib[33].ToString();
                                if (ParSib[34] != null)
                                    empSibling.Phone = ParSib[34].ToString();
                                if (ParSib[35] != null)
                                {
                                    string IsTax = ParSib[35].ToString();
                                    if (IsTax == "Y")
                                        empSibling.IsTax = true;
                                    else if (IsTax == "N")
                                        empSibling.IsTax = false;
                                }
                                empSibling.IsDeleted = false;
                                emp.Employee_Relative.Add(empSibling);
                            }
                            //////////////////////////////////////////////////////////////////////
                            empSibling = new Entity_Framework.Employee_Relative();
                            if (ParSib[36] != null)
                            {
                                empSibling.RelativeName = ParSib[36].ToString();
                                empSibling.Relation = 4; // For Sibling3
                                if (ParSib[38] != null)
                                {
                                    if (ParSib[38].ToString() == "Y")
                                        empSibling.IsAlive = true;
                                    else if (ParSib[38].ToString() == "N")
                                        empSibling.IsAlive = false;
                                }
                                if (ParSib[39] != null)
                                    empSibling.Occupation = ParSib[39].ToString();
                                if (ParSib[40] != null)
                                    empSibling.nameOfCompany = ParSib[40].ToString();
                                if (ParSib[41] != null)
                                    empSibling.Address = ParSib[41].ToString();
                                if (ParSib[42] != null)
                                    empSibling.Phone = ParSib[42].ToString();
                                if (ParSib[43] != null)
                                {
                                    string IsTax = ParSib[43].ToString();
                                    if (IsTax == "Y")
                                        empSibling.IsTax = true;
                                    else if (IsTax == "N")
                                        empSibling.IsTax = false;
                                }
                                empSibling.IsDeleted = false;
                                emp.Employee_Relative.Add(empSibling);
                            }
                            //////////////////////////////////////////////////////////////////////
                            empSibling = new Entity_Framework.Employee_Relative();
                            if (ParSib[44] != null)
                            {
                                empSibling.RelativeName = ParSib[44].ToString();
                                empSibling.Relation = 4; // For Sibling4
                                if (ParSib[46] != null)
                                {
                                    if (ParSib[46].ToString() == "Y")
                                        empSibling.IsAlive = true;
                                    else if (ParSib[46].ToString() == "N")
                                        empSibling.IsAlive = false;
                                }
                                if (ParSib[47] != null)
                                    empSibling.Occupation = ParSib[47].ToString();
                                if (ParSib[48] != null)
                                    empSibling.nameOfCompany = ParSib[48].ToString();
                                if (ParSib[49] != null)
                                    empSibling.Address = ParSib[49].ToString();
                                if (ParSib[50] != null)
                                    empSibling.Phone = ParSib[50].ToString();
                                if (ParSib[51] != null)
                                {
                                    string IsTax = ParSib[51].ToString();
                                    if (IsTax == "Y")
                                        empSibling.IsTax = true;
                                    else if (IsTax == "N")
                                        empSibling.IsTax = false;
                                }
                                empSibling.IsDeleted = false;
                                emp.Employee_Relative.Add(empSibling);
                            }
                            //////////////////////////////////////////////////////////////////////
                            empSibling = new Entity_Framework.Employee_Relative();
                            if (ParSib[52] != null)
                            {
                                empSibling.RelativeName = ParSib[52].ToString();
                                empSibling.Relation = 4; // For Sibling5
                                if (ParSib[54] != null)
                                {
                                    if (ParSib[54].ToString() == "Y")
                                        empSibling.IsAlive = true;
                                    else if (ParSib[54].ToString() == "N")
                                        empSibling.IsAlive = false;
                                }
                                if (ParSib[55] != null)
                                    empSibling.Occupation = ParSib[55].ToString();
                                if (ParSib[56] != null)
                                    empSibling.nameOfCompany = ParSib[56].ToString();
                                if (ParSib[57] != null)
                                    empSibling.Address = ParSib[57].ToString();
                                if (ParSib[58] != null)
                                    empSibling.Phone = ParSib[58].ToString();
                                if (ParSib[59] != null)
                                {
                                    string IsTax = ParSib[59].ToString();
                                    if (IsTax == "Y")
                                        empSibling.IsTax = true;
                                    else if (IsTax == "N")
                                        empSibling.IsTax = false;
                                }
                                empSibling.IsDeleted = false;
                                emp.Employee_Relative.Add(empSibling);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Parents & Siblings!");
                            return;
                        }

                        try
                        {
                            #region Spouse And Children

                            if (SpoFam[4] != null)
                            {
                                empSpouse.RelativeName = SpoFam[4].ToString();
                                empSpouse.Relation = 2; // For Spouse
                                if (SpoFam[5] != null)
                                    empSpouse.Occupation = SpoFam[5].ToString();
                                if (SpoFam[6] != null)
                                    empSpouse.Phone = SpoFam[6].ToString();
                                if (SpoFam[7] != null)
                                    empSpouse.nameOfCompany = SpoFam[7].ToString();
                                if (SpoFam[8] != null)
                                    empSpouse.Address = SpoFam[8].ToString();
                                if (SpoFam[10] != null)
                                {
                                    if (SpoFam[10].ToString() == "Y")
                                        empSpouse.IsTax = true;
                                    else if (SpoFam[10].ToString() == "N")
                                        empSpouse.IsTax = false;
                                }
                                empSpouse.IsDeleted = false;
                                emp.Employee_Relative.Add(empSpouse);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            if (SpoFam[11] != null)
                            {
                                empChildren.RelativeName = SpoFam[11].ToString();
                                empChildren.Relation = 3; // For Child 1
                                if (SpoFam[12] != null)
                                    empChildren.DOB = DateTime.Parse(SpoFam[12]);
                                empChildren.IsTax = false;
                                empChildren.IsDeleted = false;
                                emp.Employee_Relative.Add(empChildren);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            empChildren = new Entity_Framework.Employee_Relative();
                            if (SpoFam[13] != null)
                            {
                                empChildren.RelativeName = SpoFam[13].ToString();
                                empChildren.Relation = 3; // For Child 2
                                if (SpoFam[14] != null)
                                    empChildren.DOB = DateTime.Parse(SpoFam[14].ToString());
                                empChildren.IsTax = false;
                                empChildren.IsDeleted = false;
                                emp.Employee_Relative.Add(empChildren);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            empChildren = new Entity_Framework.Employee_Relative();
                            if (SpoFam[15] != null)
                            {
                                empChildren.RelativeName = SpoFam[15].ToString();
                                empChildren.Relation = 3; // For Child 3
                                if (SpoFam[16] != null)
                                    empChildren.DOB = DateTime.Parse(SpoFam[16].ToString());
                                empChildren.IsTax = false;
                                empChildren.IsDeleted = false;
                                emp.Employee_Relative.Add(empChildren);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            empChildren = new Entity_Framework.Employee_Relative();
                            if (SpoFam[17] != null)
                            {
                                empChildren.RelativeName = SpoFam[17].ToString();
                                empChildren.Relation = 3; // For Child 4
                                if (SpoFam[18] != null)
                                    empChildren.DOB = DateTime.Parse(SpoFam[18].ToString());
                                empChildren.IsTax = false;
                                empChildren.IsDeleted = false;
                                emp.Employee_Relative.Add(empChildren);
                            }
                            ////////////////////////////////////////////////////////////////////////
                            empChildren = new Entity_Framework.Employee_Relative();
                            if (SpoFam[19] != null)
                            {
                                empChildren.RelativeName = SpoFam[19].ToString();
                                empChildren.Relation = 3; // For Child 4
                                if (SpoFam[20] != null)
                                    empChildren.DOB = DateTime.Parse(SpoFam[20].ToString());
                                empChildren.IsTax = false;
                                empChildren.IsDeleted = false;
                                emp.Employee_Relative.Add(empChildren);
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Spouse & Children!");
                            return;
                        }

                        #region To insert into DB
                        try
                        {
                            // To Check same employe & same Finger ID already exist in database!
                            DataTable dt = new EmployeeDAO().CheckNameANDFigID(emp.EmpName.ToString(),int.Parse(emp.FingerID.ToString()));
                            if (dt.Rows.Count == 0)
                            {
                                new EmployeeBUS().InsertEntity(emp);
                                Success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Success = false;
                            throw ex;
                        }
                        #endregion
                    }
                }
            }

            if (Success)
            {
                MessageBox.Show("Successfully Saved!");                
            }
            else
            {
                MessageBox.Show("Unsuccessfully Saved!");                
            }
            this.Close();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeaderPCat_Click(object sender, EventArgs e)
        {

        }
    }
}
