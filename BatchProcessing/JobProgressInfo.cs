using System;

namespace DMS
{
    [Serializable()]
    public class JobProgressInfo : DMS.ProgressInfo
    {
        public JobProgressInfo(int jobId, Job.JobStates jobState)
        {
            this.mJobId = jobId;
            this.mJobState = jobState;
        }       

        int mJobId;
        public int JobId
        {
            get
            {
                return mJobId;
            }
        }


        Job.JobStates mJobState;
        public Job.JobStates JobState
        {
            get
            {
                return mJobState;
            }
        }

    } // End Class
}