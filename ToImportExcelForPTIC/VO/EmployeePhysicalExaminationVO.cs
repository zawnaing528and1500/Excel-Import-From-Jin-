using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class EmployeePhysicalExaminationVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int empID;

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        private bool isPallor;

        public bool IsPallor
        {
            get { return isPallor; }
            set { isPallor = value; }
        }
        private bool isJaundice;

        public bool IsJaundice
        {
            get { return isJaundice; }
            set { isJaundice = value; }
        }
        private bool isSkinRash;

        public bool IsSkinRash
        {
            get { return isSkinRash; }
            set { isSkinRash = value; }
        }
        private bool isDeformities;

        public bool IsDeformities
        {
            get { return isDeformities; }
            set { isDeformities = value; }
        }
        private bool isSwelling;

        public bool IsSwelling
        {
            get { return isSwelling; }
            set { isSwelling = value; }
        }
        private bool isDischarge;

        public bool IsDischarge
        {
            get { return isDischarge; }
            set { isDischarge = value; }
        }
        private bool isCardivoascular;

        public bool IsCardivoascular
        {
            get { return isCardivoascular; }
            set { isCardivoascular = value; }
        }
        private bool isRespiratory;

        public bool IsRespiratory
        {
            get { return isRespiratory; }
            set { isRespiratory = value; }
        }
        private bool isGenitourinary;

        public bool IsGenitourinary
        {
            get { return isGenitourinary; }
            set { isGenitourinary = value; }
        }
        private bool isCentralNervous;

        public bool IsCentralNervous
        {
            get { return isCentralNervous; }
            set { isCentralNervous = value; }
        }
        private bool isMusculoskeletal;

        public bool IsMusculoskeletal
        {
            get { return isMusculoskeletal; }
            set { isMusculoskeletal = value; }
        }
        private string generalCondition;

        public string GeneralCondition
        {
            get { return generalCondition; }
            set { generalCondition = value; }
        }
        private string other;

        public string Other
        {
            get { return other; }
            set { other = value; }
        }
    }
}
