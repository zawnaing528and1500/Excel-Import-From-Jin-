using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
   public class ExternalTrainingAssessmentVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int trainingPlanDetailID;

        public int TrainingPlanDetailID
        {
            get { return trainingPlanDetailID; }
            set { trainingPlanDetailID = value; }
        }
        private int attendeeID;

        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }
        private DateTime assessmentDate;

        public DateTime AssessmentDate
        {
            get { return assessmentDate; }
            set { assessmentDate = value; }
        }
        private bool isAttendance;

        public bool IsAttendance
        {
            get { return isAttendance; }
            set { isAttendance = value; }
        }

        
        private string attendanceRemark;

        public string AttendanceRemark
        {
            get { return attendanceRemark; }
            set { attendanceRemark = value; }
        }
        private bool isCertificate;

        public bool IsCertificate
        {
            get { return isCertificate; }
            set { isCertificate = value; }
        }

        
        private string certificateRemark;

        public string CertificateRemark
        {
            get { return certificateRemark; }
            set { certificateRemark = value; }
        }
        private bool isReporting;

        public bool IsReporting
        {
            get { return isReporting; }
            set { isReporting = value; }
        }

        private string reportingRemark;

        public string ReportingRemark
        {
            get { return reportingRemark; }
            set { reportingRemark = value; }
        }
        private bool isKnowledgeSharing;

        public bool IsKnowledgeSharing
        {
            get { return isKnowledgeSharing; }
            set { isKnowledgeSharing = value; }
        }
        private string knowledgeSharingRemark;

        public string KnowledgeSharingRemark
        {
            get { return knowledgeSharingRemark; }
            set { knowledgeSharingRemark = value; }
        }
        private bool isFollowPolicy;

        public bool IsFollowPolicy
        {
            get { return isFollowPolicy; }
            set { isFollowPolicy = value; }
        }
      
        private string followPolicyRemark;

        public string FollowPolicyRemark
        {
            get { return followPolicyRemark; }
            set { followPolicyRemark = value; }
        }
        private string trainingTopic;

        public string TrainingTopic
        {
            get { return trainingTopic; }
            set { trainingTopic = value; }
        }

        private string applyKnowledge;

        public string ApplyKnowledge
        {
            get { return applyKnowledge; }
            set { applyKnowledge = value; }
        }
        private string benefits;

        public string Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }
        private string relatedTrainingCourse;

        public string RelatedTrainingCourse
        {
            get { return relatedTrainingCourse; }
            set { relatedTrainingCourse = value; }
        }
        private string isDifficult;

        public string IsDifficult
        {
            get { return isDifficult; }
            set { isDifficult = value; }
        }
        private string technicalGain;

        public string TechnicalGain
        {
            get { return technicalGain; }
            set { technicalGain = value; }
        }
        private string knowledgeGain;

        public string KnowledgeGain
        {
            get { return knowledgeGain; }
            set { knowledgeGain = value; }
        }
        private string knowledgeApply;

        public string KnowledgeApply
        {
            get { return knowledgeApply; }
            set { knowledgeApply = value; }
        }
        private string skillImprovement;

        public string SkillImprovement
        {
            get { return skillImprovement; }
            set { skillImprovement = value; }
        }
        private string workingHard;

        public string WorkingHard
        {
            get { return workingHard; }
            set { workingHard = value; }
        }
        private string hRManagerComment;

        public string HRManagerComment
        {
            get { return hRManagerComment; }
            set { hRManagerComment = value; }
        }
        private string cOOComment;

        public string COOComment
        {
            get { return cOOComment; }
            set { cOOComment = value; }
        }

    }
}
