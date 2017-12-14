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

namespace ToImportExcelForPTIC
{
    public partial class Form2 : Form
    {
        int EMPLOYEEID = 1;
        public Form2()
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
            Excel.Worksheet xlWSInfo;
            Excel.Worksheet xlWSEduWorkExp;
            Excel.Worksheet xlWSWorkHisBank;
            Excel.Worksheet xlWSParSib;
            Excel.Worksheet xlWSSpouFam;

            Excel.Range range, rangeEdu, rangeWHis, rangeParent, rangeSpouse;

            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(txtFileName.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            #region get sheet and define range
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
            #endregion

            
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                if ((range.Cells[rCnt + 3, 3] as Excel.Range).Value != null)
                {
                    #region Sheet to Array
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

                    if (Info.Count() != 0)
                    {
                        #region Sheet1

                        #region For Inserting into Employee Table
                        EmployeeVO employee = new EmployeeVO();
                        

                        try
                        {
                            //Get Employed Date
                            if (Info[0] != null)
                                employee.EmployDate = DateTime.Parse(Info[0].ToString());
                            //Get Employee Name
                            if (Info[1] != null)
                                employee.EmpName = Info[1].ToString();
                            //Get Position Name and use it to retrieve Position ID
                            if (Info[2] != null)
                            {
                                string postName = Info[2].ToString();
                                JobPositionVO vo = new JobPositionDAO().GetIDByName(postName);
                                if (vo.Id == 0)
                                {
                                    vo.Id = 1;
                                }
                                employee.PostID = vo.Id;

                                //employee.PostID = 1;
                            }
                            //Get Department name and use it to retrieve Deptment ID
                            if (Info[3] != null)
                            {
                                string deptName = Info[5].ToString();
                                DepartmentVO vo = new DepartmentDAO().GetIDByName(deptName);
                                if (vo.Id == 0)
                                {
                                    //MessageBox.Show("Invalid Department Name!");
                                    //return;
                                    vo.Id = 1;
                                }
                                employee.DeptID = vo.Id;
                                //employee.DeptID = 2;
                            }
                            //Get fingerID
                            if (Info[4] != null)
                            {
                                string fingerID = Info[4].ToString();
                                employee.FingerID = Convert.ToInt32(fingerID);
                            }
                            //Get Date of Birth
                            if (Info[5] != null)
                            {
                                string dateOfBirth = Info[5].ToString();
                                DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                                employee.DOB = DateOfBirth;
                            }
                            //Get Employee NRC
                            if (Info[6] != null)
                                employee.NRCNo = Info[6].ToString();
                            //Get Employed Date
                            if (Info[7] != null)
                            {
                                string employedDate = Info[7].ToString();
                                DateTime EmployedDate = DateTime.Parse(employedDate);
                                employee.EmployDate = EmployedDate;
                            }
                            //Get Approval Date
                            if (Info[8] != null)
                            {
                                employee.ApprovalDate = DateTime.Parse(Info[8].ToString());
                                employee.IsPermanent = true;
                            }
                            else
                            {
                                employee.IsPermanent = false;
                            }
                            //Get Father Name
                            if (Info[9] != null)
                                employee.FatherName = Info[9].ToString();
                            //Get Race
                            if (Info[10] != null)
                                employee.Race = Info[10].ToString();
                            //Get Religion
                            if (Info[11] != null)
                            {
                                if (Info[10].ToString() == "ဗုဒ္ဓဘာသာ")
                                {
                                    employee.Religion = 1;
                                }
                                else if (Info[10].ToString() == "မူဆလင်")
                                {
                                    employee.Religion = 2;
                                }
                                else if (Info[10].ToString() == "ခရစ်ယာန်")
                                {
                                    employee.Religion = 3;
                                }
                                else
                                {
                                    employee.Religion = 4;
                                }
                            }
                            //Get Gender
                            if (Info[12] != null)
                            {
                                if (Info[12].ToString() == "1")
                                    employee.Gender = true;
                                else if (Info[12].ToString() == "0")
                                    employee.Gender = false;
                            }

                            //get Mariental Status
                            if (Info[13] != null)
                            {
                                if (Info[13].ToString() == "1")
                                    employee.MaritalStatus = true;
                                else if (Info[13].ToString() == "0")
                                    employee.MaritalStatus = false;
                            }
                            //get Passport Number
                            if (Info[14] != null)
                            {
                                employee.PassportNo = Info[14].ToString();
                            }
                            //Get Social Security Number
                            if (Info[15] != null)
                            {
                                employee.SSCode = Info[15].ToString();
                            }
                            //Get Driver License
                            if (Info[16] != null)
                                employee.DriverLicence = Info[16].ToString();
                            //Get in Case of Death Name of beneficiary
                            if (Info[17] != null)
                                employee.IncaseOfDeathNameOfBeneficiary = Info[17].ToString();
                            // Get Criminal
                            if (Info[18] != null)
                            {
                                if (Info[13].ToString() == "1")
                                    employee.Criminal = true;
                                else if (Info[13].ToString() == "0")
                                    employee.Criminal = false;
                            }
                            

                            employee.ApplicantID= 1;
                            employee.PostID = 1;
                            employee.EmpPhoto = null;
                            employee.SalaryLvlID = 1;
                            //employee.Criminalrecord = null;
                            //employee.ReferencesName1 = null;
                            //employee.ReferencesName2 = null;
                            //employee.ReferencesPh1 = null;
                            //employee.ReferencesPh2 = null;
                            employee.IsActive = true;
                            employee.IsDeleted = false;
                            employee.CreatedDate = DateTime.Today;
                            employee.LastModified = DateTime.Today;
                            employee.IsBLO = null;
                            employee.EmpPhoto = new byte[0];                         
                            //Insert into employee table
                            EmployeeDAO employeeDAO = new EmployeeDAO();

                            //This is need to uncomment
                            int lastInsertId = employeeDAO.Insert(employee);
                            EMPLOYEEID = lastInsertId;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in inserting to Employee Table!");
                            return;
                        }
                        #endregion

                        #region for inserting to employee address table
                        try
                        {
                            AddressVO address = new AddressVO();
                            //Get Home  Number
                            if (Info[19] != null)
                            {
                                address.HomeNo = Info[19];
                            }
                            //Get Street Number
                            if (Info[20] != null)
                            {
                                address.Street = Info[20];
                            }
                            if (Info[21] != null)
                            {
                                address.Quarter = Info[21];
                            }
                            //Get TownshipID by Name
                            if (Info[22] != null)
                            {
                                string townshipName = Info[22].ToString();
                                AddressVO vo = new AddressDAO().GetIDByName(townshipName);
                                if (vo.TownshipID == 0)
                                {
                                    vo.TownshipID = 1;
                                }
                                address.TownshipID = vo.TownshipID;
                            }
                            if (Info[32] != null)
                            {
                                address.Phone = Info[32].ToString();
                            }
                            //Get State Division ID by Name
                            if (Info[24] != null)
                            {
                                string stateDivisionName = Info[24].ToString();
                                System.Data.DataTable dt = new StateDivisionDAO().SelectByDivisionName(stateDivisionName);
                               foreach (DataRow row in dt.Rows)
                                    {
                                        object value = row["ID"];
                                        if (value == DBNull.Value){
                                            MessageBox.Show("Can't Find Filled State Division!");
                                        }
                                        else
                                        {
                                            var Id = dt.Rows[0][0];
                                            string ID = Id.ToString();
                                            int stateDivisionID = Convert.ToInt32(ID);
                                            address.StateDivisionID = stateDivisionID;
                                            MessageBox.Show(ID);
                                        }
                                    }
                            }

                            address.ApplicantID = 1;
                            //Get EmpID from FingerID
                            string figerID = Info[4].ToString();
                            int FigerID = Convert.ToInt32(figerID);
                            System.Data.DataTable EmpIDDT = new EmployeeDAO().GetEmpIDFromFingerID(FigerID);
                            foreach (DataRow row in EmpIDDT.Rows)
                            {
                                object value = row["ID"];
                                if (value == DBNull.Value)
                                {
                                    MessageBox.Show("Can't Find EmpID from FingerID!");
                                }
                                else
                                {
                                    int EmpID = Convert.ToInt32(row["ID"].ToString());
                                    address.EmpID = EmpID;
                                }
                            }

                            AddressDAO addressDAO = new AddressDAO();
                            int lastInsertedId = addressDAO.Insert(address);
                            if (lastInsertedId > 0)
                            {
                                MessageBox.Show("Inserting to Address table is success");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Employee Info!");
                            return;
                        }

                        #endregion

                        #endregion
                        
                    }
                    if (EduWEx.Count() != 0)
                    {
                        #region sheet2

                        #region for Inserting to Employee_Qualification
                        try
                        {
                            EmployeeQualificationVO quvo = new EmployeeQualificationVO();
                            //Database colums are EmpID, Degree, University, QYear
                            //Get string value from Excel
                            //EmpID should be declared as global variable
                            quvo.EmpID = EMPLOYEEID;
                            if (EduWEx[5] != null && EduWEx[6] != null && EduWEx[7] != null)
                            {
                                quvo.Degree = EduWEx[5]; quvo.University = EduWEx[6]; quvo.QYear = EduWEx[7];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[8] != null && EduWEx[9] != null && EduWEx[10] != null)
                            {
                                quvo.Degree = EduWEx[8]; quvo.University = EduWEx[9]; quvo.QYear = EduWEx[10];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[11] != null && EduWEx[12] != null && EduWEx[13] != null)
                            {
                                quvo.Degree = EduWEx[11]; quvo.University = EduWEx[12]; quvo.QYear = EduWEx[13];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[14] != null && EduWEx[15] != null && EduWEx[16] != null)
                            {
                                quvo.Degree = EduWEx[14]; quvo.University = EduWEx[15]; quvo.QYear = EduWEx[16];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Inserting Data to Employee_Qualification!");
                            return;
                        }
                        #endregion

                        #region working experience
                        EmployeeWorkingExperienceVO vo = new EmployeeWorkingExperienceVO();
                        //17/18/19/20/21
                        if (EduWEx[17] != null && EduWEx[18] != null && EduWEx[19] != null && EduWEx[20] != null && EduWEx[21] != null)
                        {
                            vo.Period = EduWEx[17]; vo.Company = EduWEx[18]; vo.Position = EduWEx[19]; vo.Address = EduWEx[20]; vo.Phone = EduWEx[21]; vo.RefName = EduWEx[32];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }
                        if (EduWEx[22] != null && EduWEx[23] != null && EduWEx[24] != null && EduWEx[25] != null && EduWEx[26] != null)
                        {
                            vo.Period = EduWEx[22]; vo.Company = EduWEx[23]; vo.Position = EduWEx[24]; vo.Address = EduWEx[25]; vo.Phone = EduWEx[26]; vo.RefName = EduWEx[32];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }
                        if (EduWEx[27] != null && EduWEx[28] != null && EduWEx[29] != null && EduWEx[30] != null && EduWEx[31] != null)
                        {
                            vo.Period = EduWEx[27]; vo.Company = EduWEx[28]; vo.Position = EduWEx[29]; vo.Address = EduWEx[30]; vo.Phone = EduWEx[31]; vo.RefName = EduWEx[32];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }                      
                        #endregion

                        #endregion

                    }
                    if(WorkHisBank.Count() != 0)
                    {
                        #region sheet3
                        //Insert employee bank info
                        //EmpID,BankID,AccountNumber,AccountType
                        EmployeeBankInfoVO vo = new EmployeeBankInfoVO();
                        //Cell Start From 15,16,17->18,19,20
                        vo.EmpID = EMPLOYEEID;
                        if(WorkHisBank[15] != null && WorkHisBank[16]!= null && WorkHisBank[17] != null)
                        {
                            string bankName = WorkHisBank[15];
                            BankVO bvo = new BankDAO().GetByBank(bankName);
                            vo.BankID = bvo.Id;//Get BankID from Bank table
                            vo.AccountNumber = WorkHisBank[16];
                            vo.AccountType = WorkHisBank[17];

                            EmployeeBankInfoDAO empdao = new EmployeeBankInfoDAO();
                            empdao.Insert(vo);
                        }
                        #endregion
                    }
                    if(ParSib.Count() != 0)
                    {
                        #region sheet4
                        EmployeeRelativeVO vo = new EmployeeRelativeVO();
                            vo.EmpID = EMPLOYEEID;
                        if(ParSib[5] != null)
                        {
                            vo.RelativeName = ParSib[5];
                            vo.Relation = "Partner";
                        }
                        if (ParSib[8] != null)
                        {
                            vo.NameOfCompany = ParSib[8];
                        }
                        if (ParSib[6] != null)
                        {
                            vo.Occupation = ParSib[6];
                        }
                        if (ParSib[9] != null)
                        {
                            vo.Address = ParSib[9];
                        }
                        if (ParSib[7] != null)
                        {
                            vo.Phone = ParSib[7];
                        }
                        EmployeeRelativeDAO redao = new EmployeeRelativeDAO();
                        redao.Insert(vo);
                        if(ParSib[11] != null && ParSib[12] != null)
                        {
                            EmployeeRelativeVO childrenvo1 = new EmployeeRelativeVO();
                            childrenvo1.RelativeName = ParSib[11];
                            childrenvo1.Relation = "Children";
                            redao.Insert(childrenvo1);
                        }
                        if (ParSib[13] != null && ParSib[14] != null)
                        {
                            EmployeeRelativeVO childrenvo2 = new EmployeeRelativeVO();
                            childrenvo2.RelativeName = ParSib[13];
                            childrenvo2.Relation = "Children";
                            redao.Insert(childrenvo2);
                        }
                        if (ParSib[15] != null && ParSib[16] != null)
                        {
                            EmployeeRelativeVO childrenvo3 = new EmployeeRelativeVO();
                            childrenvo3.RelativeName = ParSib[15];
                            childrenvo3.Relation = "Children";
                            redao.Insert(childrenvo3);
                        }
                        if (ParSib[17] != null && ParSib[18] != null)
                        {
                            EmployeeRelativeVO childrenvo4 = new EmployeeRelativeVO();
                            childrenvo4.RelativeName = ParSib[17];
                            childrenvo4.Relation = "Children";
                            redao.Insert(childrenvo4);
                        }
                        #endregion
                    }
                }
            }
          }
    }
}