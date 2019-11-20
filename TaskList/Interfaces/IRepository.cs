using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Interfaces
{
    public interface IRepository
    {
        public Task<IEnumerable<TaskViewModel>> GetAll();

        public Task<TaskViewModel> GetMyTask(int id);

        public Task<bool> UpdateTask(int id, TaskRequest task);

        public Task<bool> InsertTask(TaskRequest task);

        public Task<bool> DeleteTask(int id);

        public bool TaskExists(int id);
    }
}
