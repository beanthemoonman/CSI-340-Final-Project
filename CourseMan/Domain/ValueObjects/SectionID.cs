﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMan.Domain
{
	public struct SectionID
	{
        private CourseID courseId;
        private int sectionNumber; // 2-digit section number (unique per course).


        public SectionID(string majorCode, int courseNumber, int sectionNumber)
        {
            this.courseId = new CourseID(majorCode, courseNumber);
            this.sectionNumber = sectionNumber;
        }

        public SectionID(CourseID courseId, int sectionNumber)
        {
            this.courseId = courseId;
            this.sectionNumber = sectionNumber;
        }


        public override string ToString()
        {
            return String.Format("{0}-{1,2:00}", courseId.ToString(), sectionNumber);
        }


        public CourseID CourseID
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string MajorCode
        {
            get { return courseId.MajorCode; }
            set { courseId.MajorCode = value; }
        }

        public int CourseNumber
        {
            get { return courseId.CourseNumber; }
            set { courseId.CourseNumber = value; }
        }

        public int SectionNumber
        {
            get { return sectionNumber; }
            set { sectionNumber = value; }
        }
	}
}