using System.Collections.Generic;

namespace LibAtem.State.Builder
{
    public interface IUpdateResult
    {
        bool Success { get; }
        IReadOnlyList<string> ChangedPaths { get; }
        IReadOnlyList<string> Errors { get; }
    }
    
    internal class UpdateResultImpl: IUpdateResult
    {
        private readonly List<string> _changedPaths;
        private readonly List<string> _errors;
        private bool _success;

        public bool Success => _success;

        public IReadOnlyList<string> ChangedPaths => _changedPaths;

        public IReadOnlyList<string> Errors => _errors;

        public UpdateResultImpl()
        {
            _changedPaths = new List<string>();
            _errors = new List<string>();
        }

        public void SetSuccess(IEnumerable<string> paths)
        {
            _success = true;
            _changedPaths.AddRange(paths);
        }
        public void SetSuccess(string path)
        {
            _success = true;
            _changedPaths.Add(path);
        }
        
        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}