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
        int EMPLOYEEID = 0;
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
                        try
                        {
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


                                employee.ApplicantID = 1;
                                employee.PostID = 1;
                                employee.EmpPhoto = null;
                                employee.SalaryLvlID = 1;
                                //employee.Criminalrecord = null;
                                //employee.ReferencesName1 = null;
                                //employee.ReferencesName2 = null;
                                //employee.ReferencesPh1 = null;
                                //employee.ReferencesPh2 = null;

                                if (EduWEx[31] != null)
                                {
                                    employee.ReferencesName1 = EduWEx[31];
                                }
                                if (EduWEx[33] != null)
                                {
                                    employee.ReferencesPh1 = EduWEx[33];
                                }
                                
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Empoyee Insert Error:" + ex.ToString());
                        }

                        try
                        {
                            #region for inserting to employee address table Both Current Address and Permanent Address
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
                                        if (value == DBNull.Value)
                                        {
                                            MessageBox.Show("Can't Find Filled State Division!");
                                        }
                                        else
                                        {
                                            var Id = dt.Rows[0][0];
                                            string ID = Id.ToString();
                                            int stateDivisionID = Convert.ToInt32(ID);
                                            address.StateDivisionID = stateDivisionID;
                                            //MessageBox.Show(ID);
                                        }
                                    }
                                }

                                address.ApplicantID = 1;
                                address.IsPermanent = false;
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
                                    // MessageBox.Show("Inserting to Address table for not permanent is success");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Occurred in Employee Info!");
                                return;
                            }

                            try
                            {
                                AddressVO vo = new AddressVO();
                                vo.EmpID = EMPLOYEEID;
                                vo.ApplicantID = 1;
                                vo.IsPermanent = true;
                                if (Info[26] != null)
                                {
                                    vo.HomeNo = Info[26];
                                }
                                if (Info[27] != null)
                                {
                                    vo.Street = Info[27];
                                }
                                if (Info[28] != null)
                                {
                                    vo.Quarter = Info[28];
                                }

                                if (Info[29] != null)
                                {
                                    string townshipName = Info[29];
                                    AddressVO vo1 = new AddressDAO().GetIDByName(townshipName);
                                    if (vo1.TownshipID == 0)
                                    {
                                        vo1.TownshipID = 1;
                                    }
                                    vo.TownshipID = vo1.TownshipID;
                                }
                                if (Info[32] != null)
                                {
                                    vo.Phone = Info[32];
                                }
                                if (Info[31] != null)
                                {
                                    string stateDivisionName = Info[31];
                                    System.Data.DataTable dt = new StateDivisionDAO().SelectByDivisionName(stateDivisionName);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        object value = row["ID"];
                                        if (value == DBNull.Value)
                                        {
                                            MessageBox.Show("Can't Find Filled State Division!");
                                        }
                                        else
                                        {
                                            var Id = dt.Rows[0][0];
                                            string ID = Id.ToString();
                                            int stateDivisionID = Convert.ToInt32(ID);
                                            vo.StateDivisionID = stateDivisionID;
                                            //MessageBox.Show(ID);
                                        }
                                    }
                                }

                                AddressDAO addressDAO = new AddressDAO();
                                int lastInsertedId = addressDAO.Insert(vo);
                                if (lastInsertedId > 0)
                                {
                                    // MessageBox.Show("Inserting to Address table for permanent is success");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Occurred in Employee Info!");
                                return;
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Address Insert Error:" + ex.ToString());
                        }
                        
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
                            if (EduWEx[4] != null && EduWEx[5] != null && EduWEx[6] != null)
                            {
                                quvo.Degree = EduWEx[4]; quvo.University = EduWEx[5]; quvo.QYear = EduWEx[6];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[7] != null && EduWEx[8] != null && EduWEx[9] != null)
                            {
                                quvo.Degree = EduWEx[7]; quvo.University = EduWEx[8]; quvo.QYear = EduWEx[9];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[10] != null && EduWEx[11] != null && EduWEx[12] != null)
                            {
                                quvo.Degree = EduWEx[10]; quvo.University = EduWEx[11]; quvo.QYear = EduWEx[12];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            if (EduWEx[13] != null && EduWEx[14] != null && EduWEx[15] != null)
                            {
                                quvo.Degree = EduWEx[13]; quvo.University = EduWEx[14]; quvo.QYear = EduWEx[15];
                                EmployeeQualificationDAO dao = new EmployeeQualificationDAO();
                                dao.Insert(quvo);
                            }
                            //MessageBox.Show("Inserting to Qualification Table is OK");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Occurred in Inserting Data to Employee_Qualification!");
                            return;
                        }
                        #endregion

                        #region for Inserting Working Experience
                        EmployeeWorkingExperienceVO vo = new EmployeeWorkingExperienceVO();
                        vo.EmpID = EMPLOYEEID;
                        //17/18/19/20/21 - Array Index for Column
                        if (EduWEx[16] != null && EduWEx[17] != null && EduWEx[18] != null && EduWEx[19] != null && EduWEx[20] != null)
                        {
                            vo.Period = EduWEx[16]; vo.Company = EduWEx[17]; vo.Position = EduWEx[18]; vo.Address = EduWEx[19]; vo.Phone = EduWEx[20]; vo.RefName = EduWEx[31];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }
                        if (EduWEx[21] != null && EduWEx[22] != null && EduWEx[23] != null && EduWEx[24] != null && EduWEx[25] != null)
                        {
                            vo.Period = EduWEx[21]; vo.Company = EduWEx[22]; vo.Position = EduWEx[23]; vo.Address = EduWEx[24]; vo.Phone = EduWEx[25]; vo.RefName = EduWEx[31];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }
                        if (EduWEx[26] != null && EduWEx[27] != null && EduWEx[28] != null && EduWEx[29] != null && EduWEx[30] != null)
                        {
                            vo.Period = EduWEx[26]; vo.Company = EduWEx[27]; vo.Position = EduWEx[28]; vo.Address = EduWEx[29]; vo.Phone = EduWEx[30]; vo.RefName = EduWEx[31];
                            EmployeeWorkingExperienceDAO doa = new EmployeeWorkingExperienceDAO();
                            doa.Insert(vo);
                        }
                        //MessageBox.Show("Inserting to Working Experience is OK");
                        #endregion

                        #endregion

                    }
                    if (WorkHisBank.Count() != 0)
                    {
                        #region sheet3

                        #region for Inserting Bank Information
                        //Insert employee bank info
                        //EmpID,BankID,AccountNumber,AccountType
                        EmployeeBankInfoVO vo = new EmployeeBankInfoVO();
                        //Cell Start From 15,16,17->18,19,20
                        vo.EmpID = EMPLOYEEID;
                        if (WorkHisBank[14] != null && WorkHisBank[15] != null && WorkHisBank[16] != null)
                        {
                            string bankName = WorkHisBank[14];
                            BankVO bvo = new BankDAO().GetByBank(bankName);
                            vo.BankID = bvo.Id;//Get BankID from Bank table
                            vo.AccountNumber = WorkHisBank[15];
                            vo.AccountType = WorkHisBank[16];

                            EmployeeBankInfoDAO empdao = new EmployeeBankInfoDAO();
                            empdao.Insert(vo);
                        }
                        if (WorkHisBank[17] != null && WorkHisBank[18] != null && WorkHisBank[19] != null)
                        {
                            string bankName = WorkHisBank[17];
                            BankVO bvo = new BankDAO().GetByBank(bankName);
                            vo.BankID = bvo.Id;//Get BankID from Bank table
                            vo.AccountNumber = WorkHisBank[18];
                            vo.AccountType = WorkHisBank[19];

                            EmployeeBankInfoDAO empdao = new EmployeeBankInfoDAO();
                            empdao.Insert(vo);
                           // MessageBox.Show("Inserting in to Employee bank Info is OK");
                        }
                        #endregion
                       
                        #endregion
                    }
                    if (ParSib.Count() != 0)
                    {
                        #region sheet4
                        #region for Inserting Both Relative Information and Children Information
                        EmployeeRelativeVO vo = new EmployeeRelativeVO();
                        vo.EmpID = EMPLOYEEID;
                        if (ParSib[4] != null)
                        {
                            vo.RelativeName = ParSib[4];
                            vo.Relation = "Partner";
                        }
                        if (ParSib[7] != null)
                        {
                            vo.NameOfCompany = ParSib[7];
                        }
                        if (ParSib[5] != null)
                        {
                            vo.Occupation = ParSib[5];
                        }
                        if (ParSib[8] != null)
                        {
                            vo.Address = ParSib[8];
                        }
                        if (ParSib[6] != null)
                        {
                            vo.Phone = ParSib[6];
                        }
                        EmployeeRelativeDAO redao = new EmployeeRelativeDAO();
                        redao.Insert(vo);
                        if (ParSib[10] != null && ParSib[11] != null)
                        {
                            EmployeeRelativeVO childrenvo1 = new EmployeeRelativeVO();
                            childrenvo1.EmpID = EMPLOYEEID;
                            childrenvo1.RelativeName = ParSib[10];
                            childrenvo1.Relation = "Children";
                            redao.Insert(childrenvo1);
                            string dateOfBirth = ParSib[11].ToString();
                            DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                            string DOB = DateOfBirth.ToString("yyyy-MM-dd");
                            redao.InsertWithNoObject("INSERT INTO Employee_Children (EmpID, ChildrenName, DOB) VALUES (" + EMPLOYEEID + ", N'" + ParSib[10] + "'," + DOB + ")");
                        }
                        if (ParSib[12] != null && ParSib[13] != null)
                        {
                            EmployeeRelativeVO childrenvo2 = new EmployeeRelativeVO();
                            childrenvo2.EmpID = EMPLOYEEID;
                            childrenvo2.RelativeName = ParSib[12];
                            childrenvo2.Relation = "Children";
                            redao.Insert(childrenvo2);
                            string dateOfBirth = ParSib[13].ToString();
                            DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                            string DOB = DateOfBirth.ToString("yyyy-MM-dd");
                            redao.InsertWithNoObject("INSERT INTO Employee_Children (EmpID, ChildrenName, DOB) VALUES (" + EMPLOYEEID + ", N'" + ParSib[12] + "'," + DOB + ")");
                        }
                        if (ParSib[14] != null && ParSib[15] != null)
                        {
                            EmployeeRelativeVO childrenvo3 = new EmployeeRelativeVO();
                            childrenvo3.EmpID = EMPLOYEEID;
                            childrenvo3.RelativeName = ParSib[14];
                            childrenvo3.Relation = "Children";
                            redao.Insert(childrenvo3);
                            string dateOfBirth = ParSib[15].ToString();
                            DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                            string DOB = DateOfBirth.ToString("yyyy-MM-dd");
                            redao.InsertWithNoObject("INSERT INTO Employee_Children (EmpID, ChildrenName, DOB) VALUES (" + EMPLOYEEID + ", N'" + ParSib[14] + "'," + DOB + ")");
                        }
                        if (ParSib[16] != null && ParSib[17] != null)
                        {
                            EmployeeRelativeVO childrenvo4 = new EmployeeRelativeVO();
                            childrenvo4.EmpID = EMPLOYEEID;
                            childrenvo4.RelativeName = ParSib[16];
                            childrenvo4.Relation = "Children";
                            redao.Insert(childrenvo4);
                            string dateOfBirth = ParSib[17].ToString();
                            DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                            string DOB = DateOfBirth.ToString("yyyy-MM-dd");
                            redao.InsertWithNoObject("INSERT INTO Employee_Children (EmpID, ChildrenName, DOB) VALUES (" + EMPLOYEEID + ", N'" + ParSib[16] + "'," + DOB + ")");
                        }
                        //MessageBox.Show("Inserting into Employee Relative and Children is OK");
                        #endregion
                        #endregion
                    }
                }
            }
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
    }
}