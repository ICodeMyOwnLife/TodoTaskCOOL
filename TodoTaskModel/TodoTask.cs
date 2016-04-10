using System;
using CB.Model.Common;


namespace TodoTaskModel
{
    public class TodoTask: ObservableObject
    {
        #region Fields
        private string _content;
        private DateTime _deadline;
        private int? _id;
        private bool _isDone;
        #endregion


        #region  Properties & Indexers
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set { SetProperty(ref _deadline, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set { SetProperty(ref _isDone, value); }
        }
        #endregion


        public void CopyFrom(TodoTask task, bool copyId = false)
        {
            Content = task.Content;
            Deadline = task.Deadline;
            IsDone = task.IsDone;
            if (copyId) Id = task.Id;
        }
    }
}