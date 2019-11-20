using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Interfaces;
using TaskList.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskList.Queries
{
    public class TaskQuery: IRepository
    {
        private readonly TaskListContext _db;

        public TaskQuery(TaskListContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskViewModel>> GetAll()
        {
            List<TaskViewModel> myTasks = new List<TaskViewModel>();

            return await _db
                 .Task
                 .Select(task => new TaskViewModel
                 {
                    taskId = task.taskId,
                     taskDescription = task.taskDescription,
                     Status = task.Status
                 })
                 .ToListAsync();
        }

        public async Task<TaskViewModel> GetMyTask(int id)
        {
            
            return await _db
                 .Task
                 .Where(task => task.taskId == id)
                 .Select(task => new TaskViewModel
                 {
                     taskId = task.taskId,
                     taskDescription = task.taskDescription,
                     Status = task.Status
                 })
                 .FirstOrDefaultAsync();
         
        }
        public async Task<bool> UpdateTask(int id, TaskRequest task)
        {
 
            try
            {
                var myTask = _db.Task.Where(task => task.taskId == id).FirstOrDefault();

                myTask.taskDescription = task.taskDescription;
                myTask.Status = task.Status;
                
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return false;
            }

            return true;
        }

        public async Task<bool> InsertTask(TaskRequest task)
        {
            var myTask = new myTask
            {
                taskDescription = task.taskDescription,
                Status = task.Status
            };

            _db.Task.Add(myTask);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _db.Task.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _db.Task.Remove(task);
            await _db.SaveChangesAsync();

            return true;
        }

        public bool TaskExists(int id)
        {
            return _db.Task.Any(e => e.taskId == id);
        }


        }
}
