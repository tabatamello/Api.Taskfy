using Api.Taskfy.Data;
using Api.Taskfy.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Taskfy.Services
{
    public class TaskService
    {
        private readonly TaskContext _context;
        public TaskService(TaskContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> CreateTaskAsync(TaskModel task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return task;

        }

        public async Task<List<TaskModel>> ListTasks()
        {
            var tasks = await _context.Task.ToListAsync();
            return tasks;
        }

        public async Task<TaskModel> AlterTask(TaskModel task)
        {
            var alterTask = await FindTask(task.Id);

            if (alterTask == null)
                return null;

            alterTask.Title = task.Title;
            alterTask.Description = task.Description;
            alterTask.IsCompleted = task.IsCompleted;
            alterTask.DateChange = DateTime.UtcNow;

            _context.Task.Update(alterTask);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> AlterStatusTask(TaskModel task, bool isCompleted)
        {
            task.IsCompleted = isCompleted;
            task.DateChange = DateTime.UtcNow;

            _context.Task.Update(task);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> FindTask(long id)
        {
            var task = await _context.Task.FindAsync(id);
            return task;
        }

        public async Task<TaskModel> DeleteTask(TaskModel task)
        {
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
