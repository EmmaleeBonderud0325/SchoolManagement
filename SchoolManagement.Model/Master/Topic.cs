﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Topic
    {
        public int TopicID { get; set; }
        public int? LessonID { get; set; }
        public string Name { get; set; }
        public int SequenceNo { get; set; }
        public string LearningExperience { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn{ get; set; }

        public virtual Lesson LessonId { get; set; }

        public virtual ICollection<TopicContent>Topics { get; set; }

    }
}
