using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Client.Helper
{
    public class AutoSave<T>
    {
        public IList<T> ChangedEntities { get; set; }
        public Func<IList<T>, Task<bool>> SaveEntities { get; set; }

        private Timer _Timer;
        
        public event EventHandler SavedAllChanges;
        public event EventHandler UnsavedChanges;
        
        private int _timerDelay = 1000;
        private const int _minDelay = 100;
        private const int _maxDelay = 90000;

        public int TimerDelay { 
            get => _timerDelay; 
            set {
                _timerDelay = Math.Min(Math.Max(_minDelay, value), _maxDelay);
            } 
        }

        public bool AllChangesSaved => ChangedEntities == null || ChangedEntities.Count < 1;

        public AutoSave()
        {
            ChangedEntities = new List<T>();
        }

        private async void TimerTick(object state)
        {
            if(ChangedEntities != null && ChangedEntities.Count > 0)
            {
                Console.WriteLine($"About to save {ChangedEntities.Count}");
                await Save();
            }
            else
            {
                Console.WriteLine($"Nothing to save");
            }
        }

        public async Task Save()
        {
            if (SaveEntities != null)
            {
                await SaveEntities.Invoke(ChangedEntities);
                ChangedEntities.Clear();
                StopTimer();
                AfterSaveChanges();
            }
            else
            {
                Console.WriteLine("No SaveEntities");
            }
        }

        private void StopTimer()
        {
            if (_Timer != null)
            {
                Console.WriteLine("Timer stopped");
                _Timer.Change(Timeout.Infinite, Timeout.Infinite);
                _Timer.Dispose();
                _Timer = null;
            }
        }
        private void StartTimer()
        {
            Console.WriteLine("New Timer");
            _Timer = new Timer(new TimerCallback(TimerTick), null, _timerDelay, _timerDelay);
        }

        public void AddChangedEntity(T entity)
        {
            if(!ChangedEntities.Contains(entity)){
                Console.WriteLine("New Entity Added");
                ChangedEntities.Add(entity);
                OnUnsavedChanges();
            }

            if (_Timer == null)
            {
                StartTimer();
            }
        }

        private void OnUnsavedChanges()
        {
            UnsavedChanges?.Invoke(this, EventArgs.Empty);
        }

        private void AfterSaveChanges()
        {
            SavedAllChanges?.Invoke(this, EventArgs.Empty);
        }
    }
}
