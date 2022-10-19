using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManager.CustomEvents
{
    public class CandidateHandler
    {
        public event EventHandler<string> OnRefreshCandidateData;
        public CandidateHandler()
        {
            // OnEmailItemChanged("");
        }
        public void OnEmailItemChanged(string e)
        {
            EventHandler<string> handler = OnRefreshCandidateData;
            if (handler != null)
            {
                handler(this,e);
            }
        }
    }
}
