using LingvaApp.Data;
using LingvaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LingvaApp.ViewModels
{
    public class ThemeViewModel
    {
        public ThemeViewModel(ApplicationDbContext dbContext, int themeId)
        {
            _tasks = dbContext.Tasks.Where(x => x.ThemeParentID == themeId).ToList();
            _fields = new List<List<Field>>();
            foreach (Task task in _tasks)
            {
                List<Field> fields = dbContext.Field.Where(x => x.TaskParentID == task.TaskID).ToList();
                if (fields.Count == 0)
                    continue;
                else
                    _fields.Add(fields);
            }
        }

        private readonly List<Task> _tasks;
        private readonly List<List<Field>> _fields;

        public List<Task> Tasks { get => _tasks; }
        public List<List<Field>> Fields { get => _fields; }
    }
}
