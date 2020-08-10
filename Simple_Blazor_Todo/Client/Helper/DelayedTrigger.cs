using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Client.Helper
{
    public class DelayedTrigger
    {
        private int _FireInfoDelay;
        private Action _ToTrigger;
        private CancellationTokenSource _TokenSource;

        public DelayedTrigger()
        {
        }

        public DelayedTrigger(int fireInfoDelay, Action toTrigger)
        {
            _FireInfoDelay = fireInfoDelay;
            _ToTrigger = toTrigger;
        }

        public async Task PropertyChanged(string propertyName)
        {
            //TODO: not the best way to do it!
            if(_TokenSource != null)
            {
                _TokenSource.Cancel();
            }
            
            _TokenSource = new CancellationTokenSource();
            try
            {
                Task t = Task.Delay(_FireInfoDelay, _TokenSource.Token);
                await t;
                if (!t.IsCanceled)
                {
                    if(_ToTrigger != null)
                    {
                        _ToTrigger.Invoke();
                    }
                }
            }catch(Exception  e)
            {

            }
        }
    }
}
