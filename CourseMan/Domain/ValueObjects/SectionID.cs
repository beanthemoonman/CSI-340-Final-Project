﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMan.Domain.ValueObjects
{
	// Value object used to identify sections.
	public struct SectionID : IComparable<SectionID>
	{
        private CourseID courseId; // The course of which this section is an instance.
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

		// Convert a course ID to a string, combining the major code, course
		// number, and section number separated by dashes (ex: CSI-340-01)
        public override string ToString()
        {
            return String.Format("{0}-{1,2:00}", courseId.ToString(), sectionNumber);
        }

		public override bool Equals(object obj)
		{
			return (obj is SectionID && (SectionID) obj == this);
		}

		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + courseId.GetHashCode();
			hash = (hash * 7) + sectionNumber;
			return hash;
		}

		public int CompareTo(SectionID other)
		{
			// Order By:
			// 1. Major code.
			int returnVal = courseId.MajorCode.CompareTo(other.courseId.MajorCode);
			if (returnVal != 0)
				return returnVal;

			// 2. Course number.
			returnVal = courseId.CourseNumber.CompareTo(other.courseId.CourseNumber);
			if (returnVal != 0)
				return returnVal;

			// 3. Section number.
			return sectionNumber.CompareTo(other.sectionNumber);
		}

		public static bool operator ==(SectionID a, SectionID b)
		{
			return (a.courseId == b.courseId &&
					a.sectionNumber == b.sectionNumber);
		}

		public static bool operator !=(SectionID a, SectionID b)
		{
			return !(a == b);
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
